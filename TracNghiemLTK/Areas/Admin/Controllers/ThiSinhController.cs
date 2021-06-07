using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLTK;
using System.IO;

namespace TracNghiemLTK.Areas.Admin.Controllers
{
    public class ThiSinhController : BaseController
    {
		TracNghiemEntities tn = new TracNghiemEntities();
        // GET: Admin/ThiSinh
        public ActionResult Index()
        {
			ThiSinhData ts = new ThiSinhData();
			var model = ts.ListThiSinh();
            return View(model);
        }

        // GET: Admin/ThiSinh/Details/5
        public ActionResult Details(int id)
        {
			var model = tn.ThiSinhs.Find(id);
            return View(model);
        }

		public void SetViewBagDD(int? selectedID = null)
		{
			var mt = new LopData();
			ViewBag.MaLop = new SelectList(mt.ListLop(), "MaLop", "TenLop", selectedID);
		}

        // GET: Admin/ThiSinh/Create
        public ActionResult Create()
        {
			SetViewBagDD();
            return View();
        }

        // POST: Admin/ThiSinh/Create
        [HttpPost]
        public ActionResult Create(ThiSinh collection)
        {
            try
            {
				// TODO: Add insert logic here
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
					}
					collection.Image = imageData;
					var ts = new ThiSinhData();
					int id = ts.Insert(collection);
					if(id>0)
					{
						return RedirectToAction("Index", "ThiSinh");
					}
					else
					{
						ModelState.AddModelError("", "Thêm thất bại");
					}
			    }
				return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ThiSinh/Edit/5
        public ActionResult Edit(int id)
        {
			TracNghiemEntities tn = new TracNghiemEntities();
			var model = tn.ThiSinhs.Find(id);
			SetViewBagDD();
			return View(model);
        }

        // POST: Admin/ThiSinh/Edit/5
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
							return RedirectToAction("Index", "ThiSinh");
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
							return RedirectToAction("Index", "ThiSinh");
						}
						else
						{
							ModelState.AddModelError("", "Sửa thất bại");
						}
					}
					
				}
				return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ThiSinh/Delete/5
        public ActionResult Delete(int id)
        {
			TracNghiemEntities tn = new TracNghiemEntities();
			var model = tn.ThiSinhs.Find(id);
			return View(model);
        }

        // POST: Admin/ThiSinh/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id, ThiSinh collection)
        {
            try
            {
				// TODO: Add delete logic here
				if (ModelState.IsValid)
				{
					var ts = new ThiSinhData();
					var res = ts.Delete(id);
					if (res)
					{
						return RedirectToAction("Index", "ThiSinh");
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
