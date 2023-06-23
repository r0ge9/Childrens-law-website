using Diplom.Domain.Entities;

namespace Diplom.Domain.Repositories.Abstract
{
	public interface ITestRepository//интерфейс сущности теста БД
	{
		IQueryable<Test> GetTests();
		Test GetTestById(int id);
		Test GetTestByName(string type);
		void SaveTest(Test entity);
		void DeleteTest(int id);
	}
}
