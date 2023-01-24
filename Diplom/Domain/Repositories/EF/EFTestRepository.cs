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
		public IQueryable<Test> GetTests()
		{
			return context.Tests;
		}
		public Test GetQuestionById(int id)
		{
			return context.Tests.FirstOrDefault(x => x.Id == id);
		}
		public Test GetTestByType(string name)
		{
			return context.Tests.FirstOrDefault(e => e.Type == name);
		}
		public void SaveQuestion(Test entity)
		{
			if (entity.Id == default(int)) { context.Entry(entity).State = EntityState.Added; }
			else { context.Entry(entity).State = EntityState.Modified; }
			context.SaveChanges();
		}
		public void DeleteQuestion(int id)
		{
			context.Tests.Remove(new Test() { Id = id });
			context.SaveChanges();
		}
	}
}
