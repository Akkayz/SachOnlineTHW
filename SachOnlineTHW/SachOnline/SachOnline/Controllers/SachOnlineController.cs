﻿using SachOnline.Models;
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
            var listSachBanNhieu= LaySachBanNhieu(6);
            return View(listSachBanNhieu);
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
        //Lấy sách mới nhất
        private List<SACH> LaySachMoi(int count)
        {
            return data.SACHes.OrderByDescending(a =>
            a.NgayCapNhat).Take(count).ToList();
        }

        //Lấy sách bán  nhiều nhất
        private List<SACH> LaySachBanNhieu(int count)
        {
            return data.SACHes.OrderByDescending(a =>
            a.SoLuongBan).Take(count).ToList();
        }

    }
}