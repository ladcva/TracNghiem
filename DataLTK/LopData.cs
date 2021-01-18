using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLTK
{
	public class LopData
	{
		private TracNghiemEntities tn;
		public LopData()
		{
			tn = new TracNghiemEntities();
		}
		public List<Lop> ListLop()
		{
			var res = tn.Lops.ToList();
			return res;
		}
		public int Insert(Lop entity)
		{
			tn.Lops.Add(entity);
			tn.SaveChanges();
			return entity.MaLop;
		}
		public bool Update(Lop entity)
		{
			var tan = tn.Lops.Find(entity.MaLop);
			tan.TenLop = entity.TenLop;
			tan.Khoi = entity.Khoi;
			tn.SaveChanges();
			return true;
		}
		public bool Delete(int id)
		{
			var tan = tn.Lops.Find(id);
			tn.Lops.Remove(tan);
			tn.SaveChanges();
			return true;
		}
	}
}
