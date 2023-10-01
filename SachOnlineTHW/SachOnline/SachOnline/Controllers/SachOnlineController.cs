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
            var listChuDe = from cd in data.CHUDEs select cd;
            return PartialView(listChuDe);
        }
        public ActionResult SachBanNhieuPartial()
        {
            return PartialView();
        }
        public ActionResult NhaXuatBanPartial()
        {
            var listNhaXuatBan = from xb in data.NHAXUATBANs select xb;
            return PartialView(listNhaXuatBan);
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
        dbSachOnlineDataContext data = new dbSachOnlineDataContext("Data Source=WIN-5GV9GD73UG8;Initial Catalog=SachOnline;Integrated Security=True");

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