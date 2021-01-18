using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLTK;
using TracNghiemLTK.Areas.Contest.Models;
using TracNghiemLTK.Common;

namespace TracNghiemLTK.Areas.Contest.Controllers
{
    public class DefaultController : BaseContestController
    {
		DeThiData dt = new DeThiData();
		TracNghiemEntities tn = new TracNghiemEntities();
        // GET: Contest/Default
        public ActionResult Index()
        {
			var tan = dt.ListDeThi();
            return View(tan);
        }
		
		//chọn đề và vào thi
		public ActionResult EnterContest(int id)
		{
			return View();
		}
		[HttpPost]
		public ActionResult EnterContest(EnterContestModel lg, int id)
		{
			LoginData ld = new LoginData();
			var res = ld.CheckDeThi(lg.Password, id);
			var session = (TracNghiemLTK.Common.ThiSinhInfo)Session[TracNghiemLTK.Common.CommonConstantsStudent.STUDENT_SESSION];
			var tan1 = tn.KetQuas.Count(x => x.MaThiSinh == session.MaThiSinh && x.MaDe == id);
			if (res == true)
			{
				if (tan1 > 0)
				{
					ModelState.AddModelError("", "Bạn đã làm bài thi này rồi!");
				}
				else
				{
					return RedirectToAction("StartContest", "Default", new { area = "Contest", id = id });
				}
			}
			else
			{
				ModelState.AddModelError("", "Mật khẩu không đúng!");
			}
			return View(lg);
		}
		public ActionResult StartContest(int id)
		{
			ContestModel cm = new ContestModel();
			cm.ListQuiz = tn.ch_db.Where(x => x.MaDe == id).ToList();
			cm.Time = tn.DeThis.Where(x => x.MaDe == id).Select(u => u.Time).FirstOrDefault();
			return View(cm);
		}
		[HttpPost]
		public ActionResult StartContest(int id, ContestModel collection)
		{
			int socau = tn.ch_db.Count(x => x.MaDe == id);
			float hesodiem = 100/socau;
			float diem;
			int bodem = 0;
			for (int i=0;i<collection.ListQuiz.Count;i++)
			{
				var quizid = tn.Quizs.Find(collection.ListQuiz[i].MaCauHoi);
				if (quizid.DapAn == collection.ListQuiz[i].SelectedAnswer)
				{
					bodem = bodem + 1;
				}
			}
			diem = bodem * hesodiem;
			var session = (TracNghiemLTK.Common.ThiSinhInfo)Session[TracNghiemLTK.Common.CommonConstantsStudent.STUDENT_SESSION];
			tn.KetQuas.Add(new KetQua()
			{
				MaDe = id,
				MaThiSinh = session.MaThiSinh,
				Diem = diem,
				NgayThi = DateTime.Now
			});
			tn.SaveChanges();
			return RedirectToAction("Index", "ContestResult", new { area = "Contest", @maThiSinh = session.MaThiSinh, @maDe = id });
		}
		public ActionResult Logout()
		{
			Session[CommonConstantsStudent.STUDENT_SESSION] = null;
			return Redirect("/");
		}
	}
}
