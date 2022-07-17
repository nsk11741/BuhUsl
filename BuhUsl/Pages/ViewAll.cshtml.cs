using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuhUsl.Data;
using BuhUsl.Models;
using BuhUsl.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BuhUsl.Pages
{
	[Authorize]
	public class ViewAllModel : PageModel
    {
		private readonly OrgService _service;
		private readonly UserManager<ApplicationUser> _userManager;
		public IEnumerable<OrgSummaryViewModel> Orgs { get; private set; }

		public ViewAllModel(OrgService service, UserManager<ApplicationUser> userManager)
		{
			_service = service;
			_userManager = userManager;
		}
		public async Task OnGet()
        {
			var appUser = await _userManager.GetUserAsync(User);

			//Orgs = await _service.GetOrgs();
			Orgs = await _service.GetOwnOrgs(appUser.Id);
		}
    }
}
