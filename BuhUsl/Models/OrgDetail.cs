using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuhUsl.Models
{
	public class OrgDetailViewModel
	{
		public int Id { get; set; }
		public string ServiceName { get; set; }
		public string Name { get; set; }
		public long Inn { get; set; }
		public string SystemNalog { get; set; }
		public int Year { get; set; }
		public int Quarter { get; set; }
	}
}
