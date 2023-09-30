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
        string connectionStringName = "SachOnlineConnectionString";
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
        dbSachOnlineDataContext data = new dbSachOnlineDataContext(ConfigurationManager.ConnectionStrings["SachOnlineConnectionString"].ConnectionString);

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