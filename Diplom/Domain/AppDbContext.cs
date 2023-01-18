using Diplom.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Diplom.Domain
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
		{ }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Diplom");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
		public DbSet<Event> Events { get; set; }

		public DbSet<Review> Reviews { get; set; }
		public DbSet<Test> Tests { get; set; }
	}
}
