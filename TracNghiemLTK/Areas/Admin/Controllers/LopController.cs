using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLTK;

namespace TracNghiemLTK.Areas.Admin.Controllers
{
    public class LopController : BaseController
    {
		LopData tan = new LopData();
		TracNghiemEntities tn = new TracNghiemEntities();
        // GET: Admin/Lop
        public ActionResult Index()
        {
			LopData ld = new LopData();
			var model = ld.ListLop();
            return View(model);
        }

        // GET: Admin/Lop/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Lop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Lop/Create
        [HttpPost]
        public ActionResult Create(Lop collection)
        {
            try
            {
				// TODO: Add insert logic here
				if (ModelState.IsValid)
				{
					int id = tan.Insert(collection);
					if (id > 0)
					{
						return RedirectToAction("Index", "Lop");
					}
					else
					{
						ModelState.AddModelError("", "Thêm thất bại");
					}
				}
				return RedirectToAction("Index");
			}
            catch
            {
                return View();
            }
        }

        // GET: Admin/Lop/Edit/5
        public ActionResult Edit(int id)
        {
			var model = tn.Lops.Find(id);
            return View(model);
        }

        // POST: Admin/Lop/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Lop collection)
        {
            try
            {
				// TODO: Add update logic here
				if (ModelState.IsValid)
				{
					var res = tan.Update(collection);
					if (res)
					{
						return RedirectToAction("Index", "Lop");
					}
					else
					{
						ModelState.AddModelError("", "Sửa thất bại");
					}
				}
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Lop/Delete/5
        public ActionResult Delete(int id)
        {
			var model = tn.Lops.Find(id);
			return View(model);
		}

        // POST: Admin/Lop/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id, Lop collection)
        {
            try
            {
				// TODO: Add delete logic here
				if (ModelState.IsValid)
				{
					var res = tan.Delete(id);
					if (res)
					{
						return RedirectToAction("Index", "Lop");
					}
					else
					{
						ModelState.AddModelError("", "Delete thất bại");
					}
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
