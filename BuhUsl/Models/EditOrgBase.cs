using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuhUsl.Models
{
	public class EditOrgBase
	{
		[Required]
		[StringLength(50, ErrorMessage = "Максимальная длина составляет {1}")]
		[Display(Name = "Название организации")]
		public string Name { get; set; }

		[Required]
		[Range(1000000000, 999999999999999, ErrorMessage = "Должно быть от 10 до 15 цифр")]
		[Display(Name = "ИНН или ОГРН")]
		public long Inn { get; set; }

		[Required]
		[Display(Name = "Система налогообложения")]
		public string SystemNalog { get; set; }

		[Required]
		[Range(2019, 2022, ErrorMessage = "Должно быть от 2019 до 2022")]
		[Display(Name = "Год")]
		public int Year { get; set; }

		[Required]
		[Range(1, 4, ErrorMessage = "Должно быть от 1 до 4")]
		[Display(Name = "Квартал")]
		public int Quarter { get; set; }

		public SelectListItem[] SystemNalogList { get; } =
		{
			new SelectListItem{Text="ОСНО", Value = "ОСНО"},
			new SelectListItem{Text="УСН 15%", Value = "УСН 15%"},
			new SelectListItem{Text="УСН 6%", Value = "УСН 6%"},
		};

		public SelectListItem[] QuarterFromList { get; } =
		{
			new SelectListItem{Text="1 кв.", Value = "1"},
			new SelectListItem{Text="2 кв.", Value = "2"},
			new SelectListItem{Text="3 кв.", Value = "3"},
			new SelectListItem{Text="4 кв.", Value = "4"},
		};

		public SelectListItem[] YearFromList { get; } =
		{
			new SelectListItem{Text="2019", Value = "2019"},
			new SelectListItem{Text="2020", Value = "2020"},
			new SelectListItem{Text="2021", Value = "2021"},
			new SelectListItem{Text="2022", Value = "2022"},
		};
	}
}
