using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LapTrinhWeb.Models;

namespace LapTrinhWeb.Areas.Admin.Controllers
{
    public class GioHangController : Controller
    {
        // GET: Admin/GioHang
        public ActionResult DanhSach()
        {
             BanHang_testEntities1 db = new BanHang_testEntities1();
           
            var tongtien = db.GioHangs.Sum(m => m.TongTien);
            ViewBag.tongtien = tongtien;
            return View(db.GioHangs.ToList());
        }
        [HttpPost]
        public ActionResult Them(int idmenu,int idNguoiDung, string TenMenu, float GiaBan,string KichThuoc,string Topping,int SoLuong)
        {
            BanHang_testEntities1 db = new BanHang_testEntities1();
           
            float tongtien = 0;
            if(KichThuoc=="Nho")
            {
                tongtien = SoLuong*GiaBan;
            }
            else if(KichThuoc=="Vua") {
                tongtien = SoLuong*(GiaBan + 5000);
            }
            else
            {
                tongtien = SoLuong*(GiaBan + 10000);
            }
            if(Topping== "Kem Phô Mai Macchiato")
            {
                tongtien += SoLuong*10000;
            }else if(Topping=="Trân châu trắng")
            {
                tongtien += SoLuong*10000;
            }else if(Topping == "Chocolate")
            {
                tongtien += SoLuong*10000;
            }
            GioHang gh = new GioHang()
            {
                idMenu = idmenu,     
                idNguoiDung= idNguoiDung,
                TenMenu = TenMenu,
                GiaBan = GiaBan,
                KichThuoc= KichThuoc,
                Topping= Topping,
                SoLuong= SoLuong,
                TongTien = tongtien
            };
            var giohang = db.GioHangs.SingleOrDefault(m => m.TenMenu==TenMenu&& m.KichThuoc== KichThuoc && m.Topping== Topping);
            if (giohang == null)
            {
                db.GioHangs.Add(gh);
            }
            else
            {
                giohang.SoLuong += SoLuong;
                giohang.TongTien =giohang.SoLuong * giohang.GiaBan;
            }
            db.SaveChanges();
            return  RedirectToAction("DanhSach");
        }
        public ActionResult CapNhat(int idGioHang)
        {
            return View();
        }
        [HttpPost]
        public ActionResult CapNhat(GioHang model)
        {
            BanHang_testEntities1 db = new BanHang_testEntities1();
            var giohang = db.GioHangs.SingleOrDefault(m => m.ID == model.ID);
            giohang.TenMenu = model.TenMenu;
            giohang.SoLuong = model.SoLuong;
            giohang.KichThuoc = model.KichThuoc;
            giohang.Topping = model.Topping;
            giohang.TongTien = model.TongTien;
            giohang.GiaBan = model.GiaBan;

            db.SaveChanges();
            return Redirect("~/Admin/GioHang/DanhSach");
        }
        public ActionResult Xoa(int idGioHang)
        {
            BanHang_testEntities1 db = new BanHang_testEntities1();
            var model = db.GioHangs.SingleOrDefault(m => m.ID == idGioHang);

            db.GioHangs.Remove(model);
            db.SaveChanges();
            return Redirect("~/Admin/GioHang/DanhSach");
        }
        public ActionResult XuLyThanhToan(int idNguoiDung)
        {
            BanHang_testEntities1 db = new BanHang_testEntities1();
            var xoaDulieu = db.GioHangs.Where(m => m.idNguoiDung == idNguoiDung).ToList();

            db.GioHangs.RemoveRange(xoaDulieu);
            db.SaveChanges();
            return Redirect("~/Admin/ThanhCong/thanhCong");
        }
        
    }
}