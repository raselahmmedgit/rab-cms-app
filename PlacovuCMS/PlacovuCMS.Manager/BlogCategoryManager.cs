using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlacovuCMS.Core.Helpers;
using PlacovuCMS.Model;
using PlacovuCMS.Repository;
using PlacovuCMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacovuCMS.Manager
{
    public class BlogCategoryManager : IBlogCategoryManager
    {
        private readonly IBlogCategoryRepository _iBlogCategoryRepository;
        private readonly ICommonSpAccessRepository _commonSpAccessRepository;
        private readonly IMapper _iMapper;

        public BlogCategoryManager(IBlogCategoryRepository iBlogCategoryRepository, ICommonSpAccessRepository commonSpAccessRepository
            , IMapper iMapper)
        {
            _iBlogCategoryRepository = iBlogCategoryRepository;
            _commonSpAccessRepository = commonSpAccessRepository;
            _iMapper = iMapper;
        }
        public async Task<BlogCategoryList> GetBlogCategoryList(int? page, string searchText, int? status)
        {
            try
            {
                return await _iBlogCategoryRepository.GetBlogCategoryList(page,searchText,status);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task<BlogCategoryViewModel> GetBlogCategoryAsync(int id)
        {
            try
            {
                var data = await _iBlogCategoryRepository.GetBlogCategoryAsync(id);
                return _iMapper.Map<BlogCategory, BlogCategoryViewModel>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BlogCategoryViewModel> GetBlogCategoryByUrlAsync(string url)
        {
            try
            {
                var data = await _iBlogCategoryRepository.GetBlogCategoryByUrlAsync(url);
                return _iMapper.Map<BlogCategory, BlogCategoryViewModel>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request)
        {
            try
            {
                var modelList = await _iBlogCategoryRepository.GetBlogCategorysAsync();
                var viewModelList = _iMapper.Map<IEnumerable<BlogCategory>, IEnumerable<BlogCategoryViewModel>>(modelList);

                // Global filtering.
                // Filter is being manually applied due to in-memmory (IEnumerable) data.
                // If you want something rather easier, check IEnumerableExtensions Sample.

                int dataCount = viewModelList.Count();
                int filteredDataCount = 0;
                IEnumerable<BlogCategoryViewModel> dataPage;
                if (viewModelList.Count() > 0 && request != null)
                {
                    var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                    ? viewModelList
                    : viewModelList.Where(_item => _item.Name.Contains(request.Search.Value));

                    dataCount = filteredData.Count();

                    // Paging filtered data.
                    // Paging is rather manual due to in-memmory (IEnumerable) data.
                    dataPage = filteredData.Skip(request.Start).Take(request.Length);

                    filteredDataCount = filteredData.Count();
                }
                else
                {
                    var filteredData = viewModelList;

                    dataCount = filteredData.Count();

                    dataPage = filteredData;

                    filteredDataCount = filteredData.Count();
                }

                // Response creation. To create your response you need to reference your request, to avoid
                // request/response tampering and to ensure response will be correctly created.
                var response = DataTablesResponse.Create(request, dataCount, filteredDataCount, dataPage);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<BlogCategoryViewModel>> GetBlogCategorysAsync()
        {
            try
            {
                var data = await _iBlogCategoryRepository.GetBlogCategorysAsync();
                return _iMapper.Map<IEnumerable<BlogCategory>, IEnumerable<BlogCategoryViewModel>>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> InsertOrUpdatetBlogCategoryAsync(BlogCategoryViewModel model)
        {
            var data = _iMapper.Map<BlogCategoryViewModel, BlogCategory>(model);
            return await _iBlogCategoryRepository.InsertOrUpdatetBlogCategoryAsync(data);
        }

        public async Task<Result> InsertBlogCategoryAsync(BlogCategoryViewModel model)
        {
            try
            {
                var data = _iMapper.Map<BlogCategoryViewModel, BlogCategory>(model);

                var saveChange = await _iBlogCategoryRepository.InsertBlogCategoryAsync(data);

                if (saveChange > 0)
                {
                    return Result.Ok(MessageHelper.Save);
                }
                else
                {
                    return Result.Fail(MessageHelper.SaveFail);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Result> UpdateBlogCategoryAsync(BlogCategoryViewModel model)
        {
            try
            {
                var data = _iMapper.Map<BlogCategoryViewModel, BlogCategory>(model);

                var saveChange = await _iBlogCategoryRepository.UpdateBlogCategoryAsync(data);

                if (saveChange > 0)
                {
                    return Result.Ok(MessageHelper.Update);
                }
                else
                {
                    return Result.Fail(MessageHelper.UpdateFail);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Result> DeleteBlogCategoryAsync(int id)
        {
            try
            {
                var viewModel = await GetBlogCategoryAsync(id);
                var model = _iMapper.Map<BlogCategoryViewModel, BlogCategory>(viewModel);
                if (model != null)
                {
                    var saveChange = await _iBlogCategoryRepository.DeleteBlogCategoryAsync(model);

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
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<List<SelectListItem>> GetActiveCategory()
        {
            try
            {
                return await _iBlogCategoryRepository.GetActiveCategory();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<Result> AddOrEdit(BlogCategoryViewModel blogCategoryViewModel, int? id, string blogCategoryUrl)
        {
            try
            {
                var blogCategory = _iMapper.Map<BlogCategoryViewModel, BlogCategory>(blogCategoryViewModel);

                blogCategory.ParentId = blogCategory.ParentId == 0 ? null : (int?)blogCategory.ParentId;
                blogCategory.Url = await _commonSpAccessRepository.GetUrl(id, blogCategoryUrl);
                if (id == null)
                {
                    var saveChange = await _iBlogCategoryRepository.InsertOrUpdatetBlogCategoryAsync(blogCategory);
                    if (saveChange > 0)
                    {
                        return Result.Ok(MessageHelper.Save);
                    }
                    else
                    {
                        return Result.Fail(MessageHelper.SaveFail);
                    }
                }
                else
                {
                    var category = await _iBlogCategoryRepository.GetBlogCategoryAsync(id.Value);
                    category.ParentId = blogCategory.ParentId;
                    category.Name = blogCategory.Name;
                    category.Url = blogCategory.Url;
                    category.MetaTitle = blogCategory.MetaTitle;
                    category.MetaKeyword = blogCategory.MetaKeyword;
                    category.MetaDescription = blogCategory.MetaDescription;
                    category.Description = blogCategory.Description;
                    category.Status = Convert.ToBoolean(blogCategory.Status);
                    var saveChange = await _iBlogCategoryRepository.InsertOrUpdatetBlogCategoryAsync(category);
                    if (saveChange > 0)
                    {
                        return Result.Ok(MessageHelper.Update);
                    }
                    else
                    {
                        return Result.Fail(MessageHelper.UpdateFail);
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }

    public interface IBlogCategoryManager
    {
        Task<BlogCategoryList> GetBlogCategoryList(int? page, string searchText, int? status);
        Task<BlogCategoryViewModel> GetBlogCategoryAsync(int id);
        Task<BlogCategoryViewModel> GetBlogCategoryByUrlAsync(string url);
        Task<Result> AddOrEdit(BlogCategoryViewModel blogCategoryViewModel, int? id, string blogCategoryUrl);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<BlogCategoryViewModel>> GetBlogCategorysAsync();
        Task<int> InsertOrUpdatetBlogCategoryAsync(BlogCategoryViewModel model);
        Task<Result> InsertBlogCategoryAsync(BlogCategoryViewModel model);
        Task<Result> UpdateBlogCategoryAsync(BlogCategoryViewModel model);
        Task<Result> DeleteBlogCategoryAsync(int id);
        Task<List<SelectListItem>> GetActiveCategory();
    }
}
