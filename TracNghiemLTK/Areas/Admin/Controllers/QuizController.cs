using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLTK;
using System.IO;

namespace TracNghiemLTK.Areas.Admin.Controllers
{
    public class QuizController : BaseController
    {
		TracNghiemEntities tn = new TracNghiemEntities();
		// GET: Admin/Quiz
		public ActionResult Index(int page = 1, int pageSize = 10)
        {
			QuizData qz = new QuizData();
			var model = qz.ListQuizPaging(page, pageSize);
            return View(model);
        }

        // GET: Admin/Quiz/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
		public void SetViewBagDD(int? selectedID = null)
		{
			var mm = new MonThiData();
			ViewBag.MaMon = new SelectList(mm.ListMonThi(), "MaMon", "TenMon", selectedID);
		}
		// GET: Admin/Quiz/Create
		public ActionResult Create()
        {
			SetViewBagDD();
            return View();
        }

        // POST: Admin/Quiz/Create
        [HttpPost]
        public ActionResult Create(Quiz collection)
        {
            try
            {
				// TODO: Add insert logic here
				if (ModelState.IsValid)
				{
					byte[] imageData = null;
					if (Request.Files.Count > 0)
					{
						HttpPostedFileBase poImgFile = Request.Files["fileim"];
						using (var binary = new BinaryReader(poImgFile.InputStream))
						{
							imageData = binary.ReadBytes(poImgFile.ContentLength);
						}
					}
					collection.Picture = imageData;
					var qz = new QuizData();
					int id = qz.Insert(collection);
					if (id > 0)
					{
						return RedirectToAction("Index", "Quiz");
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

        // GET: Admin/Quiz/Edit/5
        public ActionResult Edit(int id)
        {
			var model = tn.Quizs.Find(id);
			SetViewBagDD();
            return View(model);
        }

        // POST: Admin/Quiz/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Quiz collection)
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
						collection.Picture = imageData;
						var ts = new QuizData();
						var res = ts.Update(collection);
						if (res)
						{
							return RedirectToAction("Index", "Quiz");
						}
						else
						{
							ModelState.AddModelError("", "Edit failed");
						}
					}
					else
					{
						byte[] tana = tn.Quizs.Where(x => x.MaCauHoi == id).Select(u => u.Picture).SingleOrDefault();
						collection.Picture = tana;
						var ts = new QuizData();
						var res = ts.Update(collection);
						if (res)
						{
							return RedirectToAction("Index", "Quiz");
						}
						else
						{
							ModelState.AddModelError("", "Edit failed");
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

        // GET: Admin/Quiz/Delete/5
        public ActionResult Delete(int id)
        {
			var model = tn.Quizs.Find(id);
            return View(model);
        }

        // POST: Admin/Quiz/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
				// TODO: Add delete logic here
				if (ModelState.IsValid)
				{
					var ts = new QuizData();
					var res = ts.Delete(id);
					if (res)
					{
						return RedirectToAction("Index", "Quiz");
					}
					else
					{
						ModelState.AddModelError("", "Delete failed");
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
