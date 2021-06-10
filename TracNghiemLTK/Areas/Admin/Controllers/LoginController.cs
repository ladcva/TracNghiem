using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLTK;
using TracNghiemLTK.Areas.Admin.Models;
using TracNghiemLTK.Common;

namespace TracNghiemLTK.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Index(AdminLoginModel lg)
		{
			LoginData ld = new LoginData();
			var res = ld.CheckLoginAdmin(lg.Username, lg.Password);
			if (res == true)
			{
				var manager = ld.GetByUsername(lg.Username);
				var managerSession = new ManagerInfo();
				managerSession.Username = manager.Username;
				managerSession.id = manager.id;
				managerSession.Name = manager.HoTen;
				Session.Add(Common.CommonConstantsManager.MANAGER_SESSION, managerSession);
				return RedirectToAction("Index", "Home", new { area = "Admin" });
			}
			else
			{
				ModelState.AddModelError("", "Login failed, Please try again!");
			}
			return View(lg);
		}
        public ActionResult Logout()
		{
			Session[CommonConstantsManager.MANAGER_SESSION] = null;
			return Redirect("/Admin/Login");
		}
    }
}
