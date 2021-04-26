using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLTK
{
	public class AccountData
	{
		Multi_Choice_Entities tn = null;
		public AccountData()
		{
			tn = new Multi_Choice_Entities();
		}
		public List<Account> ListAccount()
		{
			var tan = tn.Accounts.ToList();
			return tan;
		}
		public int Insert(Account entity)
		{
			tn.Accounts.Add(entity);
			tn.SaveChanges();
			return entity.id;
		}
		public bool Update(Account entity)
		{
			var tan = tn.Accounts.Find(entity.id);
			tan.Username = entity.Username;
			tan.Password = entity.Password;
			tn.SaveChanges();
			return true;
		}
		public bool Delete(int id)
		{
			var tan = tn.Accounts.Find(id);
			tn.Accounts.Remove(tan);
			tn.SaveChanges();
			return true;
		}
	}
}
