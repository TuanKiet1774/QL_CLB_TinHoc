﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CLB_TinHoc_64131060.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class BaiDang
    {
        [Required(ErrorMessage = "Bạn tạo mã bài đăng")]
        public string MaBaiDang { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập tiêu để")]
        public string TieuDe { get; set; }
        public string Anh { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập nội dung")]
        public string NoiDung { get; set; }
        [Required(ErrorMessage = "Bạn chưa để tên tác giả")]
        public string TacGia { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
    
        public virtual ThanhVien ThanhVien { get; set; }
    }
}
