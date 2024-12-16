using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CLB_TinHoc_64131060.Models;

namespace CLB_TinHoc_64131060.Controllers
{
    public class BaiDang_Admin_64131060Controller : Controller
    {
        private CLBTinHoc_64131060Entities1 db = new CLBTinHoc_64131060Entities1();

        // GET: BaiDang_Admin_64131060
        public ActionResult BaiDang_Admin_64131060()
        {
            var baiDangs = db.BaiDangs.Include(b => b.ThanhVien);
            return View(baiDangs.ToList());
        }

        // GET: BaiDang_Admin_64131060/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiDang baiDang = db.BaiDangs.Find(id);
            if (baiDang == null)
            {
                return HttpNotFound();
            }
            return View(baiDang);
        }

        // GET: BaiDang_Assitant_64131060/Create
        public ActionResult Create()
        {
            ViewBag.TacGia = new SelectList(db.ThanhViens, "MaThanhVien", "HoTen");
            return View();
        }

        // POST: BaiDang_Assitant_64131060/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBaiDang,TieuDe,Anh,NoiDung,TacGia,NgayTao")] BaiDang baiDang, HttpPostedFileBase Anh)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem có file ảnh hay không
                if (Anh != null && Anh.ContentLength > 0)
                {
                    // Tạo thư mục Image nếu chưa tồn tại
                    string folderPath = Server.MapPath("/Image/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Lấy tên file ảnh
                    string postedFileName = Path.GetFileName(Anh.FileName);

                    // Tạo đường dẫn lưu file
                    string filePath = Path.Combine(folderPath, postedFileName);

                    // Lưu file ảnh vào thư mục
                    Anh.SaveAs(filePath);

                    // Lưu đường dẫn ảnh vào trong cơ sở dữ liệu
                    baiDang.Anh = postedFileName;
                }

                // Lưu bài đăng vào cơ sở dữ liệu
                db.BaiDangs.Add(baiDang);
                db.SaveChanges();

                // Chuyển hướng sau khi lưu thành công
                return RedirectToAction("BaiDang_Admin_64131060");
            }

            // Nếu không hợp lệ, giữ lại các giá trị trong ViewBag
            ViewBag.TacGia = new SelectList(db.ThanhViens, "MaThanhVien", "HoTen", baiDang.TacGia);
            return View(baiDang);
        }

        // GET: BaiDang_Admin_64131060/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiDang baiDang = db.BaiDangs.Find(id);
            if (baiDang == null)
            {
                return HttpNotFound();
            }
            ViewBag.TacGia = new SelectList(db.ThanhViens, "MaThanhVien", "HoTen", baiDang.TacGia);
            return View(baiDang);
        }

        // POST: BaiDang_Admin_64131060/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBaiDang,TieuDe,Anh,NoiDung,TacGia,NgayTao")] BaiDang baiDang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baiDang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BaiDang_Admin_64131060");
            }
            ViewBag.TacGia = new SelectList(db.ThanhViens, "MaThanhVien", "HoTen", baiDang.TacGia);
            return View(baiDang);
        }

        // GET: BaiDang_Admin_64131060/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiDang baiDang = db.BaiDangs.Find(id);
            if (baiDang == null)
            {
                return HttpNotFound();
            }
            return View(baiDang);
        }

        // POST: BaiDang_Admin_64131060/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BaiDang baiDang = db.BaiDangs.Find(id);
            db.BaiDangs.Remove(baiDang);
            db.SaveChanges();
            return RedirectToAction("BaiDang_Admin_64131060");
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
