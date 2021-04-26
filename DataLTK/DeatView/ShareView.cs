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
			tn = new Multi_ChoiceEntities();
		}
		public List<Account> Username(string Username)
		{
			var res = tn.Account.Where(x => x.Username == Username).ToList();
			return res;
		}
	}
}
