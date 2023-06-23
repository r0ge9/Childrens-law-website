using Diplom.Domain.Entities;
using Diplom.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Diplom.Domain.Repositories.EF
{
	public class EFTestRepository : ITestRepository
	{
		private readonly AppDbContext context;
		public EFTestRepository(AppDbContext context)
		{
			this.context = context;
		}
		public IQueryable<Test> GetTests()//метод получения всех тестов из БД
		{
			return context.Tests;
		}
		public Test GetTestById(int id)//метод получения теста из БД по id
		{
			return context.Tests.FirstOrDefault(x => x.Id == id);
		}
		public Test GetTestByName(string name)//метод получения теста из БД по имени
		{
			return context.Tests.FirstOrDefault(e => e.Name == name);
		}
		public void SaveTest(Test entity)//метод сохранения измненного или нового теста
		{
			if (entity.Id == default(int)) { context.Entry(entity).State = EntityState.Added; }
			else { context.Entry(entity).State = EntityState.Modified; }
			context.SaveChanges();
		}
		public void DeleteTest(int id)//метод удаления теста из БД по id
		{
			context.Tests.Remove(new Test() { Id = id });
			context.SaveChanges();
		}
	}
}
