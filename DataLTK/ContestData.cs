using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLTK
{
	public class ContestData
	{
		private Multi_Choice_Entities tn;
		public ContestData()
		{
			tn = Multi_Choice_Entities();
		}
		public List<ch_db> ListQuiz()
		{
			var model = tn.ch_db.ToList();
			return model;
		}
		public bool CheckQuiz(int id_ques, string answer)
		{
			var model = tn.Quizs.Count(x => x.id_ques == id_ques && x.answer == answer);
			if(model > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public List<Result> ListResultID(int id_examinee, int id_code)
		{
			var tan = tn.Results.Where(x => x.code == code && x.id_examinee == examinee).ToList();
			return tan;
		}
	}
}
