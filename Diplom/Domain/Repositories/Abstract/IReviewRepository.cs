using Diplom.Domain.Entities;

namespace Diplom.Domain.Repositories.Abstract
{
	public interface IReviewRepository//интерфейс сущности отзыва БД
	{
		IQueryable<Review> GetReviews();
		Review GetReviewById(int id);
		Review GetReviewByName(string name);
		void SaveReview(Review entity);
		void DeleteReview(int id);
	}
}
