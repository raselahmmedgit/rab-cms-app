using Microsoft.EntityFrameworkCore;
using PlacovuCMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacovuCMS.Repository
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
            try
            {
                Blog blog = null;
                using (var context = new AppDbContext())
                {
                    blog = await context.Blog.FirstOrDefaultAsync(x => x.Id == id);
                }
                return blog;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<Blog> GetBlogByUrlAsync(string url)
        {
            try
            {
                Blog blog = null;
                using (var context = new AppDbContext())
                {
                    blog = await context.Blog.FirstOrDefaultAsync(x => x.Url == url);
                }
                return blog;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<IEnumerable<Blog>> GetBlogsAsync()
        {
            try
            {
                IEnumerable<Blog> bloglist = null;
                using (var context = new AppDbContext())
                {
                    bloglist = await context.Blog.ToListAsync();
                }
                return bloglist;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<IEnumerable<Blog>> GetBlogsAsync(int pageSize, int skip, string searchText, int? status)
        {
            try
            {
                return await _context.Blog.Where(x => x.Status == (status == null ? x.Status : (status == 1 ? true : false)) && x.Name.Contains(searchText == null ? x.Name : searchText)).OrderByDescending(x => x.Id).Skip(skip).Take(pageSize).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<int> GetTotalBlogsAsync()
        {
            try
            {
                return await _context.Blog.CountAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<int> GetTotalBlogsAsync(string searchText, int? status)
        {
            try
            {
                return await _context.Blog.Where(x => x.Status == (status == null ? x.Status : (status == 1 ? true : false)) && x.Name.Contains(searchText == null ? x.Name : searchText)).CountAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<int> GetTotalActiveBlogsAsync()
        {
            try
            {
                return await _context.Blog.Where(x => x.Status == true).CountAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<int> GetTotalInactiveBlogsAsync()
        {
            try
            {
                return await _context.Blog.Where(x => x.Status == false).CountAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<int> InsertOrUpdatetBlogAsync(Blog model)
        {
            int result = 0;
            using (AppDbContext context = new AppDbContext())
            {
                if (model.Id == 0)
                {
                    await context.Blog.AddAsync(model);
                }
                else
                {
                    context.Blog.Update(model);
                }
                result =  await context.SaveChangesAsync();
            }
            return result;
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
    }

    public interface IBlogRepository
    {
        Task<Blog> GetBlogAsync(int id);

        Task<Blog> GetBlogByUrlAsync(string url);
        Task<IEnumerable<Blog>> GetBlogsAsync();
        Task<IEnumerable<Blog>> GetBlogsAsync(int pageSize, int skip, string searchText, int? status);
        Task<int> GetTotalBlogsAsync();
        Task<int> GetTotalBlogsAsync(string searchText, int? status);
        Task<int> GetTotalActiveBlogsAsync();
        Task<int> GetTotalInactiveBlogsAsync();
        Task<int> InsertOrUpdatetBlogAsync(Blog model);
        Task<int> InsertBlogAsync(Blog model);
        Task<int> UpdateBlogAsync(Blog model);
        Task<int> DeleteBlogAsync(Blog model);
    }
}
