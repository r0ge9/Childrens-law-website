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
		public IQueryable<Review> GetReviews()//метод получения всех отзывов из БД
		{
			return context.Reviews;
		}
		public Review GetReviewById(int id)//метод получения отзыва по id из БД
		{
			return context.Reviews.FirstOrDefault(x => x.Id == id);
		}
		public Review GetReviewByName(string name)//метод получения отзыва по имени владельца из БД
		{
			return context.Reviews.FirstOrDefault(e => e.Name == name);
		}
		public void SaveReview(Review entity)//сохранение нового или измененного отзыва в БД
		{
			if (entity.Id == default(int)) { context.Entry(entity).State = EntityState.Added; }
			else { context.Entry(entity).State = EntityState.Modified; }
			context.SaveChanges();
		}
		public void DeleteReview(int id)//удаление отзыва из БД по id
		{
			context.Reviews.Remove(new Review() { Id = id });
			context.SaveChanges();
		}
	}
}
