using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuhUsl.Models
{
	public class OrgSummaryViewModel
	{
		public int Id { get; set; }
		public string ServiceName { get; set; }
		public string Name { get; set; }
		public string YearStr { get; set; }
		public string QuarterStr { get; set; }
		public string IsDone { get; set; }
	}
}
