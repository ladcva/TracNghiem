using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLTK
{
	public class KetQuaData
	{
		private TracNghiemEntities tn;
		public KetQuaData()
		{
			tn = new TracNghiemEntities();
		}
		public IEnumerable<KetQua> ListKetQua(int page, int pageSize)
		{
			return tn.KetQuas.OrderByDescending(x => x.MaKetQua).ToPagedList(page, pageSize);
		}
		public bool Delete(int id)
		{
			var qz = tn.KetQuas.Find(id);
			tn.KetQuas.Remove(qz);
			tn.SaveChanges();
			return true;
		}
	}
}
