using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLTK
{
	public class RoleData
	{
		TracNghiemEntities tn = null;
		public RoleData()
		{
			tn = new TracNghiemEntities();
		}
		public List<Quyen> ListRole()
		{
			var tan = tn.Quyens.ToList();
			return tan;
		}
	}
}
