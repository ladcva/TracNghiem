using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLTK;

namespace TracNghiemLTK.Areas.Contest.Controllers
{
    public class ContestResultController : BaseContestController
    {
		ContestData cd = new ContestData();
		TracNghiemEntities tn = new TracNghiemEntities();
        // GET: Contest/ContestResult
        public ActionResult Index(int maThiSinh, int maDe)
        {
			var tan = cd.ListKetQuaID(maThiSinh, maDe);
            return View(tan);
        }

        // GET: Contest/ContestResult/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contest/ContestResult/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contest/ContestResult/Create
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

        // GET: Contest/ContestResult/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contest/ContestResult/Edit/5
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

        // GET: Contest/ContestResult/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contest/ContestResult/Delete/5
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
