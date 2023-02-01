using Diplom.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Diplom.Domain.Repositories.Abstract
{
    public interface IQuestionRepository 
    {
        IQueryable<Question> GetQuestions();
        Question GetQuestionById(int id);
        Question GetQuestionByTestId(int id);
        void SaveQuestion(Question entity);
        void DeleteQuestion(int id);
        IQueryable<Question> GetQuestionsByTestId(int id);

	}
}
