using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BuhUsl.Data;
using BuhUsl.Models;
using BuhUsl.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BuhUsl.Pages
{
	[Authorize]
	public class BuhOtchModel : PageModel
	{
		[BindProperty]
		public CreateOrgCommand Input { get; set; }
		private readonly OrgService _service;
		private readonly UserManager<ApplicationUser> _userService;
		private readonly IMessageSender _messageSender;


		public BuhOtchModel(OrgService service, UserManager<ApplicationUser> userService, IMessageSender messageSender)
		{
			_service = service;
			_userService = userService;
			_messageSender = messageSender;
		}

		public void OnGet()
		{
			Input = new CreateOrgCommand();
		}

		public async Task<IActionResult> OnPost()
		{
			try
			{
				if (ModelState.IsValid)
				{
					var appUser = await _userService.GetUserAsync(User);
					var id = await _service.CreateOrg(Input, appUser, "Бух отчетность");
					_messageSender.SendMessage(appUser.Email);
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
