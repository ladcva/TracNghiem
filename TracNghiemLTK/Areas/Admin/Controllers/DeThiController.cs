using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLTK;
using TracNghiemLTK.Areas.Admin.Models;
using System.IO;

namespace TracNghiemLTK.Areas.Admin.Controllers
{
	public class DeThiController : BaseController
	{
		// GET: Admin/DeThi
		public ActionResult Index()
		{
			DeThiData dt = new DeThiData();
			var model = dt.ListDeThi();
			return View(model);
		}

		// GET: Admin/DeThi/Details/5
		public ActionResult Details(int id)
		{
			DeThiData dt = new DeThiData();
			var model = dt.ListQuizID(id);
			return View(model);
		}
		public void SetViewBagDD(int? selectedID = null)
		{
			var mt = new MonThiData();
			ViewBag.MaMon = new SelectList(mt.ListMonThi(), "MaMon", "TenMon", selectedID);
			var qz = new QuizData();
			ViewBag.MaCauHoi = new SelectList(qz.ListQuiz(), "MaCauHoi", "CauHoi", selectedID);
		}
		public void SetViewBagMD(int selectedID)
		{

			var db = new DeThiData();
			ViewBag.MaDe = new SelectList(db.ListDeThi(), "MaDe", "TenDe", selectedID);
		}
		// GET: Admin/DeThi/Create
		public ActionResult Create()
		{
			TracNghiemEntities tn = new TracNghiemEntities();
			ViewBag.MaMon = new SelectList(tn.MonThis.ToList(), "MaMon", "TenMon");
			return View();
		}

		// POST: Admin/DeThi/Create
		[HttpPost]
		public ActionResult Create(DeThi collection)
		{
			try
			{
				// TODO: Add insert logic here
				if (ModelState.IsValid)
				{
					HttpPostedFileBase fileAudio = Request.Files["fileAudio"];
					if (fileAudio != null && fileAudio.ContentLength > 0)
					{
						FileInfo finfo = new FileInfo(fileAudio.FileName);
						fileAudio.SaveAs(Server.MapPath("~/Content/audio/" + finfo));
					}
					else
					{
						collection.Audio = null;
					}
					collection.Audio = fileAudio.FileName;
					collection.CreateDate = DateTime.Now;
					DeThiData tan = new DeThiData();
					int id = tan.Insert(collection);
					if (id > 0)
					{
						return RedirectToAction("Index", "DeThi");
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

		// GET: Admin/DeThi/Edit/5
		public ActionResult Edit(int id)
		{
			TracNghiemEntities tn = new TracNghiemEntities();
			var model = tn.DeThis.Find(id);
			SetViewBagDD();
			return View(model);
		}

		// POST: Admin/DeThi/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, DeThi collection)
		{
			try
			{
				// TODO: Add update logic here
				if (ModelState.IsValid)
				{
					HttpPostedFileBase fileAudio = Request.Files["fileAudio"];
					if (fileAudio != null && fileAudio.ContentLength > 0)
					{
						FileInfo finfo = new FileInfo(fileAudio.FileName);
						fileAudio.SaveAs(Server.MapPath("~/Content/audio/" + finfo));
						collection.Audio = fileAudio.FileName;
					}
					else
					{
						TracNghiemEntities tn = new TracNghiemEntities();
						collection.Audio = tn.DeThis.Where(x => x.MaDe == id).Select(u => u.Audio).FirstOrDefault();
					}
					DeThiData tan = new DeThiData();
					var res = tan.Update(collection);
					if (res)
					{
						return RedirectToAction("Index", "DeThi");
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

		// GET: Admin/DeThi/Delete/5
		public ActionResult Delete(int id)
		{
			TracNghiemEntities tn = new TracNghiemEntities();
			var model = tn.DeThis.Find(id);
			return View(model);
		}

		// POST: Admin/DeThi/Delete/5
		[HttpDelete]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here
				if (ModelState.IsValid)
				{
					DeThiData tan = new DeThiData();
					var res = tan.Delete(id);
					if (res)
					{
						return RedirectToAction("Index", "DeThi");
					}
					else
					{
						ModelState.AddModelError("", "Xóa thất bại");
					}
				}
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
		public ActionResult AddQuiz(int id)
		{
			SetViewBagDD();
			SetViewBagMD(id);
			return View();
		}
		[HttpPost]
		public ActionResult AddQuiz(ch_db collection)
		{
			try
			{
				if (ModelState.IsValid)
				{
					DeThiData tan = new DeThiData();
					int id = tan.InsertID(collection);
					if (id > 0)
					{
						return RedirectToAction("Details/" + Url.RequestContext.RouteData.Values["id"], "DeThi");
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
		public ActionResult RemoveQuizInTheardID(int id)
		{
			TracNghiemEntities tn = new TracNghiemEntities();
			var model = tn.ch_db.Find(id);
			return View(model);
		}
		[HttpDelete]
		public ActionResult RemoveQuizInTheardID(int id, FormCollection collection, int theard)
		{
			try
			{
				TheardDetailsData thd = new TheardDetailsData();
				if (ModelState.IsValid)
				{
					var res = thd.DeleteQuizInTheard(id);
					if (res)
					{
						return RedirectToAction("Details", "DeThi", new { id = theard });
					}
					else
					{
						ModelState.AddModelError("", "Xóa thất bại");
					}
				}
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
		public ActionResult AddQuizs(int id)
		{
			TracNghiemEntities tn = new TracNghiemEntities();
			MultiQuizModel qm = new MultiQuizModel();
			qm.Quiz = tn.Quizs.ToList<Quiz>();
			qm.DeThi = tn.DeThis.ToList<DeThi>();
			return View(qm);
		}
		[HttpPost]
		public ActionResult AddQuizs(MultiQuizModel collection, int id)
		{
			try
			{
				TracNghiemEntities tn = new TracNghiemEntities();
				if (ModelState.IsValid)
				{
					for (int i = 0; i < collection.Quiz.Count; i++)
					{
						if (collection.Quiz[i].table_records)
						{
							tn.ch_db.Add(new ch_db()
							{
								MaDe = id,
								MaCauHoi = collection.Quiz[i].MaCauHoi
							});
							tn.SaveChanges();
						}
					}
					return RedirectToAction("Details", "DeThi", new { id = id });
				}
				return View(collection);
			}
			catch
			{
				return View();
			}
		}
	}
}
