using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLTK;

namespace TracNghiemLTK.Areas.Contest.Models
{
	public class EnterContestModel
	{
		public string Password { get; set; }
		public int MaDe { get; set; }
		public List<DeThi> ListDeThi()
		{
			TracNghiemEntities tn = new TracNghiemEntities();
			var model = tn.DeThis.ToList();
			return model;
		}
	}
}