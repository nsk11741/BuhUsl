using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuhUsl.Data
{
	public class Org
	{
		public int OrgId { get; set; }
		public string CreatedById { get; set; }
		public string ServiceName { get; set; }
		public string Name { get; set; }
		public long Inn { get; set; }
		public string SystemNalog { get; set; }
		public int Year { get; set; }
		public int Quarter { get; set; }
		public bool IsDone { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime AddDate { get; set; }
	}
}
