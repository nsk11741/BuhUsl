using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BuhUsl.Data;

namespace BuhUsl.Authorization
{
	public class IsOrgOwnerHandler :
		AuthorizationHandler<IsOrgOwnerRequirement, Org>
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public IsOrgOwnerHandler(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}
		protected override async Task HandleRequirementAsync(
			AuthorizationHandlerContext context,
			IsOrgOwnerRequirement requirement,
			Org resource)
		{
			var appUser = await _userManager.GetUserAsync(context.User);
			if (appUser == null)
			{
				return;
			}

			if (resource.CreatedById == appUser.Id)
			{
				context.Succeed(requirement);
			}

		}
	}
}
