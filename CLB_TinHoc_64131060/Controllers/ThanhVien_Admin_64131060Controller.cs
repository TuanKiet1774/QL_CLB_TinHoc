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
    public class ThanhVien_Admin_64131060Controller : Controller
    {
        private CLBTinHoc_64131060Entities1 db = new CLBTinHoc_64131060Entities1();

        // GET: ThanhVien_Admin_64131060
        public ActionResult ThanhVien_Admin_64131060()
        {
            var thanhViens = db.ThanhViens.Include(t => t.VaiTro);
            return View(thanhViens.ToList());
        }

        public ActionResult TimKiemTV_Admin_64131060(string mathanhvien = "", string hoten = "")
        {
            ViewBag.mathanhvien = mathanhvien;
            ViewBag.hoten = hoten;

            var thanhviens = db.ThanhViens.SqlQuery(
                "EXEC ThanhVien_TimKiem @hoten, @mathanhvien",
                new SqlParameter("hoten", hoten),
                new SqlParameter("mathanhvien", mathanhvien)
            ).ToList();

            if (thanhviens.Count == 0)
                ViewBag.TB = "Không tìm thấy sinh viên này.";

            return View(thanhviens);
        }
        // GET: ThanhVien_Admin_64131060/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhVien thanhVien = db.ThanhViens.Find(id);
            if (thanhVien == null)
            {
                return HttpNotFound();
            }
            return View(thanhVien);
        }

        // GET: ThanhVien_Admin_64131060/Create
        public ActionResult Create()
        {
            ViewBag.MaVaiTro = new SelectList(db.VaiTroes, "MaVaiTro", "TenVaiTro");
            return View();
        }

        // POST: ThanhVien_Admin_64131060/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaThanhVien,HoTen,Email,MatKhau,MaVaiTro,NgayTao")] ThanhVien thanhVien)
        {
            if (ModelState.IsValid)
            {
                db.ThanhViens.Add(thanhVien);
                db.SaveChanges();
                return RedirectToAction("TimKiemTV_Admin_64131060");
            }

            ViewBag.MaVaiTro = new SelectList(db.VaiTroes, "MaVaiTro", "TenVaiTro", thanhVien.MaVaiTro);
            return View(thanhVien);
        }

        // GET: ThanhVien_Admin_64131060/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhVien thanhVien = db.ThanhViens.Find(id);
            if (thanhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaVaiTro = new SelectList(db.VaiTroes, "MaVaiTro", "TenVaiTro", thanhVien.MaVaiTro);
            return View(thanhVien);
        }

        // POST: ThanhVien_Admin_64131060/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaThanhVien,HoTen,Email,MatKhau,MaVaiTro,NgayTao")] ThanhVien thanhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thanhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TimKiemTV_Admin_64131060");
            }
            ViewBag.MaVaiTro = new SelectList(db.VaiTroes, "MaVaiTro", "TenVaiTro", thanhVien.MaVaiTro);
            return View(thanhVien);
        }

        // GET: ThanhVien_Assitant_64131060/Edit/5
        public ActionResult Edit_Admin_64131060(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhVien thanhVien = db.ThanhViens.Find(id);
            if (thanhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaVaiTro = new SelectList(db.VaiTroes, "MaVaiTro", "TenVaiTro", thanhVien.MaVaiTro);
            return View(thanhVien);
        }

        // POST: ThanhVien_Assitant_64131060/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Admin_64131060([Bind(Include = "MaThanhVien,HoTen,Email,MatKhau,MaVaiTro,NgayTao")] ThanhVien thanhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thanhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Admin_Page_64131060");
            }
            ViewBag.MaVaiTro = new SelectList(db.VaiTroes, "MaVaiTro", "TenVaiTro", thanhVien.MaVaiTro);
            return View(thanhVien);
        }

        // GET: ThanhVien_Admin_64131060/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhVien thanhVien = db.ThanhViens.Find(id);
            if (thanhVien == null)
            {
                return HttpNotFound();
            }
            return View(thanhVien);
        }

        // POST: ThanhVien_Admin_64131060/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ThanhVien thanhVien = db.ThanhViens.Find(id);
            db.ThanhViens.Remove(thanhVien);
            db.SaveChanges();
            return RedirectToAction("TimKiemTV_Admin_64131060");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Admin_Page_64131060()
        {
            // Lấy email của người dùng từ Session hoặc các phương pháp lưu trữ đăng nhập
            string email = Session["Email"]?.ToString();

            // Lấy thông tin thành viên từ bảng ThanhVien
            var thanhVien = db.ThanhViens.FirstOrDefault(tv => tv.Email == email);

            if (thanhVien == null)
            {
                ViewBag.Error = "Không tìm thấy thông tin người dùng.";
                return RedirectToAction("Login_64131060", "Login_64131060");
            }

            // Truyền thông tin thành viên vào View
            return View(thanhVien);
        }
    }
}
