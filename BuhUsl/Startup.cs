using BuhUsl.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuhUsl.Services;
using BuhUsl.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace BuhUsl
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{

			var connString = Configuration.GetConnectionString("SqlLiteConnection"); //DefaultConnection ��� SqlLiteConnection

			services.AddDbContext<AppDbContext>(
					// ���� �� ����������� SQL Server ��� Local DB, ����������� ��������� ������:
					//options => options.UseSqlServer(connString)
					// ���� �� ����������� SQLite, ����������� ������ ����� ��������� ������:
					options => options.UseSqlite(connString)
			);

			services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false) //TODO ������� �� true
				.AddEntityFrameworkStores<AppDbContext>();

			services.AddRazorPages();

			services.AddScoped<OrgService>();
			services.AddScoped<IMessageSender, EmailSender>();
			services.AddScoped<IAuthorizationHandler, IsOrgOwnerHandler>();

			services.AddAuthorization(options =>
			{
				options.AddPolicy("CanManageOrg",
					policyBuilder => policyBuilder
						.AddRequirements(new IsOrgOwnerRequirement()));
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				//app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
			});
		}
	}
}
