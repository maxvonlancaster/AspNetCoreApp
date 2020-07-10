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
    public class UserService : IUserService
    {
        private readonly PresentationContext _context;

        public UserService(PresentationContext context)
        {
            _context = context;
        }

        public async Task Create(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        //public async Task<User> Get(int id)
        //{
        //    var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
        //    return user;
        //}

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByCredentials(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Password == password && u.UserName == userName);
            return user;
        }

        public async Task<User> GetByTelegramId(string telegId)
        {
            return await _context.Users.FirstOrDefaultAsync(m => m.TelegramId == telegId);
        }

        public async Task<User> GetByUserName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(m => m.UserName == userName);
        }

        public bool UserExists(string telegId)
        {
            return _context.Users.Any(e => e.TelegramId == telegId);
        }

        // Also add method to get 10 users sorted
    }
}
