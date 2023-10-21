using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
using System.Configuration;

namespace SachOnline.Areas.Admin.Controllers

{
    public class SachController : Controller

    {

        private dbSachOnlineDataContext db = new dbSachOnlineDataContext(ConfigurationManager.ConnectionStrings["SachOnlineConnectionString"].ConnectionString);

        // GET: Admin/Sach

        public ActionResult Index(int ? page)

        {
            int iPageNum = (page ?? 1);
            int iPageSize = 7;
            return View(db.SACHes.ToList().OrderBy(n => n.MaSach).ToPagedList(iPageNum,iPageSize));

        }

    }

}