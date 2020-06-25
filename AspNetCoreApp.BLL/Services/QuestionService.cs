using AspNetCoreApp.BLL.Interfaces;
using AspNetCoreApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreApp.BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly PresentationContext _context;

        public QuestionService(PresentationContext context)
        {
            _context = context;
        }

        public async Task Create(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Question question)
        {
            _context.Update(question);
            await _context.SaveChangesAsync();
        }

        public async Task<Question> Get(int id)
        {
            var question = await _context.Questions.FirstOrDefaultAsync(q => q.Id == id);
            return question;
        }

        public async Task<List<Question>> GetAll()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<List<Question>> GetByPresentation(int presentationId)
        {
            var questions = await _context.Questions.Where(q => q.Presentation.Id == presentationId).ToListAsync();
            return questions;
        }

        public async Task<Question> GetByTelegramId(string telegId)
        {
            throw new NotImplementedException();
        }

        public async Task<Question> GetByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public bool QuestionExists(string questionId)
        {
            throw new NotImplementedException();
        }
    }
}
