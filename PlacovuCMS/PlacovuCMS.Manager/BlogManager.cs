using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
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
    public class BlogManager : IBlogManager
    {
        private readonly IBlogRepository _iBlogRepository;
        private readonly ICommonSpAccessRepository _iCommonSpAccessRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IMapper _iMapper;

        public BlogManager(IBlogRepository iBlogRepository, ICommonSpAccessRepository commonSpAccessRepository, IMapper iMapper, IMediaRepository mediaRepository)
        {
            _iBlogRepository = iBlogRepository;
            _iCommonSpAccessRepository = commonSpAccessRepository;
            _iMapper = iMapper;
            _mediaRepository = mediaRepository;
        }

        public async Task<BlogViewModel> GetBlogAsync(int id)
        {
            try
            {
                Blog blog = new Blog();
                blog = await _iBlogRepository.GetBlogAsync(id);
                blog.PrimaryImageUrl = "/default/images/default-addphoto-image.jpg";
                if (blog.PrimaryImageId.HasValue)
                {
                    var media = await _mediaRepository.GetMediaByPrimaryImageId(blog.PrimaryImageId.Value);
                    if(media != null)
                    {
                        blog.PrimaryImageUrl = "/" + media.Url;
                    }
                }
                //blog.PrimaryImageUrl = blog.PrimaryImageId != null ? "/" + media.Where(x => x.Id == blog.PrimaryImageId).Select(x => x.Url).FirstOrDefault() : "/default/images/default-addphoto-image.jpg";
                
                return _iMapper.Map<Blog, BlogViewModel>(blog);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<BlogViewModel> GetBlogByUrlAsync(string url)
        {
            try
            {
                Blog blog = new Blog();
                blog = await _iBlogRepository.GetBlogByUrlAsync(url);
                blog.PrimaryImageUrl = "/default/images/default-image.png";
                if (blog.PrimaryImageId.HasValue)
                {
                    var media = await _mediaRepository.GetMediaByPrimaryImageId(blog.PrimaryImageId.Value);
                    if (media != null)
                    {
                        blog.PrimaryImageUrl = "/" + media.Url;
                    }
                }
                return _iMapper.Map<Blog, BlogViewModel>(blog);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BlogList> GetBlogListAsync(int? page, string searchText, int? status)
        {
            int pageSize = 3;
            int pageNo = page == null ? 1 : Convert.ToInt32(page);

            //int total;
            //using (var context = new CMSEntities())
            //{
            //    total = context.Blogs.Where(x => x.Name == (searchText == null ? x.Name : searchText) && x.Status == (status == null ? x.Status : (status == 1 ? true : false))).Count();
            //}

            var skip = pageSize * (Convert.ToInt32(pageNo) - 1);
            //var canPage = skip < total;

            BlogList bList = new BlogList();
            //if (canPage)
            //{
            var result = await _iBlogRepository.GetBlogsAsync(pageSize, skip, searchText, status);

            int total = await _iBlogRepository.GetTotalBlogsAsync(searchText, status);

            PagingInfo pagingInfo = new PagingInfo();
            pagingInfo.CurrentPage = pageNo;
            pagingInfo.TotalItems = total;
            pagingInfo.ItemsPerPage = pageSize;

            bList.blog = result;
            bList.allTotal = await _iBlogRepository.GetTotalBlogsAsync();
            bList.activeTotal = await _iBlogRepository.GetTotalActiveBlogsAsync();
            bList.inactiveTotal = await _iBlogRepository.GetTotalInactiveBlogsAsync();
            bList.searchText = searchText;
            bList.status = status;
            bList.pagingInfo = pagingInfo;
            //}
            return bList;
        }

        public async Task<Result> AddOrEdit(BlogViewModel blogViewModel, int? id, string url)
        {
            try
            {
                var blog = _iMapper.Map<BlogViewModel, Blog>(blogViewModel);

                blog.Url = await _iCommonSpAccessRepository.GetUrl(id, url);
                if(id != null)
                {
                    var blogResult = await _iBlogRepository.GetBlogAsync(id.Value);
                    blogResult.Name = blog.Name;
                    blogResult.Url = blog.Url;
                    blogResult.CategoryId = blog.CategoryId;
                    blogResult.PrimaryImageId = blog.PrimaryImageId;
                    blogResult.Description = blog.Description;
                    blogResult.MetaTitle = blog.MetaTitle;
                    blogResult.MetaKeyword = blog.MetaKeyword;
                    blogResult.MetaDescription = blog.MetaDescription;
                    blogResult.Status = blog.Status;

                    int saveChange = await _iBlogRepository.InsertOrUpdatetBlogAsync(blogResult);
                    if (saveChange > 0)
                    {
                        return Result.Ok(MessageHelper.Update);
                    }
                    else
                    {
                        return Result.Fail(MessageHelper.UpdateFail);
                    }
                }
                else
                {
                    int saveChange = await _iBlogRepository.InsertOrUpdatetBlogAsync(blog);
                    if (saveChange > 0)
                    {
                        return Result.Ok(MessageHelper.Save);
                    }
                    else
                    {
                        return Result.Fail(MessageHelper.SaveFail);
                    }
                }

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
                var modelList = await _iBlogRepository.GetBlogsAsync();
                var viewModelList = _iMapper.Map<IEnumerable<Blog>, IEnumerable<BlogViewModel>>(modelList);

                // Global filtering.
                // Filter is being manually applied due to in-memmory (IEnumerable) data.
                // If you want something rather easier, check IEnumerableExtensions Sample.

                int dataCount = viewModelList.Count();
                int filteredDataCount = 0;
                IEnumerable<BlogViewModel> dataPage;
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

        public async Task<IEnumerable<BlogViewModel>> GetBlogsAsync()
        {
            try
            {
                var data = await _iBlogRepository.GetBlogsAsync();

                foreach (var blog in data)
                {
                    blog.PrimaryImageUrl = "/default/images/default-image.png";
                    if (blog.PrimaryImageId.HasValue)
                    {
                        var media = await _mediaRepository.GetMediaByPrimaryImageId(blog.PrimaryImageId.Value);
                        if (media != null)
                        {
                            blog.PrimaryImageUrl = "/" + media.Url;
                        }
                    }
                    //blog.PrimaryImageUrl = blog.PrimaryImageId != null ? "/" + context.Media.Where(x => x.Id == blog.PrimaryImageId).Select(x => x.Url).FirstOrDefault() : "/default/images/default-addphoto-image.jpg";
                }
                return _iMapper.Map<IEnumerable<Blog>, IEnumerable<BlogViewModel>>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> InsertOrUpdatetBlogAsync(BlogViewModel model)
        {
            var data = _iMapper.Map<BlogViewModel, Blog>(model);
            return await _iBlogRepository.InsertOrUpdatetBlogAsync(data);
        }

        public async Task<Result> InsertBlogAsync(BlogViewModel model)
        {
            try
            {
                var data = _iMapper.Map<BlogViewModel, Blog>(model);

                var saveChange = await _iBlogRepository.InsertBlogAsync(data);

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

        public async Task<Result> UpdateBlogAsync(BlogViewModel model)
        {
            try
            {
                var data = _iMapper.Map<BlogViewModel, Blog>(model);

                var saveChange = await _iBlogRepository.UpdateBlogAsync(data);

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

        public async Task<Result> DeleteBlogAsync(int id)
        {
            try
            {
                var viewModel = await GetBlogAsync(id);
                var model = _iMapper.Map<BlogViewModel, Blog>(viewModel);
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
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Media>> GetMediaWithPagingForBlog(string date, int page, string name)
        {
            try
            {
                var result = await _iCommonSpAccessRepository.GetMediaWithPagingForBlog(date, page, name);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public interface IBlogManager
    {
        Task<BlogViewModel> GetBlogAsync(int id);
        Task<BlogViewModel> GetBlogByUrlAsync(string url);
        Task<BlogList> GetBlogListAsync(int? page, string searchText, int? status);
        Task<Result> AddOrEdit(BlogViewModel blogViewModel, int? id, string url);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<BlogViewModel>> GetBlogsAsync();
        Task<int> InsertOrUpdatetBlogAsync(BlogViewModel model);
        Task<Result> InsertBlogAsync(BlogViewModel model);
        Task<Result> UpdateBlogAsync(BlogViewModel model);
        Task<Result> DeleteBlogAsync(int id);
        Task<List<Media>> GetMediaWithPagingForBlog(string date, int page, string name);
    }
}
