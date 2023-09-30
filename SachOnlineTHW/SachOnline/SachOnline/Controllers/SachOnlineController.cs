using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;
using System.Configuration;
namespace SachOnline.Controllers
{

    public class SachOnlineController : Controller
    {
        // GET: SachOnline
        public ActionResult Index()
        {
            var listSachMoi = LaySachMoi(6);
            return View(listSachMoi);
        }
        public ActionResult ChuDePartial()
        {
            return PartialView();
        }
        public ActionResult SachBanNhieuPartial()
        {
            return PartialView();
        }
        public ActionResult NhaXuatBanPartial()
        {
            return PartialView();
        }
        public ActionResult NavPartial()
        {
            return PartialView();
        }
        public ActionResult SliderPartial()
        {
            return PartialView();
        }
        public ActionResult FooterPartial()
        {
            return PartialView();
        }
        dbSachOnlineDataContext data = new dbSachOnlineDataContext("Data Source=WIN-19S1OU3P8T7;Initial Catalog=SachOnline;Integrated Security=True");

        /// <summary>
        /// LaySachMoi
        /// </summary>
        /// <param name="count">int</param>
        // <returns>List</returns>
        private List<SACH> LaySachMoi(int count)
        {
            return data.SACHes.OrderByDescending(a =>
            a.NgayCapNhat).Take(count).ToList();
        }
        // GET: SachOnline
        
    }
}