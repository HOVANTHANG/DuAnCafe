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
       
        public ActionResult Index(string filter)
        {
            if (Session["user"]!=null)
            {
                BanHang_testEntities1 db = new BanHang_testEntities1();
                if (filter != null)
                {
                    var danhsachMenu = db.Menus.Where(m => m.TenMenu.ToLower().Contains(filter.ToLower()) == true).ToList();   
                    ViewBag.filter = filter;
                    return View(danhsachMenu);
                }
                else
                {
                    var danhsachMenu = db.Menus.ToList();
                    ViewBag.filter = filter;
                    return View(danhsachMenu);
                }
            }
            else
            {
                return Redirect("~/Admin/HomeAdmin/DangNhap");
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
        public ActionResult ThemMoiMenu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoiMenu(Menu model)
        {
            BanHang_testEntities1 db = new BanHang_testEntities1();
            db.Menus.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult CapNhat(int idMenu)
        {
            BanHang_testEntities1 db = new BanHang_testEntities1();
            var menu = db.Menus.SingleOrDefault(m => m.ID == idMenu);
            return View(menu);
        }
        [HttpPost]
        public ActionResult CapNhat(Menu model)
        {
            BanHang_testEntities1 db = new BanHang_testEntities1();
            var menu1 = db.Menus.SingleOrDefault(m => m.ID == model.ID);
            menu1.idLoaiMenu = model.idLoaiMenu;
            menu1.TenMenu = model.TenMenu;
            menu1.HinhAnh = model.HinhAnh;
            menu1.GiaBan = model.GiaBan;
            menu1.TrangThai = model.TrangThai;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult XoaMenu(int idMenu)
        {
            BanHang_testEntities1 db = new BanHang_testEntities1();
            var model = db.Menus.SingleOrDefault(m => m.ID == idMenu);
            db.Menus.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}