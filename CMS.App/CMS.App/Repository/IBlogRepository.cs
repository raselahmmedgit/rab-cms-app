using CMS.App.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.App.Repository
{
    public interface IBlogRepository : IDisposable
    {
        Task<Blog> GetBlogAsync(int id);
        Task<IEnumerable<Blog>> GetBlogsAsync();
        Task<int> InsertOrUpdatetBlogAsync(Blog model);
        Task<int> InsertBlogAsync(Blog model);
        Task<int> UpdateBlogAsync(Blog model);
        Task<int> DeleteBlogAsync(Blog model);
    }
}
