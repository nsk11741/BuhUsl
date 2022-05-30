using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BuhUsl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BuhUsl.Pages
{
	public class NullOtchModel : PageModel
    {
		[BindProperty]
		public CreateClientCommand Input { get; set; }
		private readonly ClientService _service;

		public NullOtchModel(ClientService service)
		{
			_service = service;
		}

		public void OnGet()
		{
			Input = new CreateClientCommand();
		}

		public async Task<IActionResult> OnPost()
		{
			try
			{
				if (ModelState.IsValid)
				{
					var id = await _service.CreateClient(Input);
					return RedirectToPage("View", new { id = id });
				}
			}
			catch (Exception)
			{
				ModelState.AddModelError(
					string.Empty,
					"Произошла ошибка при сохранении заказа"
					);
			}

			return Page();
		}

	}
}
