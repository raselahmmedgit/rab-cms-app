using Microsoft.EntityFrameworkCore;
using PlacovuCMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacovuCMS.Repository
{
    public class NewsContentRepository : INewsContentRepository
    {
        private AppDbContext _context;
        public NewsContentRepository()
        {
            _context = new AppDbContext();
        }
        public NewsContentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<News> GetNewsContentAsync(int id)
        {
            return await _context.News.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<News>> GetNewsContentAsync()
        {
            return await _context.News.ToListAsync();
        }

        public async Task<int> InsertOrUpdatetNewsContentAsync(News model)
        {
            
            if (model.Id == 0)
            {
                await _context.News.AddAsync(model);
            }
            else
            {
                _context.News.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertNewsContentAsync(News model)
        {
            try
            {
                if (model.Id == 0)
                {
                    await _context.News.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateNewsContentAsync(News model)
        {
            if (model.Id > 0)
            {
                _context.News.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteNewsContentAsync(News model)
        {
            if (model.Id > 0)
            {
                _context.News.Remove(model);
            }
            return await _context.SaveChangesAsync();
        }
    }

    public interface INewsContentRepository
    {
        Task<News> GetNewsContentAsync(int id);
        Task<IEnumerable<News>> GetNewsContentAsync();
        Task<int> InsertOrUpdatetNewsContentAsync(News model);
        Task<int> InsertNewsContentAsync(News model);
        Task<int> UpdateNewsContentAsync(News model);
        Task<int> DeleteNewsContentAsync(News model);
    }
}
