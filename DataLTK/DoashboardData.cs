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
		public DoashboardData()
		{
			tn = new TracNghiemEntities();
		}
		public int SoHocSinh()
		{
			var tan = tn.ThiSinhs.Count();
			return tan;
		}
		public int SoLopHoc()
		{
			var tan = tn.Lops.Count();
			return tan;
		}
		public int SoDeThi()
		{
			var tan = tn.DeThis.Count();
			return tan;
		}
		public int SoMonThi()
		{
			var tan = tn.MonThis.Count();
			return tan;
		}
		public int SoCauHoi()
		{
			var tan = tn.Quizs.Count();
			return tan;
		}
		public List<DeThi> ListDeThi()
		{
			return tn.DeThis.ToList();
		}
	}
}
