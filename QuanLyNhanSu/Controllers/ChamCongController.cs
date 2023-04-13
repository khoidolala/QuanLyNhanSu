using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExcelDataReader;
using iTextSharp.text;
using OfficeOpenXml;
using PagedList;
using QuanLyNhanSu.Models;
namespace QuanLyNhanSu.Controllers
{
    public class ChamCongController : Controller
    {
        private DBContext db = new DBContext();

        // GET: ChamCong
        public ActionResult Index(string name, int page = 1)
        {
            page = page < 1 ? 1 : page;
            int pagesize = 10;
            var tblChamCong = db.tblChamCongs.OrderBy(x => x.Ngay).ThenBy(x => x.TenNV);
            return View(tblChamCong.ToPagedList(page, pagesize));
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase excelFile)
        {
            if (excelFile != null && excelFile.ContentLength > 0 &&
        (Path.GetExtension(excelFile.FileName) == ".xls" || Path.GetExtension(excelFile.FileName) == ".xlsx"))
            {
                try
                {
                    // Create a stream for the Excel file
                    Stream stream = excelFile.InputStream;
                    IExcelDataReader reader = null;

                    // Read the Excel file with either OpenXML or ClosedXML
                    if (Path.GetExtension(excelFile.FileName) == ".xls")
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (Path.GetExtension(excelFile.FileName) == ".xlsx")
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }

                    // Read the data from the Excel file
                    DataSet result = reader.AsDataSet();

                    // Loop through each sheet in the Excel file and read the data
                    
                   
                    foreach (DataTable table in result.Tables)
                    {
                        // Loop through each row in the sheet
                        for (int i = 1; i < table.Rows.Count; i++)
                        {
                            // Create a new TimeLog object and set its properties
                            var cc = new tblChamCong();                            
                            cc.MaNV = table?.Rows[i][0].ToString();
                            cc.TenNV = table?.Rows[i][1].ToString();
                           
                            string dateString = table?.Rows[i][2].ToString();
                            if (DateTime.TryParse(dateString, out DateTime dateValue))
                            {
                                cc.Ngay = dateValue;
                                
                            }
                            else
                            {
                                ViewBag.Message = "Ngày không đúng định dạng";
                            }
                            string timeString = table?.Rows[i][3].ToString();
                            timeString = timeString.Replace("SA", "AM").Replace("CH", "PM");
                            TimeSpan timeSpan = DateTime.ParseExact(timeString, "dd/MM/yyyy h:mm:ss tt", CultureInfo.InvariantCulture).TimeOfDay;
                            cc.ThoiGianVao = timeSpan;
                            string timeString1 = table?.Rows[i][4].ToString();
                            timeString1 = timeString1.Replace("SA", "AM").Replace("CH", "PM");
                            TimeSpan timeSpan1 = DateTime.ParseExact(timeString1, "dd/MM/yyyy h:mm:ss tt", CultureInfo.InvariantCulture).TimeOfDay;
                            cc.ThoiGianRa = timeSpan1;

                            cc.TrangThai = table?.Rows[i][5].ToString();
                            //kiem tra trung lap thong tin
                            var chamcongs = db.tblChamCongs.Where(a => a.MaNV == cc.MaNV && a.Ngay == cc.Ngay);
                            if (chamcongs.Count() > 0)
                            {
                                db.SaveChanges();
                            }
                            else {
                                db.tblChamCongs.Add(cc);
                                db.SaveChanges();
                            }
                            
                        }

                    }
                    



                    // Close the Excel reader and stream
                    reader.Close();
                    stream.Close();

                    // Return success message
                    ViewBag.Message = "Tải lên thành công";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    
                    // Return error message
                    ViewBag.Message = "Lỗi: " + ex.Message;
                    return View();
                }
            }
            else
            {
                // Return error message if file is not Excel file
                ViewBag.Message = "Hãy chọn tệp Excel";
                return View();
            }
        }
        // GET: ChamCong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChamCong tblChamCong = db.tblChamCongs.Find(id);
            if (tblChamCong == null)
            {
                return HttpNotFound();
            }
            return View(tblChamCong);
        }

        // GET: ChamCong/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChamCong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MaNV,TenNV,Ngay,ThoiGianVao,ThoiGianRa,TrangThai")] tblChamCong tblChamCong)
        {

            if (ModelState.IsValid)
            {

                db.tblChamCongs.Add(tblChamCong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblChamCong);
        }

        // GET: ChamCong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChamCong tblChamCong = db.tblChamCongs.Find(id);
            if (tblChamCong == null)
            {
                return HttpNotFound();
            }
            return View(tblChamCong);
        }

        // POST: ChamCong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MaNV,TenNV,Ngay,ThoiGianVao,ThoiGianRa,TrangThai")] tblChamCong tblChamCong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblChamCong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblChamCong);
        }

        // GET: ChamCong/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChamCong tblChamCong = db.tblChamCongs.Find(id);
            if (tblChamCong == null)
            {
                return HttpNotFound();
            }
            return View(tblChamCong);
        }

        // POST: ChamCong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblChamCong tblChamCong = db.tblChamCongs.Find(id);
            db.tblChamCongs.Remove(tblChamCong);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*[HttpPost]
        public ActionResult Upload(HttpPostedFileBase excelFile)
        {
            // Check if file is Excel file
            if (excelFile != null && excelFile.ContentLength > 0 &&
                (Path.GetExtension(excelFile.FileName) == ".xls" || Path.GetExtension(excelFile.FileName) == ".xlsx"))
            {
                try
                {
                    // Create a stream for the Excel file
                    Stream stream = excelFile.InputStream;
                    IExcelDataReader reader = null;

                    // Read the Excel file with either OpenXML or ClosedXML
                    if (Path.GetExtension(excelFile.FileName) == ".xls")
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (Path.GetExtension(excelFile.FileName) == ".xlsx")
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }

                    // Read the data from the Excel file
                    DataSet result = reader.AsDataSet();

                    // Loop through each sheet in the Excel file and read the data
                    foreach (DataTable table in result.Tables)
                    {
                        // Loop through each row in the sheet
                        for (int i = 1; i < table.Rows.Count; i++)
                        {
                            // Create a new TimeLog object and set its properties
                            tblChamCong cc = new tblChamCong();
                            cc.ID = (int)table.Rows[i][1];
                            cc.TenNV = table.Rows[i][2].ToString();
                            cc.TenNV = table.Rows[i][3].ToString();
                            cc.Ngay = DateTime.Parse(table.Rows[i][4].ToString());
                            cc.ThoiGianRa = TimeSpan.Parse(table.Rows[i][5].ToString());
                            cc.ThoiGianVao = TimeSpan.Parse(table.Rows[i][6].ToString());
                            cc.TrangThai = table.Rows[i][7].ToString();

                            // Save the TimeLog object to the database
                            db.tblChamCongs.Add(cc);
                            db.SaveChanges();
                        }
                    }

                    // Close the Excel reader and stream
                    reader.Close();
                    stream.Close();

                    // Return success message
                    ViewBag.Message = "Tải lên thành công";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Return error message
                    ViewBag.Message = "Lỗi: " + ex.Message;
                    return View();
                }
            }
            else
            {
                // Return error message if file is not Excel file
                ViewBag.Message = "Hãy chọn tệp Excel";
                return View();
            }
        }*/


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public TimeSpan ConvertStringToTimeSpan(string timeString)
        {
            DateTime baseTime = DateTime.ParseExact(timeString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dateTimeValue;
            if (DateTime.TryParseExact(timeString, "h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTimeValue))
            {
                return dateTimeValue - baseTime;
            }
            else
            {
                throw new ArgumentException("Invalid time string format", nameof(timeString));
            }
        }

    }
}
