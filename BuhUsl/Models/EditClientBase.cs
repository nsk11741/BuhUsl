using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuhUsl.Models
{
	public class EditClientBase
	{

		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Display(Name = "Ваше имя")]
		public string Name { get; set; }

	}
}
