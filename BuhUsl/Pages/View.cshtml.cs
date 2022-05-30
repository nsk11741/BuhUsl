using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuhUsl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BuhUsl.Pages
{
    public class ViewModel : PageModel
    {
		public ClientDetailViewModel Client { get; set; }
		private readonly ClientService _service;
		public ViewModel(ClientService service)
		{
			_service = service;
		}

		public async Task<IActionResult> OnGetAsync(int id)
		{
			Client = await _service.GetClientDetail(id);
			if (Client is null)
			{
				return NotFound();
			}
			return Page();
		}


	}
}
