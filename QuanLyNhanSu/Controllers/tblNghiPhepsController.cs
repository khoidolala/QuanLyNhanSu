﻿using System;
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
    public class tblNghiPhepsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: tblNghiPheps
        public ActionResult Index()
        {
            var tblNghiPhep = db.tblNghiPhep.Include(t => t.tblThongTinNV);
            return View(tblNghiPhep.ToList());
        }

        // GET: tblNghiPheps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNghiPhep tblNghiPhep = db.tblNghiPhep.Find(id);
            if (tblNghiPhep == null)
            {
                return HttpNotFound();
            }
            return View(tblNghiPhep);
        }

        // GET: tblNghiPheps/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = new SelectList(db.tblThongTinNVs, "MaNV", "TenNV");
            return View();
        }

        // POST: tblNghiPheps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNghiPhep,MaNV,NgayBatDau,NgayKetThuc")] tblNghiPhep tblNghiPhep)
        {
            if (ModelState.IsValid)
            {
                db.tblNghiPhep.Add(tblNghiPhep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNV = new SelectList(db.tblThongTinNVs, "MaNV", "TenNV", tblNghiPhep.MaNV);
            return View(tblNghiPhep);
        }

        // GET: tblNghiPheps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNghiPhep tblNghiPhep = db.tblNghiPhep.Find(id);
            if (tblNghiPhep == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNV = new SelectList(db.tblThongTinNVs, "MaNV", "TenNV", tblNghiPhep.MaNV);
            return View(tblNghiPhep);
        }

        // POST: tblNghiPheps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNghiPhep,MaNV,NgayBatDau,NgayKetThuc")] tblNghiPhep tblNghiPhep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblNghiPhep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNV = new SelectList(db.tblThongTinNVs, "MaNV", "TenNV", tblNghiPhep.MaNV);
            return View(tblNghiPhep);
        }

        // GET: tblNghiPheps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblNghiPhep tblNghiPhep = db.tblNghiPhep.Find(id);
            if (tblNghiPhep == null)
            {
                return HttpNotFound();
            }
            return View(tblNghiPhep);
        }

        // POST: tblNghiPheps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblNghiPhep tblNghiPhep = db.tblNghiPhep.Find(id);
            db.tblNghiPhep.Remove(tblNghiPhep);
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
