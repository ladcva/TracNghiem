using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLTK;

namespace TracNghiemLTK.Areas.Contest.Controllers
{
    public class KetQuaController : BaseContestController
    {
        // GET: Contest/KetQua
        public ActionResult Index(int id)
        {
			TracNghiemEntities tn = new TracNghiemEntities();
			var tan = tn.KetQuas.Where(x=>x.MaThiSinh == id).ToList();
            return View(tan);
        }

        // GET: Contest/KetQua/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contest/KetQua/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contest/KetQua/Create
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

        // GET: Contest/KetQua/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contest/KetQua/Edit/5
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

        // GET: Contest/KetQua/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contest/KetQua/Delete/5
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
