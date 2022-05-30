using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuhUsl.Data
{
	public class Client
	{
		//TODO Не выполняю напрямую привязку к Client, т.к. приложение может быть уязвимым для оверпостинга.
		public int ClientId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public bool IsDeleted { get; set; }
		public bool IsMailingList { get; set; }
		public DateTime AddDate { get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}
