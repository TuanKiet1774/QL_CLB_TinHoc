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
    public class NhomHocTap_Admin_64131060Controller : Controller
    {
        private CLBTinHoc_64131060Entities1 db = new CLBTinHoc_64131060Entities1();

        // GET: NhomHocTap_Admin_64131060
        public ActionResult NhomHocTap_Admin_64131060()
        {
            var nhomHocTaps = db.NhomHocTaps.Include(n => n.ThanhVien);
            return View(nhomHocTaps.ToList());
        }

        // GET: NhomHocTap_Admin_64131060/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomHocTap nhomHocTap = db.NhomHocTaps.Find(id);
            if (nhomHocTap == null)
            {
                return HttpNotFound();
            }
            return View(nhomHocTap);
        }

        // GET: NhomHocTap_Admin_64131060/Create
        public ActionResult Create()
        {
            ViewBag.TroGiang = new SelectList(db.ThanhViens, "MaThanhVien", "HoTen");
            return View();
        }

        // POST: NhomHocTap_Admin_64131060/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNhom,TenNhom,TroGiang,NgayTao,MoTa")] NhomHocTap nhomHocTap)
        {
            if (ModelState.IsValid)
            {
                db.NhomHocTaps.Add(nhomHocTap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TroGiang = new SelectList(db.ThanhViens, "MaThanhVien", "HoTen", nhomHocTap.TroGiang);
            return View(nhomHocTap);
        }

        // GET: NhomHocTap_Admin_64131060/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomHocTap nhomHocTap = db.NhomHocTaps.Find(id);
            if (nhomHocTap == null)
            {
                return HttpNotFound();
            }
            ViewBag.TroGiang = new SelectList(db.ThanhViens, "MaThanhVien", "HoTen", nhomHocTap.TroGiang);
            return View(nhomHocTap);
        }

        // POST: NhomHocTap_Admin_64131060/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNhom,TenNhom,TroGiang,NgayTao,MoTa")] NhomHocTap nhomHocTap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhomHocTap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TroGiang = new SelectList(db.ThanhViens, "MaThanhVien", "HoTen", nhomHocTap.TroGiang);
            return View(nhomHocTap);
        }

        // GET: NhomHocTap_Admin_64131060/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomHocTap nhomHocTap = db.NhomHocTaps.Find(id);
            if (nhomHocTap == null)
            {
                return HttpNotFound();
            }
            return View(nhomHocTap);
        }

        // POST: NhomHocTap_Admin_64131060/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhomHocTap nhomHocTap = db.NhomHocTaps.Find(id);
            db.NhomHocTaps.Remove(nhomHocTap);
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
