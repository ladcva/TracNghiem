using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLTK
{
	public class DeThiData
	{
		private TracNghiemEntities tn;
		public DeThiData()
		{
			tn = new TracNghiemEntities();
		}
		public List<DeThi> ListDeThi()
		{
			var res = tn.DeThis.ToList();
			return res;
		}
		public List<ch_db> ListQuizID(int MaDe)
		{
			var res = tn.ch_db.Where(x => x.MaDe == MaDe).ToList();
			return res;
		}
		public int Insert(DeThi entity)
		{
			tn.DeThis.Add(entity);
			tn.SaveChanges();
			return entity.MaDe;
		}
		public bool Update(DeThi entity)
		{
			var tan = tn.DeThis.Find(entity.MaDe);
			tan.MoTa = entity.MoTa;
			tan.MaMon = entity.MaMon;
			tan.LoaiDe = entity.LoaiDe;
			tan.MaxQuiz = entity.MaxQuiz;
			tan.Status = entity.Status;
			tan.Time = entity.Time;
			tan.Audio = entity.Audio;
			tan.Password = entity.Password;
			tn.SaveChanges();
			return true;
		}
		public bool Delete(int id)
		{
			var tan = tn.DeThis.Find(id);
			tn.DeThis.Remove(tan);
			tn.SaveChanges();
			return true;
		}
		public int InsertID(ch_db entity)
		{
			tn.ch_db.Add(entity);
			tn.SaveChanges();
			return entity.id;
		}
	}
}
