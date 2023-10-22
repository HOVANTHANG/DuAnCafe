using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LapTrinhWeb.Models
{


    public class CartItems
    {
        public GioHang gioHang { get; set; }
        public int soluong { get; set; }

    }
    public class Cart
    {
        List<GioHang> items = new List<GioHang>();

        public IEnumerable<GioHang> Items
        {
            get { return items; }
        }
        public double Total()
        {
            var total = items.Sum(m => m.TongTien);
            return (double)total;
        }
    }
}