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

    public partial class ThanhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThanhVien()
        {
            this.BaiDangs = new HashSet<BaiDang>();
            this.BaoCaos = new HashSet<BaoCao>();
            this.DiemDanhs = new HashSet<DiemDanh>();
            this.NhomHocTaps = new HashSet<NhomHocTap>();
            this.SuKiens = new HashSet<SuKien>();
            this.ThanhVienSuKiens = new HashSet<ThanhVienSuKien>();
            this.ThanhVienNhoms = new HashSet<ThanhVienNhom>();
        }

        [Required(ErrorMessage = "Bạn chưa nhập mã sinh viên")]    
        public string MaThanhVien { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập tên")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập mail trường")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bạn chưa tạo mật khẩu")]
        public string MatKhau { get; set; }
        public string MaVaiTro { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiDang> BaiDangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaoCao> BaoCaos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiemDanh> DiemDanhs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhomHocTap> NhomHocTaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuKien> SuKiens { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhVienSuKien> ThanhVienSuKiens { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhVienNhom> ThanhVienNhoms { get; set; }
        public virtual VaiTro VaiTro { get; set; }

    }
}
