using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class NhaXuatBanController : Controller
    {
        private dbSachOnlineDataContext db = new dbSachOnlineDataContext(ConfigurationManager.ConnectionStrings["SachOnlineConnectionString"].ConnectionString);

        // GET: Admin/NhaXuatBan
        public ActionResult Index()
        {
            var nhaxuatbanList = db.NHAXUATBANs.ToList();
            return View(nhaxuatbanList);
        }

        // GET: Admin/NhaXuatBan/Details/5
        public ActionResult Details(int id)
        {
            var nhaxuatban = db.NHAXUATBANs.FirstOrDefault(n => n.MaNXB == id);

            if (nhaxuatban == null)
            {
                return HttpNotFound();
            }

            return View(nhaxuatban);
        }

        // GET: Admin/NhaXuatBan/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NHAXUATBAN nhaxuatban)
        {
            if (ModelState.IsValid)
            {
                // Lưu dữ liệu vào cơ sở dữ liệu
                db.NHAXUATBANs.InsertOnSubmit(nhaxuatban);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }

            // Nếu dữ liệu không hợp lệ, trả về view với thông báo lỗi
            return View(nhaxuatban);
        }

        // GET: Admin/NhaXuatBan/Edit/5
        public ActionResult Edit(int id)
        {
            var nhaxuatban = db.NHAXUATBANs.FirstOrDefault(n => n.MaNXB == id);
            if (nhaxuatban == null)
            {
                return HttpNotFound();
            }
            return View(nhaxuatban);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NHAXUATBAN nhaxuatban)
        {
            if (ModelState.IsValid)
            {
                var existingNhaXuatBan = db.NHAXUATBANs.FirstOrDefault(n => n.MaNXB == id);
                if (existingNhaXuatBan == null)
                {
                    return HttpNotFound();
                }

                existingNhaXuatBan.TenNXB = nhaxuatban.TenNXB;
                existingNhaXuatBan.DiaChi = nhaxuatban.DiaChi;
                existingNhaXuatBan.DienThoai = nhaxuatban.DienThoai;

                db.SubmitChanges();
                return RedirectToAction("Index");
            }

            // Nếu dữ liệu không hợp lệ, trả về view với thông báo lỗi
            return View(nhaxuatban);
        }

        // GET: Admin/NhaXuatBan/Delete/5
        public ActionResult Delete(int id)
        {
            var nhaxuatban = db.NHAXUATBANs.FirstOrDefault(n => n.MaNXB == id);
            if (nhaxuatban == null)
            {
                return HttpNotFound();
            }

            return View(nhaxuatban);
        }

        // POST: Admin/NhaXuatBan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var nhaxuatban = db.NHAXUATBANs.FirstOrDefault(n => n.MaNXB == id);
            if (nhaxuatban == null)
            {
                return HttpNotFound();
            }

            db.NHAXUATBANs.DeleteOnSubmit(nhaxuatban);
            db.SubmitChanges();

            return RedirectToAction("Index");
        }
    }
}