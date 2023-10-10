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
        dbSachOnlineDataContext data = new dbSachOnlineDataContext("Data Source=MSI\\SQLEXPRESS;Initial Catalog=SachOnline;Integrated Security=True");

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
            dbSachOnlineDataContext data = new dbSachOnlineDataContext("Data Source=MSI\\SQLEXPRESS;Initial Catalog=SachOnline;Integrated Security=True");
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
            else if (db.KHACHHANGs.SingleOrDefault(n => n.TaiKhoan == sTenDN != null))
            {
                ViewBag.ThongBao = "Tên đăng nhập đã tồn tại";
            }
            else if (db.KHACHHANGs.SingleOrDefault(n => n.Email == sEmail != null))
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

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var sTenDN = collection["TenDN"];
            var sMatKhau = collection["Matkhau"];
            if (String.IsNullOrEmpty(sTenDN))
            {
                ViewData["Err1"] = "Bạn chưa nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(sMatKhau))
            {
                ViewData["Err2"] = "Phải nhập mật khẩu";
            }
            else
            {

                KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.TaiKhoan == sTenDN && n.MatKhau == sMatKhau);
                if (kh != null)
                {
                    ViewBag.ThongBao = "Chúc mừng đăng nhập thành công";
                    Session["TaiKhoan"] = kh;
                }
                else
                {
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }

            }
            return View("");

        }
    }
    D:\SachOnlineTHW\SachOnlineTHW\SachOnline\SachOnline\Views\User\DangNhap.cshtml

}
}