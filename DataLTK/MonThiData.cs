using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLTK
{
	public class MonThiData
	{
		TracNghiemEntities tn = null;
		public MonThiData()
		{
			tn = new TracNghiemEntities();
		}
		public List<MonThi> ListMonThi()
		{
			var res = tn.MonThis.ToList();
			return res;
		}
		public int Insert(MonThi entity)
		{
			tn.MonThis.Add(entity);
			tn.SaveChanges();
			return entity.MaMon;
		}
		public bool Update(MonThi entity)
		{
			var mt = tn.MonThis.Find(entity.MaMon);
			mt.TenMon = entity.TenMon;
			tn.SaveChanges();
			return true;

		}
		public bool Delete(int id)
		{
			var mt = tn.MonThis.Find(id);
			tn.MonThis.Remove(mt);
			tn.SaveChanges();
			return true;
		}
	}
}
