using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLTK.DeatView
{
	public class ShareView
	{
		Multi_Choice_Entities tn = null;
		public ShareView()
		{
			tn = new Multi_Choice_Entities();
		}
		public List<Account> Username(string Username)
		{
			var res = tn.Accounts.Where(x => x.Username == Username).ToList();
			return res;
		}
	}
}
