using Diplom.Domain.Entities;
using Diplom.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Diplom.Domain.Repositories.EF
{
    public class EFQuestionRepository:IQuestionRepository
    {
        private readonly AppDbContext context;
        public EFQuestionRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Question> GetQuestions()//метод получения вопросов из БД
        {
            return context.Questions;
        }
        public Question GetQuestionById(int id)//метод получения вопроса из БД по id
        {
            return context.Questions.FirstOrDefault(x => x.Id == id);
        }
        public Question GetQuestionByTestId(int id)//метод получения вопроса по id теста
        {
            return context.Questions.FirstOrDefault(e => e.TestId == id);
        }
		public IQueryable< Question >GetQuestionsByTestId(int id)//метод получения вопросов из БД по id теста
		{
			return context.Questions.Where(x=>x.TestId==id);
		}
		public void SaveQuestion(Question entity)//метод сохранения нового или измененного вопроса
        {
            if (entity.Id == default(int)) { 
                context.Entry(entity).State = EntityState.Added; }
            else { context.Entry(entity).State = EntityState.Modified; }
            context.SaveChanges();
        }
        public void DeleteQuestion(int id)//метод удаления вопроса из БД по id
        {
            context.Questions.Remove(new Question() { Id = id });
            context.SaveChanges();
        }
    }
}
