using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuhUsl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BuhUsl.Services;

namespace BuhUsl.Pages
{
    public class ViewModel : PageModel
    {
		private readonly IMessageSender _messageSender;
		public ClientDetailViewModel Client { get; set; }
		private readonly ClientService _service;
		public ViewModel(ClientService service, IMessageSender messageSender)
		{
			_service = service;
			_messageSender = messageSender;
		}

		public async Task<IActionResult> OnGetAsync(int id)
		{
			Client = await _service.GetClientDetail(id);
			if (Client is null)
			{
				return NotFound();
			}
			_messageSender.SendMessage(Client.Email);
			return Page();
		}


	}
}
