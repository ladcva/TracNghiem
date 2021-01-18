using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace DataLTK
{
	public class QuizData
	{
		private TracNghiemEntities tn;
		public QuizData()
		{
			tn = new TracNghiemEntities();
		}
		public List<Quiz> ListQuiz()
		{
			var res = tn.Quizs.ToList();
			return res;
		}
		public IEnumerable<Quiz> ListQuizPaging(int page, int pageSize)
		{
			return tn.Quizs.OrderByDescending(x=>x.MaCauHoi).ToPagedList(page, pageSize);
		}
		public int Insert(Quiz entity)
		{
			tn.Quizs.Add(entity);
			tn.SaveChanges();
			return entity.MaCauHoi;
		}
		public bool Update(Quiz entity)
		{
			var qz = tn.Quizs.Find(entity.MaCauHoi);
			qz.CauHoi = entity.CauHoi;
			qz.Picture = entity.Picture;
			qz.A = entity.A;
			qz.B = entity.B;
			qz.C = entity.C;
			qz.D = entity.D;
			qz.DapAn = entity.DapAn;
			tn.SaveChanges();
			return true;
		}
		public bool Delete(int id)
		{
			var qz = tn.Quizs.Find(id);
			tn.Quizs.Remove(qz);
			tn.SaveChanges();
			return true;
		}
	}
}
