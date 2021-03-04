using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLTK;

namespace TracNghiemLTK.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
		DoashboardData db = new DoashboardData();
        // GET: Admin/Home
        public ActionResult Index()
        {
			ViewBag.SoHocSinh = db.SoHocSinh();
			ViewBag.SoLopHoc = db.SoLopHoc();
			ViewBag.SoDeThi = db.SoDeThi();
			ViewBag.SoMonThi = db.SoMonThi();
			ViewBag.SoCauHoi = db.SoCauHoi();
            ViewBag.SoHocSinhNam = db.SoHocSinhNam();
            ViewBag.ListDeThi = db.ListDeThi();
            ViewBag.DiemTrungBinh = db.DiemTrungBinh();
			return View();
        }

        // GET: Admin/Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
