using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLTK
{
	public class DoashboardData
	{
		TracNghiemEntities tn = null;
		ThiSinh ts = null;
		public DoashboardData()
		{
			tn = new TracNghiemEntities();
			ts = new ThiSinh();
		}
		public int SoHocSinh()
		{
			var result = tn.ThiSinhs.Count();
			return result;
		}
		public int SoLopHoc()
		{
			var result = tn.Lops.Count();
			return result;
		}
		public int SoDeThi()
		{
			var result = tn.DeThis.Count();
			return result;
		}
		public int SoMonThi()
		{
			var result = tn.MonThis.Count();
			return result;
		}
		public int SoCauHoi()
		{
			var result = tn.Quizs.Count();
			return result;
		}
		public int SoHocSinhNam()
        {
			var result = tn.ThiSinhs.Where(x => x.GioiTinh == false).Count();
			return result;
        }
		public List<DeThi> ListDeThi()
		{
			return tn.DeThis.ToList();
		}
	}
}
