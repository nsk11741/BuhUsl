using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BuhUsl.Data;
using BuhUsl.Models;
using BuhUsl.Services;
using BuhUsl;
using Microsoft.AspNetCore.Authorization;
using BuhUsl.Models;

namespace BuhUsl.Pages
{
	[Authorize]
	public class EditModel : PageModel
	{
		[BindProperty]
		public UpdateOrgCommand Input { get; set; }
		private readonly OrgService _service;
		private readonly IAuthorizationService _authService;

		public EditModel(OrgService service, IAuthorizationService authService)
		{
			_service = service;
			_authService = authService;
		}

		public async Task<IActionResult> OnGet(int id)
		{
			var org = await _service.GetOrg(id);
			var authResult = await _authService.AuthorizeAsync(User, org, "CanManageOrg");
			if (!authResult.Succeeded)
			{
				return new ForbidResult();
			}

			Input = await _service.GetOrgForUpdate(id);
			if (Input is null)
			{
				// 
				// 
				return NotFound();
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			try
			{
				var org = await _service.GetOrg(Input.Id);
				var authResult = await _authService.AuthorizeAsync(User, org, "CanManageOrg");
				if (!authResult.Succeeded)
				{
					return new ForbidResult();
				}

				if (ModelState.IsValid)
				{
					await _service.UpdateOrg(Input);
					return RedirectToPage("View", new { id = Input.Id });
				}
			}
			catch (Exception)
			{
				// TODO: Log error
				// Add a model-level error by using an empty string key
				ModelState.AddModelError(
					string.Empty,
					"An error occured saving the org"
					);
			}

			//If we got to here, something went wrong
			return Page();
		}
	}
}