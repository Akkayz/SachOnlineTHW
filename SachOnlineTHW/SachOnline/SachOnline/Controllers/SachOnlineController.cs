using PagedList;
using SachOnline.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace SachOnline.Controllers
{
    public class SachOnlineController : Controller
    {
        private dbSachOnlineDataContext data = new dbSachOnlineDataContext(ConfigurationManager.ConnectionStrings["SachOnlineConnectionString"].ConnectionString);

        // GET: SachOnline
        public ActionResult Index(int? page)
        {
            int iSize = 6;
            int iPageNum = (page ?? 1);
            var listSachMoi = data.SACHes.OrderByDescending(a => a.NgayCapNhat).ToPagedList(iPageNum, iSize);
            return View(listSachMoi);
        }

        public ActionResult ChuDePartial()
        {
            var listChuDe = from cd in data.CHUDEs select cd;
            return PartialView(listChuDe);
        }

        public ActionResult SachBanNhieuPartial()
        {
            var listSachBanNhieu = LaySachBanNhieu(6);
            return PartialView(listSachBanNhieu);
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

        public ActionResult SachTheoNhaXuatBan(int? iMaNXB, int? page)
        {
            ViewBag.MaNXB = iMaNXB;
            int iSize = 3;
            int iPageNum = (page ?? 1);
            var sach = from s in data.SACHes where s.MaNXB == iMaNXB.Value select s;
            return View(sach.ToPagedList(iPageNum, iSize));
        }

        public ActionResult SachTheoChuDe(int? iMaCD, int? page)
        {
            ViewBag.MaCD = iMaCD.Value;
            int iSize = 3;
            int iPageNum = (page ?? 1);
            var sach = from s in data.SACHes where s.MaCD == iMaCD.Value select s;
            return View(sach.ToPagedList(iPageNum, iSize));
        }

        public ActionResult ChiTietSach(int id)
        {
            var sach = from s in data.SACHes
                       where s.MaSach == id
                       select s;
            return View(sach.Single());
        }

        public ActionResult LoginLogout()
        {
            return PartialView("LoginLogoutPartial");
        }

        private List<SACH> LaySachBanNhieu(int count)
        {
            return data.SACHes.OrderByDescending(a =>
            a.SoLuongBan).Take(count).ToList();
        }
    }
}