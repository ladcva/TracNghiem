using DataLTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemLTK.Areas.Admin.Models
{
	public class MultiQuizModel
	{
		public List<DeThi> DeThi { get; set; }
		public List<Quiz> Quiz { get; set; }
	}
}