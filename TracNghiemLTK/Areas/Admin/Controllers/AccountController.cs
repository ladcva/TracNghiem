using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLTK;

namespace TracNghiemLTK.Areas.Admin.Controllers
{
    public class AccountController : BaseController
	{
		TracNghiemEntities tn = new TracNghiemEntities();
		// GET: Admin/Account
		AccountData ac = new AccountData();
        public ActionResult Index()
        {
			var tan = new AccountData();
			var model = tan.ListTaiKhoan();
            return View(model);
        }

        // GET: Admin/Account/Details/5
        public ActionResult Details(int id)
        {
			var model = tn.TaiKhoans.Find(id);
            return View(model);
        }
		public void SetViewBagDD(int? selectedID = null)
		{
			var mt = new RoleData();
			ViewBag.MaQuyen = new SelectList(mt.ListRole(), "ID_Book", "Name", selectedID);
		}
		// GET: Admin/Account/Create
		public ActionResult Create()
        {
			SetViewBagDD();
            return View();
        }

        // POST: Admin/Account/Create
        [HttpPost]
        public ActionResult Create(TaiKhoan collection)
        {
            try
            {
				// TODO: Add insert logic here
				if (ModelState.IsValid)
				{
					ac.Insert(collection);
				    return RedirectToAction("Index", "Account");
				}
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Account/Edit/5
        public ActionResult Edit(int id)
        {

			var model = tn.TaiKhoans.Find(id);
			SetViewBagDD();
			return View(model);
        }

        // POST: Admin/Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TaiKhoan collection)
        {
            try
            {
				// TODO: Add update logic here
				var res = ac.Update(collection);
				if(res)
				{
					return RedirectToAction("Index", "Account");
				}
				else
				{
					ModelState.AddModelError("", "Fixed Failure ");
				}
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Account/Delete/5
        public ActionResult Delete(int id)
        {
			TracNghiemEntities tn = new TracNghiemEntities();
			var model = tn.TaiKhoans.Find(id);
			return View(model);
		}

        // POST: Admin/Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
				// TODO: Add delete logic here
				var res = ac.Delete(id);
				if (res)
				{
					return RedirectToAction("Index", "Account");
				}
				else
				{
					ModelState.AddModelError("", "Deleted Failure");
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
