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
    public class ThanhVien_Member_64131060Controller : Controller
    {
        private CLBTinHoc_64131060Entities1 db = new CLBTinHoc_64131060Entities1();

        // GET: ThanhVien_Member_64131060
        public ActionResult Index()
        {
            var thanhViens = db.ThanhViens.Include(t => t.VaiTro);
            return View(thanhViens.ToList());
        }

        // GET: ThanhVien_Member_64131060/Details/5
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

        // GET: ThanhVien_Member_64131060/Create
        public ActionResult Create()
        {
            ViewBag.MaVaiTro = new SelectList(db.VaiTroes, "MaVaiTro", "TenVaiTro");
            return View();
        }

        // POST: ThanhVien_Member_64131060/Create
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
                return RedirectToAction("SigninAlert_64131060");
            }

            ViewBag.MaVaiTro = new SelectList(db.VaiTroes, "MaVaiTro", "TenVaiTro", thanhVien.MaVaiTro);
            return View(thanhVien);
        }

        public ActionResult SigninAlert_64131060()
        {
            return View();
        }

        // GET: ThanhVien_Member_64131060/Edit/5
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

        // POST: ThanhVien_Member_64131060/Edit/5
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
                return RedirectToAction("Index");
            }
            ViewBag.MaVaiTro = new SelectList(db.VaiTroes, "MaVaiTro", "TenVaiTro", thanhVien.MaVaiTro);
            return View(thanhVien);
        }

        // GET: ThanhVien_Member_64131060/Delete/5
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

        // POST: ThanhVien_Member_64131060/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ThanhVien thanhVien = db.ThanhViens.Find(id);
            db.ThanhViens.Remove(thanhVien);
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

        // GET: ThanhVien_Assitant_64131060/Edit/5
        public ActionResult Edit_Member_64131060(string id)
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

            // Gán giá trị mặc định cho MaVaiTro nếu chưa có
            if (string.IsNullOrEmpty(thanhVien.MaVaiTro))
            {
                thanhVien.MaVaiTro = "TV"; // Mặc định là "Thành viên bình thường"
            }

            return View(thanhVien);
        }

        // POST: ThanhVien_Assitant_64131060/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Member_64131060([Bind(Include = "MaThanhVien,HoTen,Email,MatKhau,MaVaiTro,NgayTao")] ThanhVien thanhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thanhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Member_Page_64131060");
            }
            ViewBag.MaVaiTro = new SelectList(db.VaiTroes, "MaVaiTro", "TenVaiTro", thanhVien.MaVaiTro);
            return View(thanhVien);
        }

        // GET: ThanhVien_Assitant_64131060/Assitant_Page_64131060
        public ActionResult Member_Page_64131060()
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
