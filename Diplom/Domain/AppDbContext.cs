using Diplom.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Diplom.Domain
{
	public class AppDbContext:IdentityDbContext<IdentityUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
		{ Database.EnsureCreated(); }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Diplom");
			optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Diplom;AttachDbFilename=|DataDirectory|\\Data\\Diplom.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
		public override void Dispose()
		{
			base.Dispose();
		}
		public override ValueTask DisposeAsync()
		{
			return base.DisposeAsync();
		}
		public DbSet<Event> Events { get; set; }

		public DbSet<Review> Reviews { get; set; }
		public DbSet<Test> Tests { get; set; }
		public DbSet<Question> Questions { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
