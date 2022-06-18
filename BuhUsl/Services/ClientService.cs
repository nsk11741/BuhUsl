using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BuhUsl.Data;
using BuhUsl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuhUsl
{
	public class ClientService
	{
		readonly AppDbContext _context;
		readonly ILogger _logger;

		public ClientService(AppDbContext context, ILoggerFactory factory)
		{
			_context = context;
			_logger = factory.CreateLogger<ClientService>();
		}

		public async Task<int> CreateClient(CreateClientCommand cmd)
		{

			Client client = _context.Clients.Where(c => c.Email == cmd.Email).SingleOrDefault();
			if (client == null)
			{
				client = cmd.ToClient();
				_context.Add(client);
			}
			else
			{
				client = cmd.ToClientExists(client);
				_context.Update(client);
			}

			await _context.SaveChangesAsync();
			return client.ClientId;
		}

		public async Task<ClientDetailViewModel> GetClientDetail(int id)
		{
			return await _context.Clients
				.Where(x => x.ClientId == id)
				.Select(x => new ClientDetailViewModel
				{
					Id = x.ClientId,
					Email = x.Email,
					Name = x.Name,
					Orders = x.Orders
					.Select(item => new ClientDetailViewModel.Item
					{
						Name = item.Name,
						Inn = item.Inn,
						SystemNalog = item.SystemNalog,
						Year = item.Year,
						Quarter = item.Quarter,
					})
				})
				.SingleOrDefaultAsync();
		}





	}
}
