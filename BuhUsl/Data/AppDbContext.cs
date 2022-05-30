using Microsoft.EntityFrameworkCore;

namespace BuhUsl.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Client> Clients { get; set; }
	}
}
