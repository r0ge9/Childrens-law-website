using Diplom.Domain.Entities;

namespace Diplom.Domain.Repositories.Abstract
{
	public interface ITestRepository
	{
		IQueryable<Test> GetTests();
		Test GetQuestionById(int id);
		Test GetTestByType(string type);
		void SaveQuestion(Test entity);
		void DeleteQuestion(int id);
	}
}
