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
    public class NewsContentManager : INewsContentManager
    {
        private readonly INewsContentRepository _iNewsContentRepository;
        private readonly IMapper _iMapper;

        public NewsContentManager(INewsContentRepository iNewsContentRepository, IMapper iMapper)
        {
            _iNewsContentRepository = iNewsContentRepository;
            _iMapper = iMapper;
        }

        public async Task<NewsContentViewModel> GetNewsContentAsync(int id)
        {
            try
            {
                var data = await _iNewsContentRepository.GetNewsContentAsync(id);
                return _iMapper.Map<News, NewsContentViewModel>(data);
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
                var modelList = await _iNewsContentRepository.GetNewsContentAsync();
                var viewModelList = _iMapper.Map<IEnumerable<News>, IEnumerable<NewsContentViewModel>>(modelList);

                // Global filtering.
                // Filter is being manually applied due to in-memmory (IEnumerable) data.
                // If you want something rather easier, check IEnumerableExtensions Sample.

                int dataCount = viewModelList.Count();
                int filteredDataCount = 0;
                IEnumerable<NewsContentViewModel> dataPage;
                if (viewModelList.Count() > 0 && request != null)
                {
                    var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                    ? viewModelList
                    : viewModelList.Where(_item => _item.NewsTitle.Contains(request.Search.Value));

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

        public async Task<IEnumerable<NewsContentViewModel>> GetNewsContentAsync()
        {
            try
            {
                var data = await _iNewsContentRepository.GetNewsContentAsync();
                return _iMapper.Map<IEnumerable<News>, IEnumerable<NewsContentViewModel>>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> InsertOrUpdatetNewsContentAsync(NewsContentViewModel model)
        {
            var data = _iMapper.Map<NewsContentViewModel, News>(model);
            return await _iNewsContentRepository.InsertOrUpdatetNewsContentAsync(data);
        }

        public async Task<Result> InsertNewsContentAsync(NewsContentViewModel model)
        {
            try
            {
                var data = _iMapper.Map<NewsContentViewModel, News>(model);

                var saveChange = await _iNewsContentRepository.InsertNewsContentAsync(data);

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

        public async Task<Result> UpdateNewsContentAsync(NewsContentViewModel model)
        {
            try
            {
                var data = _iMapper.Map<NewsContentViewModel, News>(model);

                var saveChange = await _iNewsContentRepository.UpdateNewsContentAsync(data);

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

        public async Task<Result> DeleteNewsContentAsync(int id)
        {
            try
            {
                var model = await GetNewsContentAsync(id);
                if (model != null)
                {
                    var data = _iMapper.Map<NewsContentViewModel, News>(model);

                    var saveChange = await _iNewsContentRepository.DeleteNewsContentAsync(data);

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
    }

    public interface INewsContentManager
    {
        Task<NewsContentViewModel> GetNewsContentAsync(int id);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<NewsContentViewModel>> GetNewsContentAsync();
        Task<int> InsertOrUpdatetNewsContentAsync(NewsContentViewModel model);
        Task<Result> InsertNewsContentAsync(NewsContentViewModel model);
        Task<Result> UpdateNewsContentAsync(NewsContentViewModel model);
        Task<Result> DeleteNewsContentAsync(int id);
    }
}
