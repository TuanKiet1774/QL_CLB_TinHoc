//------------------------------------------------------------------------------
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
    
    public partial class BaoCao
    {
        public int MaBaoCao { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string NopBoi { get; set; }
        public Nullable<System.DateTime> NgayNop { get; set; }
    
        public virtual ThanhVien ThanhVien { get; set; }
    }
}
