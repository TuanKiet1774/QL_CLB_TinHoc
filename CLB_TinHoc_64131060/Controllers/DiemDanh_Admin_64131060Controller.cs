using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CLB_TinHoc_64131060.Models;

namespace CLB_TinHoc_64131060.Controllers
{
    public class DiemDanh_Admin_64131060Controller : Controller
    {
        private CLBTinHoc_64131060Entities1 db = new CLBTinHoc_64131060Entities1();

        // GET: DiemDanh_Admin_64131060
        public ActionResult DiemDanh_Admin_64131060()
        {
            var diemDanhs = db.DiemDanhs.Include(d => d.NhomHocTap).Include(d => d.ThanhVien);
            return View(diemDanhs.ToList());
        }

        // GET: DiemDanh_Admin_64131060/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemDanh diemDanh = db.DiemDanhs.Find(id);
            if (diemDanh == null)
            {
                return HttpNotFound();
            }
            return View(diemDanh);
        }

        // GET: DiemDanh_Admin_64131060/Create
        public ActionResult Create()
        {
            ViewBag.MaNhom = new SelectList(db.NhomHocTaps, "MaNhom", "TenNhom");
            ViewBag.MaThanhVien = new SelectList(db.ThanhViens, "MaThanhVien", "HoTen");
            return View();
        }

        // POST: DiemDanh_Admin_64131060/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDiemDanh,MaNhom,MaThanhVien,NgayDiemDanh,TrangThai,GhiChu")] DiemDanh diemDanh)
        {
            if (ModelState.IsValid)
            {
                db.DiemDanhs.Add(diemDanh);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.MaNhom = new SelectList(db.NhomHocTaps, "MaNhom", "TenNhom", diemDanh.MaNhom);
            ViewBag.MaThanhVien = new SelectList(db.ThanhViens, "MaThanhVien", "HoTen", diemDanh.MaThanhVien);
            return View(diemDanh);
        }

        // GET: DiemDanh_Admin_64131060/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemDanh diemDanh = db.DiemDanhs.Find(id);
            if (diemDanh == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhom = new SelectList(db.NhomHocTaps, "MaNhom", "TenNhom", diemDanh.MaNhom);
            ViewBag.MaThanhVien = new SelectList(db.ThanhViens, "MaThanhVien", "HoTen", diemDanh.MaThanhVien);
            return View(diemDanh);
        }

        // POST: DiemDanh_Admin_64131060/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDiemDanh,MaNhom,MaThanhVien,NgayDiemDanh,TrangThai,GhiChu")] DiemDanh diemDanh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diemDanh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DiemDanh_Admin_64131060");
            }
            ViewBag.MaNhom = new SelectList(db.NhomHocTaps, "MaNhom", "TenNhom", diemDanh.MaNhom);
            ViewBag.MaThanhVien = new SelectList(db.ThanhViens, "MaThanhVien", "HoTen", diemDanh.MaThanhVien);
            return View(diemDanh);
        }

        // GET: DiemDanh_Admin_64131060/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemDanh diemDanh = db.DiemDanhs.Find(id);
            if (diemDanh == null)
            {
                return HttpNotFound();
            }
            return View(diemDanh);
        }

        // POST: DiemDanh_Admin_64131060/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiemDanh diemDanh = db.DiemDanhs.Find(id);
            db.DiemDanhs.Remove(diemDanh);
            db.SaveChanges();
            return RedirectToAction("DiemDanh_Admin_64131060");
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
