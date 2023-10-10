using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SachOnline.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, KHACHHANG kh)
        {
            var sHoTen = collection["HoTen"];
            var sTenDN = collection["TenDN"];

            var sMatKhau = collection["MatKhau"];

            var sMatKhauNhapLai = collection["“MatKhauNL"];

            var sDiaChi = collection["DiaChi"];

            var sEmail = collection["Email"];

            var sDienThoai = collection["DienThoai"];


            var dNgaySinh = String.Format("{@:MM/dd/yyyy}", collection["NgaySinh"]);
            if (String.IsNullOrEmpty(sHoTen))
            {
                ViewData["err1"] = "Họ tên không được rỗng";
            }
            else if (String.IsNullOrEmpty(sTenDN))
            {
                ViewData["err2"] = "Tên đăng nhập không được rỗng";
            }
            else if (String.IsNullOrEmpty(sMatKhau))
            {
                ViewData["err3"] = "Tên đăng nhập không được rỗng";
            }
            else if (String.IsNullOrEmpty(sMatKhauNhapLai))
            {
                ViewData["err4"] = "Tên đăng nhập không được rỗng";
            }
            else if (String.IsNullOrEmpty(sMatKhauNhapLai))
            {
                ViewData["err4"] = "Tên đăng nhập không được rỗng";
            }
            else if (String.IsNullOrEmpty(sDiaChi))
            {
                ViewData["err5"] = "Tên đăng nhập không được rỗng";
            }
            else if (String.IsNullOrEmpty(sEmail))
            {
                ViewData["err6"] = "Tên đăng nhập không được rỗng";
            }
            else if (db.KHACHHANGs.SingleOrDefault(n => n.TaiKhoan(sTenDN) != null))
            {
                ViewBag.ThongBao = "Tên đăng nhập đã tồn tại";
            }
            else if (db.KHACHHANGs.SingleOrDefault(n => n.Email( sEmail) != null))
            {
                ViewBag.ThongBao = "Email đã được sử dung";
            }
            else
            {
                kh.HoTen = sHoTen;

                kh.TaiKhoan = sTenDN;
                kh.MatKhau = sMatKhau;

                kh.Email = sEmail;

                kh.DiaChi = sDiaChi;

                kh.DienThoai = sDienThoai;

                kh.NgaySinh = DateTime.Parse(dNgaySinh);
                db.KHACHHANGs.InsertOnSubmit(kh); 
                db.SubmitChanges();
                return RedirectToAction("DangNhap");
            }
            return this.DangKy();
        }
        }
}