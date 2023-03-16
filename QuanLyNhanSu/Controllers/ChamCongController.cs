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
    public class ChamCongController : Controller
    {
        private DBContext db = new DBContext();

        // GET: ChamCong
        public ActionResult Index()
        {
            return View(db.tblChamCongs.ToList());
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
