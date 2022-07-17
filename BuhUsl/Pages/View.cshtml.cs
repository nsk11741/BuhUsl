using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuhUsl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BuhUsl.Services;
using Microsoft.AspNetCore.Authorization;
using BuhUsl.Models;

namespace BuhUsl.Pages
{
	[Authorize]
	public class ViewModel : PageModel
    {
		
		public OrgDetailViewModel Org { get; set; }
		public bool CanEditOrg { get; set; }

		private readonly OrgService _service;
		private readonly IAuthorizationService _authService;
		public ViewModel(OrgService service, IAuthorizationService authService)
		{
			_service = service;
			_authService = authService;
		}

		public async Task<IActionResult> OnGetAsync(int id)
		{
			var org = await _service.GetOrg(id);
			var authResult = await _authService.AuthorizeAsync(User, org, "CanManageOrg");
			if (!authResult.Succeeded)
			{
				return new ForbidResult();
			}

			CanEditOrg = authResult.Succeeded;

			Org = await _service.GetOrgDetail(id);
			if (Org is null)
			{
				return NotFound();
			}
			

			//var org = await _service.GetOrg(id);
			//var isAuthorised = await _authService.AuthorizeAsync(User, org, "CanManageOrg");
			//CanEditOrg = isAuthorised.Succeeded;

			return Page();
		}

		public async Task<IActionResult> OnPostDeleteAsync(int id)
		{
			var org = await _service.GetOrg(id);
			var authResult = await _authService.AuthorizeAsync(User, org, "CanManageOrg");
			if (!authResult.Succeeded)
			{
				return new ForbidResult();
			}

			await _service.DeleteOrg(id);

			return RedirectToPage("/Index");
		}
	}
}
