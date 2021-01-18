using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLTK
{
	public class TheardDetailsData
	{
		TracNghiemEntities tn = null;
		public TheardDetailsData()
		{
			tn = new TracNghiemEntities();
		}
		public bool DeleteQuizInTheard(int id)
		{
			var tan = tn.ch_db.Find(id);
			tn.ch_db.Remove(tan);
			tn.SaveChanges();
			return true;
		}
	}
}
