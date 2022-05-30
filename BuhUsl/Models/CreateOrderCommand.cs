using BuhUsl.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuhUsl.Models
{
	public class CreateOrderCommand
	{
		[Required]
		[StringLength(50, ErrorMessage = "Максимальная длина составляет {1}")]
		[Display(Name = "Название организации")]
		public string CompanyName { get; set; }

		[Required]
		[Range(1000000000, 999999999999999, ErrorMessage = "Должно быть от 10 до 15 цифр")]
		[Display(Name = "ИНН или ОГРН")]
		public long Inn { get; set; }

		[Required]
		[Display(Name = "Система налогообложения")]
		public string SystemNalog { get; set; }

		[Required]
		[Range(1, 4, ErrorMessage = "Должно быть от 1 до 4")]
		[Display(Name = "Квартал")]
		public int QuarterFrom { get; set; }

		[Required]
		[Range(2019, 2022, ErrorMessage = "Должно быть от 2019 до 2022")]
		[Display(Name = "Год")]
		public int YearFrom { get; set; }

		[Display(Name = "Прислать xml")]
		public bool Xml { get; set; }


		public Order ToOrders()
		{
			return new Order
			{
				Name = CompanyName,
				Inn = Inn,
				SystemNalog = SystemNalog,
				Year = YearFrom,
				Quarter = QuarterFrom,
				AddDate = DateTime.Now,
			};
		}
		public Order ToOrdersExists(int clientId)
		{
			return new Order
			{
				ClientId = clientId,
				Name = CompanyName,
				Inn = Inn,
				SystemNalog = SystemNalog,
				Year = YearFrom,
				Quarter = QuarterFrom,
				AddDate = DateTime.Now,
			};
		}
	}
}
