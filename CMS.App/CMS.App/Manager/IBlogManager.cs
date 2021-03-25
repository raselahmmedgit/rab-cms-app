using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.App.Core;
using CMS.App.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace CMS.App.Manager
{
    public interface IBlogManager
    {
        Task<Blog> GetBlogAsync(int id);
        Task<IEnumerable<Blog>> GetBlogsAsync();
        Task<int> InsertOrUpdatetBlogAsync(Blog model);
        Task<Result> InsertBlogAsync(Blog model);
        Task<Result> UpdateBlogAsync(Blog model);
        Task<Result> DeleteBlogAsync(int id);
    }
}
