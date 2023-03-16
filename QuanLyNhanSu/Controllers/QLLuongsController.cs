using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Controllers
{
    public class QLLuongsController : Controller
    {
        private DBContext db = new DBContext();
        

        // GET: QLLuongs
        public ActionResult Index()
        {
            var tblLuongs = db.tblLuongs.Include(t => t.tblPhuCap).Include(t => t.tblThongTinNV).Include(t => t.tblThuong);
            /*foreach (var item in tblLuongs)
            {
                tblHSL hsl = new tblHSL();
                tblPhuCap pc = new tblPhuCap();
                tblThuong th = new tblThuong();
                float tong = 0;
                tong = (float)(hsl.HSL * 1500000 - item.TienPhat + pc.TienPhuCap + th.TienThuong);
                *//*item.TongLuong = tong;*//*
            }*/
            return View(tblLuongs.ToList());
        }

        // GET: QLLuongs/Details/5
        public ActionResult Details(string id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLuong tblLuong = db.tblLuongs.Find(id);
            if (tblLuong == null)
            {
                return HttpNotFound();
            }
            return View(tblLuong);
        }

        // GET: QLLuongs/Create
        public ActionResult Create()
        {
            ViewBag.MaHSL = new SelectList(db.tblHSLs, "MaHSL", "HSL");
            ViewBag.MaPhuCap = new SelectList(db.tblPhuCaps, "MaPhuCap", "MaPhuCap");
            ViewBag.MaNV = new SelectList(db.tblThongTinNVs, "MaNV", "TenNV");
            ViewBag.MaThuong = new SelectList(db.tblThuongs, "MaThuong", "MaThuong");

            return View();
        }

        // POST: QLLuongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLuong,Thang,MaNV,SoNgayLamViec,SoGioLamViec,HSL,MaThuong,MaPhuCap,TienPhat,TamUng")] tblLuong tblLuong)
        {
            if (ModelState.IsValid)
            {
                db.tblLuongs.Add(tblLuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPhuCap = new SelectList(db.tblPhuCaps, "MaPhuCap", "TienPhuCap", tblLuong.MaPhuCap);
            ViewBag.MaNV = new SelectList(db.tblThongTinNVs, "MaNV", "TenNV", tblLuong.MaNV);
            ViewBag.MaThuong = new SelectList(db.tblThuongs, "MaThuong", "TienThuong", tblLuong.MaThuong);
            return View(tblLuong);
        }

        // GET: QLLuongs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLuong tblLuong = db.tblLuongs.Find(id);
            if (tblLuong == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPhuCap = new SelectList(db.tblPhuCaps, "MaPhuCap", "TienPhuCap", tblLuong.MaPhuCap);
            ViewBag.MaNV = new SelectList(db.tblThongTinNVs, "MaNV", "TenNV", tblLuong.MaNV);
            ViewBag.MaThuong = new SelectList(db.tblThuongs, "MaThuong", "LoaiThuong", tblLuong.MaThuong);
            return View(tblLuong);
        }

        // POST: QLLuongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLuong,Thang,MaNV,SoNgayLamViec,SoGioLamViec,HSL,MaThuong,MaPhuCap,TienPhat,TamUng")] tblLuong tblLuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblLuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPhuCap = new SelectList(db.tblPhuCaps, "MaPhuCap", "MaPhuCap", tblLuong.MaPhuCap);
            ViewBag.MaNV = new SelectList(db.tblThongTinNVs, "MaNV", "TenNV", tblLuong.MaNV);
            ViewBag.MaThuong = new SelectList(db.tblThuongs, "MaThuong", "MaThuong", tblLuong.MaThuong);
            return View(tblLuong);
        }

        // GET: QLLuongs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLuong tblLuong = db.tblLuongs.Find(id);
            if (tblLuong == null)
            {
                return HttpNotFound();
            }
            return View(tblLuong);
        }

        // POST: QLLuongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblLuong tblLuong = db.tblLuongs.Find(id);
            db.tblLuongs.Remove(tblLuong);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
