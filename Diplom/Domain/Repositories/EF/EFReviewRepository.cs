using Diplom.Domain.Entities;
using Diplom.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Diplom.Domain.Repositories.EF
{
	public class EFReviewRepository:IReviewRepository
	{
		private readonly AppDbContext context;
		public EFReviewRepository(AppDbContext context)
		{
			this.context = context;
		}
		public IQueryable<Review> GetReviews()
		{
			return context.Reviews;
		}
		public Review GetReviewById(int id)
		{
			return context.Reviews.FirstOrDefault(x => x.Id == id);
		}
		public Review GetReviewByName(string name)
		{
			return context.Reviews.FirstOrDefault(e => e.Name == name);
		}
		public void SaveReview(Review entity)
		{
			if (entity.Id == default(int)) { context.Entry(entity).State = EntityState.Added; }
			else { context.Entry(entity).State = EntityState.Modified; }
			context.SaveChanges();
		}
		public void DeleteReview(int id)
		{
			context.Reviews.Remove(new Review() { Id = id });
		}
	}
}
