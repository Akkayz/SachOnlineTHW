using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        private dbSachOnlineDataContext db = new dbSachOnlineDataContext(ConfigurationManager.ConnectionStrings["SachOnlineConnectionString"].ConnectionString);

        public ActionResult Index()
        {
            var khachHangList = db.KHACHHANGs.ToList();
            return View(khachHangList);
        }

        // GET: Admin/KhachHang/Details/5
        public ActionResult Details(int id)
        {
            // Lấy thông tin "Khách hàng" dựa trên ID từ cơ sở dữ liệu
            KHACHHANG khachHang = db.KHACHHANGs.FirstOrDefault(c => c.MaKH == id);

            if (khachHang == null)
            {
                return HttpNotFound(); // Trả về HTTP 404 nếu không tìm thấy "Khách hàng"
            }

            return View(khachHang);
        }

        // GET: Admin/KhachHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/KhachHang/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KHACHHANG khachHang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Kiểm tra xem khách hàng đã tồn tại chưa
                    var existingCustomer = db.KHACHHANGs.FirstOrDefault(c => c.TaiKhoan == khachHang.TaiKhoan);

                    if (existingCustomer != null)
                    {
                        ModelState.AddModelError("TaiKhoan", "Tên tài khoản đã tồn tại.");
                        return View(khachHang);
                    }

                    db.KHACHHANGs.InsertOnSubmit(khachHang);
                    db.SubmitChanges();

                    return RedirectToAction("Index");
                }

                return View(khachHang);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/KhachHang/Edit/5
        public ActionResult Edit(int id)
        {
            // Lấy thông tin "Khách hàng" cần chỉnh sửa từ cơ sở dữ liệu
            KHACHHANG khachHang = db.KHACHHANGs.FirstOrDefault(c => c.MaKH == id);

            if (khachHang == null)
            {
                return HttpNotFound(); // Trả về HTTP 404 nếu không tìm thấy "Khách hàng"
            }

            return View(khachHang);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, KHACHHANG khachHang)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(khachHang.HoTen))
                {
                    ModelState.AddModelError("HoTen", "Họ tên không được để trống.");
                    return View(khachHang);
                }

                if (string.IsNullOrEmpty(khachHang.MatKhau))
                {
                    ModelState.AddModelError("MatKhau", "Mật khẩu không được để trống.");
                    return View(khachHang);
                }

                if (string.IsNullOrEmpty(khachHang.Email))
                {
                    ModelState.AddModelError("Email", "Email không được để trống.");
                    return View(khachHang);
                }

                if (string.IsNullOrEmpty(khachHang.DiaChi))
                {
                    ModelState.AddModelError("DiaChi", "Địa chỉ không được để trống.");
                    return View(khachHang);
                }

                if (string.IsNullOrEmpty(khachHang.DienThoai))
                {
                    ModelState.AddModelError("DienThoai", "Điện thoại không được để trống.");
                    return View(khachHang);
                }

                if (khachHang.NgaySinh == null)
                {
                    ModelState.AddModelError("NgaySinh", "Ngày sinh không được để trống.");
                    return View(khachHang);
                }

                // Kiểm tra xem tài khoản đã tồn tại chưa
                var existingAccount = db.KHACHHANGs.FirstOrDefault(c => c.TaiKhoan == khachHang.TaiKhoan && c.MaKH != khachHang.MaKH);

                if (existingAccount != null)
                {
                    ModelState.AddModelError("TaiKhoan", "Tên tài khoản đã tồn tại.");
                    return View(khachHang);
                }

                // Lấy "Khách hàng" cần chỉnh sửa từ cơ sở dữ liệu
                KHACHHANG existingCustomer = db.KHACHHANGs.FirstOrDefault(c => c.MaKH == id);

                if (existingCustomer == null)
                {
                    return HttpNotFound(); // Trả về HTTP 404 nếu không tìm thấy "Khách hàng"
                }

                // Cập nhật thông tin "Khách hàng" từ form
                existingCustomer.HoTen = khachHang.HoTen;
                existingCustomer.TaiKhoan = khachHang.TaiKhoan;
                existingCustomer.MatKhau = khachHang.MatKhau;
                existingCustomer.Email = khachHang.Email;
                existingCustomer.DiaChi = khachHang.DiaChi;
                existingCustomer.DienThoai = khachHang.DienThoai;
                existingCustomer.NgaySinh = khachHang.NgaySinh;

                db.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                return RedirectToAction("Index");
            }

            return View(khachHang);
        }

        // GET: Admin/KhachHang/Delete/5
        public ActionResult Delete(int id)
        {
            // Lấy thông tin "Khách hàng" cần xóa từ cơ sở dữ liệu
            KHACHHANG khachHang = db.KHACHHANGs.FirstOrDefault(c => c.MaKH == id);

            if (khachHang == null)
            {
                return HttpNotFound(); // Trả về HTTP 404 nếu không tìm thấy "Khách hàng"
            }

            return View(khachHang);
        }

        // POST: Admin/KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Lấy "Khách hàng" cần xóa từ cơ sở dữ liệu
            KHACHHANG khachHang = db.KHACHHANGs.FirstOrDefault(c => c.MaKH == id);

            if (khachHang == null)
            {
                return HttpNotFound(); // Trả về HTTP 404 nếu không tìm thấy "Khách hàng"
            }

            db.KHACHHANGs.DeleteOnSubmit(khachHang);
            db.SubmitChanges();

            return RedirectToAction("Index");
        }
    }
}