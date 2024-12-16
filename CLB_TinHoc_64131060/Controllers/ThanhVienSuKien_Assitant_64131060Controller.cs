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
    public class ThanhVienSuKien_Assitant_64131060Controller : Controller
    {
        private CLBTinHoc_64131060Entities1 db = new CLBTinHoc_64131060Entities1();

        // GET: ThanhVienSuKien_Assitant_64131060
        public ActionResult ThanhVienSuKien_Assitant_64131060()
        {
            var thanhVienSuKiens = db.ThanhVienSuKiens.Include(t => t.SuKien).Include(t => t.ThanhVien);
            return View(thanhVienSuKiens.ToList());
        }


        // GET: ThanhVienSuKien_Assitant_64131060/Details
        public ActionResult Details(string MaSuKien, string MaThanhVien)
        {
            if (MaSuKien == null || MaThanhVien == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Tìm bản ghi sử dụng cả hai tham số khóa chính
            ThanhVienSuKien thanhVienSuKien = db.ThanhVienSuKiens
                                                 .FirstOrDefault(t => t.MaSuKien == MaSuKien && t.MaThanhVien == MaThanhVien);

            if (thanhVienSuKien == null)
            {
                return HttpNotFound();
            }

            return View(thanhVienSuKien);
        }


        // GET: ThanhVienSuKien_Assitant_64131060/Create
        public ActionResult Create()
        {
            ViewBag.MaSuKien = new SelectList(db.SuKiens, "MaSuKien", "TenSuKien");
            ViewBag.MaThanhVien = new SelectList(db.ThanhViens, "MaThanhVien", "HoTen");
            return View();
        }

        // POST: ThanhVienSuKien_Assitant_64131060/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSuKien,MaThanhVien,NgayDangKy")] ThanhVienSuKien thanhVienSuKien)
        {
            if (ModelState.IsValid)
            {
                db.ThanhVienSuKiens.Add(thanhVienSuKien);
                db.SaveChanges();
                return RedirectToAction("ThanhVienSuKien_Assitant_64131060");
            }

            ViewBag.MaSuKien = new SelectList(db.SuKiens, "MaSuKien", "TenSuKien", thanhVienSuKien.MaSuKien);
            ViewBag.MaThanhVien = new SelectList(db.ThanhViens, "MaThanhVien", "HoTen", thanhVienSuKien.MaThanhVien);
            return View(thanhVienSuKien);
        }

        // GET: ThanhVienSuKien_Assitant_64131060/Edit/5
        // GET: ThanhVienSuKien_Assitant_64131060/Edit
        public ActionResult Edit(string MaSuKien, string MaThanhVien)
        {
            if (MaSuKien == null || MaThanhVien == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ThanhVienSuKien thanhVienSuKien = db.ThanhVienSuKiens
                                                 .FirstOrDefault(t => t.MaSuKien == MaSuKien && t.MaThanhVien == MaThanhVien);

            if (thanhVienSuKien == null)
            {
                return HttpNotFound();
            }

            ViewBag.MaSuKien = new SelectList(db.SuKiens, "MaSuKien", "TenSuKien", thanhVienSuKien.MaSuKien);
            ViewBag.MaThanhVien = new SelectList(db.ThanhViens, "MaThanhVien", "HoTen", thanhVienSuKien.MaThanhVien);
            return View(thanhVienSuKien);
        }

        // POST: ThanhVienSuKien_Assitant_64131060/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSuKien,MaThanhVien,NgayDangKy")] ThanhVienSuKien thanhVienSuKien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thanhVienSuKien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ThanhVienSuKien_Assitant_64131060");
            }

            ViewBag.MaSuKien = new SelectList(db.SuKiens, "MaSuKien", "TenSuKien", thanhVienSuKien.MaSuKien);
            ViewBag.MaThanhVien = new SelectList(db.ThanhViens, "MaThanhVien", "HoTen", thanhVienSuKien.MaThanhVien);
            return View(thanhVienSuKien);
        }


        // GET: ThanhVienSuKien_Assitant_64131060/Delete/5
        public ActionResult Delete(string MaSuKien, string MaThanhVien)
        {
            if (MaSuKien == null || MaThanhVien == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Sử dụng cả hai tham số để tìm đối tượng
            ThanhVienSuKien thanhVienSuKien = db.ThanhVienSuKiens
                                                 .FirstOrDefault(t => t.MaSuKien == MaSuKien && t.MaThanhVien == MaThanhVien);

            if (thanhVienSuKien == null)
            {
                return HttpNotFound();
            }

            return View(thanhVienSuKien);
        }

        // POST: ThanhVienSuKien_Assitant_64131060/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string MaSuKien, string MaThanhVien)
        {
            // Sử dụng cả hai tham số để tìm đối tượng
            ThanhVienSuKien thanhVienSuKien = db.ThanhVienSuKiens
                                                 .FirstOrDefault(t => t.MaSuKien == MaSuKien && t.MaThanhVien == MaThanhVien);

            if (thanhVienSuKien == null)
            {
                return HttpNotFound();
            }

            db.ThanhVienSuKiens.Remove(thanhVienSuKien);
            db.SaveChanges();
            return RedirectToAction("ThanhVienSuKien_Assitant_64131060");
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
