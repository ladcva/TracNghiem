using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLTK;

namespace TracNghiemLTK.Areas.Contest.Controllers
{
    public class MonController : BaseContestController
    {
        // GET: Contest/Mon
        public ActionResult Index()
        {
			TracNghiemEntities tn = new TracNghiemEntities();
			var tan = tn.MonThis.ToList();
            return View(tan);
        }

        // GET: Contest/Mon/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contest/Mon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contest/Mon/Create
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

        // GET: Contest/Mon/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contest/Mon/Edit/5
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

        // GET: Contest/Mon/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contest/Mon/Delete/5
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
