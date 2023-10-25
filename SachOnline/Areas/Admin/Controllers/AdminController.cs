using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline.Areas.Admin.Controllers
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // Kiểm tra xem người dùng đã đăng nhập với tài khoản Admin hay chưa
            if (httpContext.Session["Admin"] != null)
            {
                return true; // Cho phép truy cập
            }
            return false; // Không cho phép truy cập
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // Nếu người dùng chưa đăng nhập, chuyển hướng họ đến trang đăng nhập Admin
            filterContext.Result = new RedirectResult("/Admin/Home/Login");
        }
    }
}