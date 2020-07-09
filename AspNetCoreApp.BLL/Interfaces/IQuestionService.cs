using AspNetCoreApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreApp.BLL.Interfaces
{
    public interface IQuestionService
    {
        Task Create(Question question);
        Task Delete(int id);
        Task Edit(Question question);
        Task<Question> Get(int id);
        Task<List<Question>> GetAll();
        Task<Question> GetByTelegramId(string telegId);
        Task<Question> GetByUserName(string userName);
        Task<List<Question>> GetByPresentation(int presentationId);
        bool QuestionExists(int questionId);
    }
}
