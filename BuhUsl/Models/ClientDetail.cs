using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuhUsl.Models
{
	public class ClientDetailViewModel
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }

		public IEnumerable<Item> Orders { get; set; }

		public class Item
		{
			public string Name { get; set; }
			public long Inn { get; set; }
			public string SystemNalog { get; set; }
			public int Year { get; set; }
			public int Quarter { get; set; }
		}
	}
}
