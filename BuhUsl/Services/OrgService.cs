using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BuhUsl.Data;
using BuhUsl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuhUsl.Models;

namespace BuhUsl.Services
{
	public class OrgService
	{
		readonly AppDbContext _context;
		readonly ILogger _logger;

		public OrgService(AppDbContext context, ILoggerFactory factory)
		{
			_context = context;
			_logger = factory.CreateLogger<OrgService>();
		}

		public async Task<int> CreateOrg(CreateOrgCommand cmd, ApplicationUser createdBy, string serviceName)
		{

			var org = cmd.ToOrg(createdBy, serviceName);
			_context.Add(org);

			await _context.SaveChangesAsync();
			return org.OrgId;
		}

		public async Task<OrgDetailViewModel> GetOrgDetail(int id)
		{
			return await _context.Orgs
				.Where(x => x.OrgId == id)
				.Select(x => new OrgDetailViewModel
				{
					Id = x.OrgId,
					ServiceName = x.ServiceName,
					Name = x.Name,
					Inn = x.Inn,
					SystemNalog = x.SystemNalog,
					Year = x.Year,
					Quarter = x.Quarter,
				})
				.SingleOrDefaultAsync();
		}


		public async Task<List<OrgSummaryViewModel>> GetOrgs()
		{
			return await _context.Orgs
				.Where(r => !r.IsDeleted)
				.Select(x => new OrgSummaryViewModel
				{
					Id = x.OrgId,
					ServiceName = x.ServiceName,
					Name = x.Name,
					YearStr = $"{x.Year} г.",
					QuarterStr = $"{x.Year} кв.",
				})
				.DefaultIfEmpty().ToListAsync();
		}

		public async Task<List<OrgSummaryViewModel>> GetOwnOrgs(string id)
		{
			return await _context.Orgs
				.Where(r => !r.IsDeleted)
				.Where(r => r.CreatedById == id)
				.Select(x => new OrgSummaryViewModel
				{
					Id = x.OrgId,
					ServiceName = x.ServiceName,
					Name = x.Name,
					YearStr = $"{x.Year} г.",
					QuarterStr = $"{x.Year} кв.",
					IsDone = x.IsDone.ToString(),
				})
				.ToListAsync();
		}

		public async Task<UpdateOrgCommand> GetOrgForUpdate(int orgId)
		{
			return await _context.Orgs
				.Where(x => x.OrgId == orgId)
				.Where(x => !x.IsDeleted)
				.Select(x => new UpdateOrgCommand
				{
					Name = x.Name,
					Inn = x.Inn,
					SystemNalog = x.SystemNalog,
					Year = x.Year,
					Quarter = x.Quarter,
				})
				.SingleOrDefaultAsync();
		}


		public async Task UpdateOrg(UpdateOrgCommand cmd)
		{
			var org = await _context.Orgs.FindAsync(cmd.Id);
			if (org == null) { throw new Exception("Unable to find the org"); }
			if (org.IsDeleted) { throw new Exception("Unable to update a deleted org"); }

			cmd.UpdateOrg(org);
			await _context.SaveChangesAsync();
		}

		public async Task<Org> GetOrg(int orgId)
		{
			return await _context.Orgs
				.Where(x => x.OrgId == orgId)
				.SingleOrDefaultAsync();
		}

		public async Task DeleteOrg(int orgId)
		{
			var org = await _context.Orgs.FindAsync(orgId);
			if (org is null) { throw new Exception("Unable to find org"); }

			org.IsDeleted = true;
			await _context.SaveChangesAsync();
		}
	}
}
