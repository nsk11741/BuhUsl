using BuhUsl.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuhUsl.Models
{
	public class CreateClientCommand : EditClientBase
	{
		public IList<CreateOrderCommand> Orders { get; set; } = new List<CreateOrderCommand>();

		public Client ToClient()
		{

			return new Client
			{
				Email = Email,
				Name = Name,
				AddDate = DateTime.Now,
				IsDeleted = false,

				Orders = Orders?.Select(x => x.ToOrders()).ToList()

			};
		}

		public Client ToClientExists(Client client)
		{
			client.Orders = Orders?.Select(x => x.ToOrdersExists(client.ClientId)).ToList();
			return client;
		}
	}
}
