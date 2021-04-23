using Microsoft.EntityFrameworkCore;
using PlacovuCMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacovuCMS.Repository
{
    public class PageRepository : IPageRepository
    {
        private AppDbContext _context;
        public PageRepository()
        {
            _context = new AppDbContext();
        }
        public PageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Page> GetPageAsync(int id)
        {
            return await _context.Page.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Page> GetPageByNameAsync(string name)
        {
            return await _context.Page.AsNoTracking().SingleOrDefaultAsync(x => x.Name == name);
        }
        public async Task<Page> GetPageByUrlAsync(string url)
        {
            return await _context.Page.AsNoTracking().SingleOrDefaultAsync(x => x.Url == url);
        }
        public async Task<IEnumerable<Page>> GetPagesAsync()
        {
            return await _context.Page.AsNoTracking().ToListAsync();
        }

        public async Task<int> InsertOrUpdatetPageAsync(Page model)
        {
            if (model.Id == 0)
            {
                await _context.Page.AddAsync(model);
            }
            else
            {
                _context.Page.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertPageAsync(Page model)
        {
            try
            {
                if (model.Id == 0)
                {
                    await _context.Page.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdatePageAsync(Page model)
        {
            if (model.Id > 0)
            {
                _context.Page.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeletePageAsync(Page model)
        {
            if (model.Id > 0)
            {
                _context.Page.Remove(model);
            }
            return await _context.SaveChangesAsync();
        }
    }

    public interface IPageRepository
    {
        Task<Page> GetPageAsync(int id);
        Task<Page> GetPageByNameAsync(string name);
        Task<Page> GetPageByUrlAsync(string url);
        Task<IEnumerable<Page>> GetPagesAsync();
        Task<int> InsertOrUpdatetPageAsync(Page model);
        Task<int> InsertPageAsync(Page model);
        Task<int> UpdatePageAsync(Page model);
        Task<int> DeletePageAsync(Page model);
    }
}
