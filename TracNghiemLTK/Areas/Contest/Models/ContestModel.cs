using DataLTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemLTK.Areas.Contest.Models
{
	public class ContestModel
	{
		public List<ch_db> ListQuiz { get; set; }
		public int? Time { get; set; }
	}
}