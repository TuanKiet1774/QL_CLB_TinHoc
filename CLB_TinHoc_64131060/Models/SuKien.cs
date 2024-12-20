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

    public partial class SuKien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SuKien()
        {
            this.ThanhVienSuKiens = new HashSet<ThanhVienSuKien>();
        }
    
        public string MaSuKien { get; set; }
        [Required(ErrorMessage ="Bạn chưa nhập tên sự kiện")]
        public string TenSuKien { get; set; }

        public string MoTa { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập thời gian bắt đầu sự kiện")]
        public System.DateTime NgayBatDau { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập thời gian kết thúc sự kiện")]
        public System.DateTime NgayKetThuc { get; set; }
        public string NguoiToChuc { get; set; }
    
        public virtual ThanhVien ThanhVien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhVienSuKien> ThanhVienSuKiens { get; set; }
    }
}
