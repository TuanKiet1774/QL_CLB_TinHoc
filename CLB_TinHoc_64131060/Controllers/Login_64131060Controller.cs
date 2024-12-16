using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLB_TinHoc_64131060.Models; // Thay đổi namespace theo mô hình của bạn

namespace CLB_TinHoc_64131060.Controllers
{
    public class Login_64131060Controller : Controller
    {
        private CLBTinHoc_64131060Entities1 db = new CLBTinHoc_64131060Entities1(); // Khởi tạo DbContext của bạn

        // GET: Login_64131060
        public ActionResult Login_64131060()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login_64131060(string email, string matKhau)
        {
            var thanhVien = db.ThanhViens
                .FirstOrDefault(tv => tv.Email == email && tv.MatKhau == matKhau);

            if (thanhVien == null)
            {
                ViewBag.Error = "Email hoặc mật khẩu không đúng.";
                return View();
            }

            // Lưu email và vai trò vào Session
            Session["Email"] = thanhVien.Email;
            Session["MaVaiTro"] = thanhVien.MaVaiTro;

            // Điều hướng dựa trên MaVaiTro
            switch (thanhVien.MaVaiTro)
            {
                case "TVCN": // Quản trị viên
                    return RedirectToAction("AdminPage_64131060", "TrangChu_64131060");
                case "TVTG": // Trợ giảng
                    return RedirectToAction("AssistantPage_64131060", "TrangChu_64131060");
                case "TV": // Thành viên
                    return RedirectToAction("MemberPage_64131060", "TrangChu_64131060");
                default:
                    ViewBag.Error = "Vai trò không hợp lệ.";
                    return View();
            }
        }


    }
}
