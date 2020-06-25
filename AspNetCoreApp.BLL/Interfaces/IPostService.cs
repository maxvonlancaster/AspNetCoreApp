using AspNetCoreApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreApp.BLL.Interfaces
{
    public interface IPostService
    {
        Task Create(Post post);
        Task Delete(int id);
        Task Edit(Post post);
        Task<Post> Get(int id);
        Task<List<Post>> GetAll();
        Task<Post> GetByTelegramId(string telegId);
        bool PostExists(string postId);
    }
}
