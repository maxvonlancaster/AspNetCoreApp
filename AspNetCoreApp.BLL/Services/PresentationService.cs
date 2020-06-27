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
    public class PresentationService : IPresentationService
    {
        private readonly PresentationContext _context;

        public PresentationService(PresentationContext context)
        {
            _context = context;
        }

        public async Task Create(Presentation presentation)
        {
            _context.Add(presentation);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var presentation = await _context.Presentations.FindAsync(id);
            _context.Presentations.Remove(presentation);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Presentation presentation)
        {
            _context.Update(presentation);
            await _context.SaveChangesAsync();
            throw new NotImplementedException();
        }

        public async Task<Presentation> Get(int id)
        {
            var presentation = await _context.Presentations.FirstOrDefaultAsync(p => p.Id == id);
            return presentation;
        }

        public async Task<List<Presentation>> GetList(int take, int skip, string userName)
        {
            var list = await _context.Presentations.Where(p => p.User.UserName == userName)
                .Select(p => new Presentation()
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .OrderBy(p => p.Name)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
            return list;
        }

        public async Task<Presentation> GetByTelegramId(string telegId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Presentation>> GetByUser(int userId)
        {
            var presentations = await _context.Presentations.Where(p => p.User.Id == userId).ToListAsync();
            return presentations;
        }

        public bool PresentationExists(string postId)
        {
            throw new NotImplementedException();
        }
    }
}
