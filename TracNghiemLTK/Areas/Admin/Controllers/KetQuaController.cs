using DataLTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TracNghiemLTK.Areas.Admin.Controllers
{
    public class KetQuaController : BaseController
    {
        // GET: Admin/KetQua
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
			KetQuaData qk = new KetQuaData();
			var model = qk.ListKetQua(page, pageSize);
			return View(model);
		}

        // GET: Admin/KetQua/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/KetQua/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/KetQua/Create
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

        // GET: Admin/KetQua/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/KetQua/Edit/5
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

        // GET: Admin/KetQua/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/KetQua/Delete/5
        // [HttpDelete]
        /*public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
				// TODO: Add delete logic here
				KetQuaData kq = new KetQuaData();
				kq.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/
    }
}
