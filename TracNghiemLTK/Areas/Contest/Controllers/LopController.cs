using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLTK;

namespace TracNghiemLTK.Areas.Contest.Controllers
{
    public class LopController : BaseContestController
	{
        // GET: Contest/Lop
        public ActionResult Index(int id)
        {
			TracNghiemEntities tn = new TracNghiemEntities();
			var tan = tn.ThiSinhs.Where(x => x.MaLop == id).ToList();
            return View(tan);
        }

        // GET: Contest/Lop/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contest/Lop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contest/Lop/Create
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

        // GET: Contest/Lop/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contest/Lop/Edit/5
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

        // GET: Contest/Lop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contest/Lop/Delete/5
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
