using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemLTK.Common
{
	[Serializable]
	public class ThiSinhInfo
	{
		public int MaThiSinh { get; set; }
		public string HoTen { get; set; }
		public byte[] Image { get; set; }
		public int? MaLop { get; set; }
	}
}