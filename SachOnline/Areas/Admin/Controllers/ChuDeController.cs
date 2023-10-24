using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline.Areas.Admin.Controllers
{
    public class ChuDeController : Controller
    {
        private dbSachOnlineDataContext db = new dbSachOnlineDataContext(ConfigurationManager.ConnectionStrings["SachOnlineConnectionString"].ConnectionString);

        // GET: Admin/ChuDe
        public ActionResult Index()
        {
            var chudeList = db.CHUDEs.ToList();

            return View(chudeList);
        }

        // GET: Admin/ChuDe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/ChuDe/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CHUDE chude)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.CHUDEs.InsertOnSubmit(chude);
                    db.SubmitChanges();

                    return RedirectToAction("Index");
                }

                return View(chude);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ChuDe/Edit/5
        public ActionResult Edit(int id)
        {
            // Lấy thông tin "Chủ đề" cần chỉnh sửa từ cơ sở dữ liệu
            CHUDE chude = db.CHUDEs.FirstOrDefault(c => c.MaCD == id);

            if (chude == null)
            {
                return HttpNotFound(); // Trả về HTTP 404 nếu không tìm thấy "Chủ đề"
            }

            return View(chude);
        }

        // POST: Admin/ChuDe/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string NewTenChuDe)
        {
            try
            {
                // Lấy "Chủ đề" cần chỉnh sửa từ cơ sở dữ liệu
                CHUDE existingChuDe = db.CHUDEs.FirstOrDefault(c => c.MaCD == id);

                if (existingChuDe == null)
                {
                    return HttpNotFound(); // Trả về HTTP 404 nếu không tìm thấy "Chủ đề"
                }

                // Cập nhật thông tin "Chủ đề" từ trường NewTenChuDe
                existingChuDe.TenChuDe = NewTenChuDe;

                db.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ChuDe/Delete/5
        public ActionResult Delete(int id)
        {
            // Lấy thông tin "Chủ đề" cần xóa từ cơ sở dữ liệu
            CHUDE chude = db.CHUDEs.FirstOrDefault(c => c.MaCD == id);

            if (chude == null)
            {
                return HttpNotFound(); // Trả về HTTP 404 nếu không tìm thấy "Chủ đề"
            }

            return View(chude);
        }

        // POST: Admin/ChuDe/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // Lấy "Chủ đề" cần xóa từ cơ sở dữ liệu
                CHUDE existingChuDe = db.CHUDEs.FirstOrDefault(c => c.MaCD == id);

                if (existingChuDe == null)
                {
                    return HttpNotFound(); // Trả về HTTP 404 nếu không tìm thấy "Chủ đề"
                }

                // Xóa "Chủ đề" khỏi cơ sở dữ liệu
                db.CHUDEs.DeleteOnSubmit(existingChuDe);
                db.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}