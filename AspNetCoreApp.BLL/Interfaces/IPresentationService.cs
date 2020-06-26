using AspNetCoreApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreApp.BLL.Interfaces
{
    public interface IPresentationService
    {
        Task Create(Presentation presentation);
        Task Delete(int id);
        Task Edit(Presentation presentation);
        Task<Presentation> Get(int id);
        Task<List<Presentation>> GetList(int take, int skip, string userName);
        Task<Presentation> GetByTelegramId(string telegId);
        Task<List<Presentation>> GetByUser(int userId);

        bool PresentationExists(string postId);
    }
}
