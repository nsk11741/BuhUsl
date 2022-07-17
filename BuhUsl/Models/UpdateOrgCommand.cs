using BuhUsl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuhUsl.Models
{
	public class UpdateOrgCommand : EditOrgBase
	{
		public int Id { get; set; }

		public void UpdateOrg(Org org)
		{
			org.Name = Name;
			org.Inn = Inn;
			org.SystemNalog = SystemNalog;
			org.Year = Year;
			org.Quarter = Quarter;
		}
	}
}
