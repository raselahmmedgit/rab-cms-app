using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CMS.App.Models;

namespace CMS.App.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private AppDbContext _context;
        public BlogRepository()
        {
            _context = new AppDbContext();
        }
        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Blog> GetBlogAsync(int id)
        {
            return await _context.Blog.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Blog>> GetBlogsAsync()
        {
            return await _context.Blog.ToListAsync();
        }

        public async Task<int> InsertOrUpdatetBlogAsync(Blog model)
        {
            if (model.Id == 0)
            {
                await _context.Blog.AddAsync(model);
            }
            else
            {
                _context.Blog.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertBlogAsync(Blog model)
        {
            try
            {
                if (model.Id == 0)
                {
                    await _context.Blog.AddAsync(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateBlogAsync(Blog model)
        {
            if (model.Id > 0)
            {
                _context.Blog.Update(model);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteBlogAsync(Blog model)
        {
            if (model.Id > 0)
            {
                _context.Blog.Remove(model);
            }
            return await _context.SaveChangesAsync();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
