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
        public IQueryable<Question> GetQuestions()
        {
            return context.Questions;
        }
        public Question GetQuestionById(int id)
        {
            return context.Questions.FirstOrDefault(x => x.Id == id);
        }
        public Question GetQuestionByTestId(int id)
        {
            return context.Questions.FirstOrDefault(e => e.TestId == id);
        }
        public void SaveQuestion(Question entity)
        {
            if (entity.Id == default(int)) { 
                context.Entry(entity).State = EntityState.Added; }
            else { context.Entry(entity).State = EntityState.Modified; }
            context.SaveChanges();
        }
        public void DeleteQuestion(int id)
        {
            context.Questions.Remove(new Question() { Id = id });
            context.SaveChanges();
        }
    }
}
