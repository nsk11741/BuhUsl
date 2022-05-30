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

			var connString = Configuration.GetConnectionString("SqlLiteConnection"); //DefaultConnection или SqlLiteConnection

			services.AddDbContext<AppDbContext>(
					// Если вы используете SQL Server или Local DB, используйте следующую строку:
					//options => options.UseSqlServer(connString)
					// Если вы используете SQLite, используйте вместо этого следующую строку:
					options => options.UseSqlite(connString)
			);

			services.AddRazorPages();

			services.AddScoped<ClientService>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
			});
		}
	}
}
