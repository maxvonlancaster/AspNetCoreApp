using AspNetCoreApp.BLL.Interfaces;
using AspNetCoreApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreApp.BLL.Services
{
    public class PostService : IPostService
    {
        private readonly PresentationContext _context;

        public PostService(PresentationContext context)
        {
            _context = context;
        }

        public async Task Create(Post post)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Edit(Post post)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Post>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Post> GetByTelegramId(string telegId)
        {
            throw new NotImplementedException();
        }

        public bool PostExists(string postId)
        {
            throw new NotImplementedException();
        }
    }
}
