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
    
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.GioHangSanPhams = new HashSet<GioHangSanPham>();
        }
    
        public int ID { get; set; }
        public int idLoaiSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int idNhaSanXuat { get; set; }
        public string HinhAnh { get; set; }
        public Nullable<double> So_Luong { get; set; }
        public Nullable<double> GiaBan { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    
        public virtual LoaiSanPham LoaiSanPham { get; set; }
        public virtual NhaSanXuat NhaSanXuat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHangSanPham> GioHangSanPhams { get; set; }
    }
}