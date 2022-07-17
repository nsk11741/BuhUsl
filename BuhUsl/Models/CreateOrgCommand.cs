using BuhUsl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuhUsl.Models
{
	public class CreateOrgCommand : EditOrgBase
	{
		public Org ToOrg(ApplicationUser createdBy, string serviceName)
		{
			return new Org
			{
				CreatedById = createdBy.Id,
				ServiceName = serviceName,
				Name = Name,
				Inn = Inn,
				SystemNalog = SystemNalog,
				Year = Year,
				Quarter = Quarter,
				IsDeleted = false,
				AddDate = DateTime.Now,

			};
		}
	}
}
