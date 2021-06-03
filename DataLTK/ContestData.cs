using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLTK
{
	public class ContestData
	{
		private TracNghiemEntities tn;
		public ContestData()
		{
			tn = new TracNghiemEntities();
		}
		public List<ch_db> ListQuiz()
		{
			var model = tn.ch_db.ToList();
			return model;
		}
		public bool CheckQuiz(int maCauHoi, string dapAn)
		{
			var model = tn.Quizs.Count(x => x.MaCauHoi == maCauHoi && x.DapAn == dapAn);
			if(model > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public List<KetQua> ListKetQuaID(int maThiSinh, int maDe)
		{
			var tan = tn.KetQuas.Where(x => x.MaDe == maDe && x.MaThiSinh == maThiSinh).ToList();
			return tan;
		}
	}
}
