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
    
    public partial class GioHang
    {
        public int ID { get; set; }
        public int idNguoiDung { get; set; }
        public int idMenu { get; set; }
        public string TenMenu { get; set; }
        public Nullable<double> SoLuong { get; set; }
        public Nullable<double> GiaBan { get; set; }
        public Nullable<double> TongTien { get; set; }
        public string KichThuoc { get; set; }
        public string Topping { get; set; }
    
        public virtual Menu Menu { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
    }
}