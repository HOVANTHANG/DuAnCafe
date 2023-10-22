using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LapTrinhWeb.Models;

namespace LapTrinhWeb.Areas.Admin.Controllers
{
    public class GioHangSPController : Controller
    {
        public ActionResult DanhSach()
        {
            BanHang_testEntities1 db = new BanHang_testEntities1();

            var tongtien = db.GioHangSanPhams.Sum(m => m.TongTien);
            ViewBag.tongtien = tongtien;
            return View(db.GioHangSanPhams.ToList());
        }
        [HttpPost]
        public ActionResult Them(int idSanPham, int idNguoiDung, string TenSanPham, float GiaBan,int SoLuong)
        {
            BanHang_testEntities1 db = new BanHang_testEntities1();

            float tongtien = 0;
            tongtien = SoLuong * GiaBan;

            GioHangSanPham gh = new GioHangSanPham()
            {
                idSanPham = idSanPham,
                idNguoiDung = idNguoiDung,
                TenSanPham = TenSanPham,
                GiaBan = GiaBan,
                SoLuong = SoLuong,
                TongTien = tongtien
            };
            var giohang = db.GioHangSanPhams.SingleOrDefault(m => m.idSanPham == idSanPham );
            if (giohang == null)
            {
                db.GioHangSanPhams.Add(gh);
            }
            else
            {
                giohang.SoLuong += SoLuong;
                giohang.TongTien = giohang.SoLuong * giohang.GiaBan;
            }
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }
        public ActionResult CapNhat(int idGioHang)
        {
            return View();
        }
        [HttpPost]
        public ActionResult CapNhat(GioHang model)
        {
          
            return Redirect("~/Admin/GioHang/DanhSach");
        }
        public ActionResult Xoa(int idGioHangsp)
        {
            BanHang_testEntities1 db = new BanHang_testEntities1();
            var model = db.GioHangSanPhams.SingleOrDefault(m => m.ID == idGioHangsp);

            db.GioHangSanPhams.Remove(model);
            db.SaveChanges();
            return Redirect("~/Admin/GioHangSP/DanhSach");
        }
        public ActionResult XuLyThanhToan(int idNguoiDung)
        {
            BanHang_testEntities1 db = new BanHang_testEntities1();
            var xoaDulieu = db.GioHangSanPhams.Where(m => m.idNguoiDung == idNguoiDung).ToList();

            db.GioHangSanPhams.RemoveRange(xoaDulieu);
            db.SaveChanges();
            return Redirect("~/Admin/ThanhCong/thanhCong");
        }
    }
}