using DataLTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TracNghiemLTK.Areas.Contest.Controllers
{
    public class ProfileController : BaseContestController
    {

		TracNghiemEntities tn = new TracNghiemEntities();
		// GET: Contest/Profile
		public ActionResult Index()
        {
            return View();
        }

        // GET: Contest/Profile/Details/5
        public ActionResult Details(int id)
        {
			ThiSinhData dt = new ThiSinhData();
			var tan = dt.ListThiSinhID(id);
			ViewBag.ListKQ = tn.KetQuas.Where(x => x.MaThiSinh == id).ToList();
			return View(tan);
        }

        // GET: Contest/Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contest/Profile/Create
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

        // GET: Contest/Profile/Edit/5
        public ActionResult Edit(int id)
        {
			var model = tn.ThiSinhs.Find(id);
			ViewBag.MaLop = new SelectList(tn.Lops, "MaLop", "TenLop",id);
			return View(model);
        }

        // POST: Contest/Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ThiSinh collection)
        {
            try
            {
				// TODO: Add update logic here
				if (ModelState.IsValid)
				{
					byte[] imageData = null;
					HttpPostedFileBase poImgFile = Request.Files["fileim"];
					if (poImgFile != null && poImgFile.ContentLength > 0)
					{
						using (var binary = new BinaryReader(poImgFile.InputStream))
						{
							imageData = binary.ReadBytes(poImgFile.ContentLength);
						}
						collection.Image = imageData;
						var ts = new ThiSinhData();
						var res = ts.Update(collection);
						if (res)
						{
							return RedirectToAction("Index", "Profile");
						}
						else
						{
							ModelState.AddModelError("", "Sửa thất bại");
						}
					}
					else
					{
						byte[] tana = tn.ThiSinhs.Where(x => x.MaThiSinh == id).Select(u => u.Image).SingleOrDefault();
						collection.Image = tana;
						var ts = new ThiSinhData();
						var res = ts.Update(collection);
						if (res)
						{
							return RedirectToAction("Index", "Profile");
						}
						else
						{
							ModelState.AddModelError("", "Sửa thất bại");
						}
					}

				}
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contest/Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contest/Profile/Delete/5
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
