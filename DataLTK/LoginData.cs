using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLTK
{
	public class LoginData
	{
		private TracNghiemEntities tn;
		public LoginData()
		{
			tn = new TracNghiemEntities();
		}
		public bool CheckLogin(int Username, string Password)
		{
			var res = (tn.ThiSinhs.Count(x=>x.MaThiSinh == Username && x.Password == Password));
			if(res > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool CheckDeThi(string Password, int MaDe)
		{
			var res = (tn.DeThis.Count(x => x.Password == Password && x.MaDe == MaDe));
			if(res > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool CheckLoginAdmin(string Username, string Password)
		{
			var res = (tn.TaiKhoans.Count(x => x.Username == Username && x.Password == Password));
			if (res > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public TaiKhoan GetByUsername(string username)
		{
			return tn.TaiKhoans.SingleOrDefault(x=>x.Username == username);
		}
		public ThiSinh GetByTen(int maThiSinh)
		{
			return tn.ThiSinhs.SingleOrDefault(x => x.MaThiSinh == maThiSinh);
		}
	}
}
