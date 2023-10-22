using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LapTrinhWeb.Models;

namespace LapTrinhWeb.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
       
        public ActionResult Index()
        {
            if (Session["user"]!=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("DangNhap");
            }
            
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string Username, string password)

        {
            BanHang_testEntities1 db = new BanHang_testEntities1();

            var nhanvien = db.NhanViens.SingleOrDefault(m => m.Username.ToLower() == Username && m.Password == password);
            var nguoidung = db.NguoiDungs.SingleOrDefault(m => m.Username.ToLower() == Username && m.Password == password);

            if (nhanvien!= null|| nguoidung!=null)
            {
                if (nhanvien != null)
                {
                    Session["user"] = nhanvien;
                   
                    return RedirectToAction("Index");
                }
                else
                {
                    Session["user"] = nguoidung;
                    ViewBag.idNguoiDung = nguoidung.ID;
                    return Redirect("~/Admin/GiaoDien/TrangChu");
                }
                
            }else
            {
                TempData["error"] = "Tài khoản hoặc mật khẩu của bạn không chính xác";
                return View();
            }

            
        }
        public ActionResult DangXuat()
        {
            Session.Remove("user");
            FormsAuthentication.SignOut();
            return RedirectToAction("DangNhap");
        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(NguoiDung user)
        {
            BanHang_testEntities1 db = new BanHang_testEntities1();
            db.NguoiDungs.Add(user);
            db.SaveChanges();
            return Redirect("~/Admin/ThanhCong/Index");
        }
    }
}