using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LapTrinhWeb.Models;

namespace LapTrinhWeb.Areas.Admin.Controllers
{
    public class GiaoDienController : Controller
    {
        // GET: Admin/GiaoDien
        public ActionResult TrangChu()
        {
            return View();
        }
        public ActionResult GioiThieu()
        {
            return View();
        }
        
        public ActionResult Menu()
        {

            BanHang_testEntities1 db = new BanHang_testEntities1();
                List<Menu> DanhSachMenu = db.Menus.Where(m => m.TrangThai == false).ToList();
                return View(DanhSachMenu);
           
        }
     


        public ActionResult Menu1(int idMenu)
        {
            if (Session["user"] != null)
            {
                BanHang_testEntities1 db = new BanHang_testEntities1();
                var meNu = db.Menus.SingleOrDefault(m => m.ID == idMenu);
                return View(meNu);
            }else
            {

                return Redirect("~/Admin/HomeAdmin/DangNhap");
            }
        }
      


        public ActionResult SanPham()
        {
            BanHang_testEntities1 db = new BanHang_testEntities1();
            List<SanPham> DanhsachSanPham = db.SanPhams.Where(m => m.TrangThai == false).ToList();
            return View(DanhsachSanPham);
        }
        public ActionResult SanPhamCon1(int idSanPham)
        {
            if (Session["user"] != null)
            {
                BanHang_testEntities1 db = new BanHang_testEntities1();
                var sanpham = db.SanPhams.SingleOrDefault(m => m.ID == idSanPham);

                return View(sanpham);
            }
            else
            {

                return Redirect("~/Admin/HomeAdmin/DangNhap");
            }
        }
       


        public ActionResult Blogs()
        {
            return View();
        }
        public ActionResult GioHang()
        {
            return View();
        }

    }
}