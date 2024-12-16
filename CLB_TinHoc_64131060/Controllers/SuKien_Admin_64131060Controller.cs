using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CLB_TinHoc_64131060.Models;

namespace CLB_TinHoc_64131060.Controllers
{
    public class SuKien_Admin_64131060Controller : Controller
    {
        private CLBTinHoc_64131060Entities1 db = new CLBTinHoc_64131060Entities1();

        // GET: SuKien_Admin_64131060
        public ActionResult SuKien_Admin_64131060()
        {
            var suKiens = db.SuKiens.Include(s => s.ThanhVien);
            return View(suKiens.ToList());
        }

        public ActionResult TimKiemSuKien_Admin_64131060(string maSuKien = "", string tenSuKien = "")
        {
            ViewBag.maSuKien = maSuKien;
            ViewBag.tenSuKien = tenSuKien;

            var suKiens = db.SuKiens.SqlQuery(
                "EXEC SuKien_TimKiem @maSuKien, @tenSuKien",
                new SqlParameter("maSuKien", maSuKien),
                new SqlParameter("tenSuKien", tenSuKien)
            ).ToList();

            if (suKiens.Count == 0)
                ViewBag.TB = "Không tìm thấy sự kiện phù hợp.";

            return View(suKiens);
        }

        // GET: SuKien_Admin_64131060/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuKien suKien = db.SuKiens.Find(id);
            if (suKien == null)
            {
                return HttpNotFound();
            }
            return View(suKien);
        }

        // GET: SuKien_Admin_64131060/Create
        public ActionResult Create()
        {
            ViewBag.NguoiToChuc = new SelectList(db.ThanhViens, "MaThanhVien", "HoTen");
            return View();
        }

        // POST: SuKien_Admin_64131060/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSuKien,TenSuKien,MoTa,NgayBatDau,NgayKetThuc,NguoiToChuc")] SuKien suKien)
        {
            if (ModelState.IsValid)
            {
                db.SuKiens.Add(suKien);
                db.SaveChanges();
                return RedirectToAction("TimKiemSuKien_Admin_64131060");
            }

            ViewBag.NguoiToChuc = new SelectList(db.ThanhViens, "MaThanhVien", "HoTen", suKien.NguoiToChuc);
            return View(suKien);
        }

        // GET: SuKien_Admin_64131060/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuKien suKien = db.SuKiens.Find(id);
            if (suKien == null)
            {
                return HttpNotFound();
            }
            ViewBag.NguoiToChuc = new SelectList(db.ThanhViens, "MaThanhVien", "HoTen", suKien.NguoiToChuc);
            return View(suKien);
        }

        // POST: SuKien_Admin_64131060/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSuKien,TenSuKien,MoTa,NgayBatDau,NgayKetThuc,NguoiToChuc")] SuKien suKien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suKien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TimKiemSuKien_Admin_64131060");
            }
            ViewBag.NguoiToChuc = new SelectList(db.ThanhViens, "MaThanhVien", "HoTen", suKien.NguoiToChuc);
            return View(suKien);
        }

        // GET: SuKien_Admin_64131060/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuKien suKien = db.SuKiens.Find(id);
            if (suKien == null)
            {
                return HttpNotFound();
            }
            return View(suKien);
        }

        // POST: SuKien_Admin_64131060/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SuKien suKien = db.SuKiens.Find(id);
            db.SuKiens.Remove(suKien);
            db.SaveChanges();
            return RedirectToAction("TimKiemSuKien_Admin_64131060");
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
