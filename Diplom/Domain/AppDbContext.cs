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
			//optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Diplom;AttachDbFilename=|DataDirectory|\\Data\\Diplom.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
		public DbSet<Event> Events { get; set; }

		public DbSet<Review> Reviews { get; set; }
		public DbSet<Test> Tests { get; set; }
		public DbSet<Question> Questions { get; set; }
	}
}
