using AspNetCoreApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreApp.BLL.Interfaces
{
    public interface IUserService
    {
        Task Create(User user);
        Task Delete(int id);
        Task Edit(User user);
        Task<User> Get(int id);
        Task<User> GetByCredentials(string userName, string password);
        Task<List<User>> GetAll();
        Task<User> GetByTelegramId(string telegId);
        Task<User> GetByUserName(string userName);
        bool UserExists(string telegId);
    }
}
