using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLTK
{
	public class AccountData
	{
		TracNghiemEntities tn = null;
		public AccountData()
		{
			tn = new TracNghiemEntities();
		}
		public List<TaiKhoan> ListTaiKhoan()
		{
			var tan = tn.TaiKhoans.ToList();
			return tan;
		}
		public int Insert(TaiKhoan entity)
		{
			tn.TaiKhoans.Add(entity);
			tn.SaveChanges();
			return entity.id;
		}
		public bool Update(TaiKhoan entity)
		{
			var tan = tn.TaiKhoans.Find(entity.id);
			tan.Username = entity.Username;
			tan.Password = entity.Password;
			tn.SaveChanges();
			return true;
		}
		public bool Delete(int id)
		{
			var tan = tn.TaiKhoans.Find(id);
			tn.TaiKhoans.Remove(tan);
			tn.SaveChanges();
			return true;
		}
	}
}
