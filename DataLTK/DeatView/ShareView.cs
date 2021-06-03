using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLTK.DeatView
{
	public class ShareView
	{
		TracNghiemEntities tn = null;
		public ShareView()
		{
			tn = new TracNghiemEntities();
		}
		public List<TaiKhoan> TenTaiKhoan(string Username)
		{
			var res = tn.TaiKhoans.Where(x => x.Username == Username).ToList();
			return res;
		}
	}
}
