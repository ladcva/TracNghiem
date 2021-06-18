using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLTK;

namespace TracNghiemLTK.Areas.Admin.Controllers
{
    public class MonThiController : BaseController
    {
		MonThiData mt = new MonThiData();
		TracNghiemEntities tn = new TracNghiemEntities();
        // GET: Admin/MonThi
        public ActionResult Index()
        {
			var model = mt.ListMonThi();
            return View(model);
        }

        // GET: Admin/MonThi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/MonThi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MonThi/Create
        [HttpPost]
        public ActionResult Create(MonThi collection)
        {
            try
            {
				// TODO: Add insert logic here
				if (ModelState.IsValid)
				{
					int id = mt.Insert(collection);
					if (id > 0)
					{
						return RedirectToAction("Index", "MonThi");
					}
					else
					{
						ModelState.AddModelError("", "Add failed");
					}
				}
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/MonThi/Edit/5
        public ActionResult Edit(int id)
        {
			var model = tn.MonThis.Find(id);
            return View(model);
        }

        // POST: Admin/MonThi/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MonThi collection)
        {
            try
            {
				// TODO: Add update logic here
				if (ModelState.IsValid)
				{
					var res = mt.Update(collection);
					if (res)
					{
						return RedirectToAction("Index", "MonThi");
					}
					else
					{
						ModelState.AddModelError("", "Edit failed");
					}
				}
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/MonThi/Delete/5
        public ActionResult Delete(int id)
        {
			var model = tn.MonThis.Find(id);
            return View(model);
        }

        // POST: Admin/MonThi/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
				// TODO: Add delete logic here
				if (ModelState.IsValid)
				{
					var res = mt.Delete(id);
					if (res)
					{
						return RedirectToAction("Index", "MonThi");
					}
					else
					{
						ModelState.AddModelError("", "Delete failed
				}
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
