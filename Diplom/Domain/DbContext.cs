using Diplom.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Diplom.Domain
{
	public class DbContext
	{
		public DbContext()
		{ }
		public DbSet<Event> Events { get; set; }

		public DbSet<Review> Reviews { get; set; }
		public DbSet<Test> Tests { get; set; }
	}
}
