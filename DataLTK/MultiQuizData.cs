using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLTK
{
	public class MultiQuizData
	{
		private TracNghiemEntities tn;
		public MultiQuizData()
		{
			tn = new TracNghiemEntities();
		}
		public List<Quiz> ListMultiQuiz()
		{
			var tan = tn.Quizs.ToList();
			return tan;
		}
		public List<ch_db> ListMultiQuizTan()
		{
			var tan = tn.ch_db.ToList();
			return tan;
		}
	}
}
