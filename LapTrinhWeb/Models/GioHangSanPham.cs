//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LapTrinhWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GioHangSanPham
    {
        public int ID { get; set; }
        public int idNguoiDung { get; set; }
        public int idSanPham { get; set; }
        public string TenSanPham { get; set; }
        public Nullable<double> SoLuong { get; set; }
        public Nullable<double> GiaBan { get; set; }
        public Nullable<double> TongTien { get; set; }
    
        public virtual NguoiDung NguoiDung { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}