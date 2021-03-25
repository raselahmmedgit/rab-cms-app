using CMS.App.Core;
using CMS.App.Helpers;
using CMS.App.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.App.Repository;

namespace CMS.App.Manager
{
    public class BlogManager : IBlogManager
    {
        private readonly IBlogRepository _iBlogRepository;

        public BlogManager(IBlogRepository iBlogRepository)
        {
            _iBlogRepository = iBlogRepository;
        }

        public async Task<Blog> GetBlogAsync(int id)
        {
            var data = await _iBlogRepository.GetBlogAsync(id);
            return data;
        }

        public async Task<IEnumerable<Blog>> GetBlogsAsync()
        {
            var data = await _iBlogRepository.GetBlogsAsync();
            return data;
        }

        public async Task<int> InsertOrUpdatetBlogAsync(Blog model)
        {
            return await _iBlogRepository.InsertOrUpdatetBlogAsync(model);
        }

        public async Task<Result> InsertBlogAsync(Blog model)
        {
            try
            {
                var saveChange = await _iBlogRepository.InsertBlogAsync(model);

                if (saveChange > 0)
                {
                    return Result.Ok(MessageHelper.Save);
                }
                else
                {
                    return Result.Fail(MessageHelper.SaveFail);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Result> UpdateBlogAsync(Blog model)
        {
            var saveChange = await _iBlogRepository.UpdateBlogAsync(model);

            if (saveChange > 0)
            {
                return Result.Ok(MessageHelper.Update);
            }
            else
            {
                return Result.Fail(MessageHelper.UpdateFail);
            }
        }

        public async Task<Result> DeleteBlogAsync(int id)
        {
            var model = await GetBlogAsync(id);
            if (model != null)
            {
                var saveChange = await _iBlogRepository.DeleteBlogAsync(model);

                if (saveChange > 0)
                {
                    return Result.Ok(MessageHelper.Delete);
                }
                else
                {
                    return Result.Fail(MessageHelper.DeleteFail);
                }
            }
            else
            {
                return Result.Fail(MessageHelper.DeleteFail);
            }

        }
    }
}
