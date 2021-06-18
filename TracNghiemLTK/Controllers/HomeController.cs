using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLTK;
using TracNghiemLTK.Models;
using TracNghiemLTK.Common;

namespace TracNghiemLTK.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";
			return View();
		}
		[HttpPost]
		public ActionResult Index(LoginModel lg)
		{
			//Login
			LoginData ld = new LoginData();
			var res = ld.CheckLogin(lg.Username, lg.Password);
			if(res == true)
			{
				var student = ld.GetByTen(lg.Username);
				var studentSession = new ThiSinhInfo();
				studentSession.MaThiSinh = student.MaThiSinh;
				studentSession.HoTen = student.HoTen;
				studentSession.Image = student.Image;
				studentSession.MaLop = student.MaLop;
				Session.Add(CommonConstantsStudent.STUDENT_SESSION, studentSession);
				return RedirectToAction("Index", "Default", new { area = "Contest" });
			}
			else
			{
				ModelState.AddModelError("", "Login failed, Please try again!");
			}
			return View(lg);
		}
		public ActionResult MaSinhVien()
		{
			//get StudentData
			ThiSinhData dt = new ThiSinhData();
			var model = dt.ListThiSinh();
			return View(model);
		}
	}
}
