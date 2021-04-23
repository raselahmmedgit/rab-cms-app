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
    public class PageManager : IPageManager
    {
        private readonly IPageRepository _iPageRepository;
        private readonly IMapper _iMapper;

        public PageManager(IPageRepository iPageRepository, IMapper iMapper)
        {
            _iPageRepository = iPageRepository;
            _iMapper = iMapper;
        }

        public async Task<PageViewModel> GetPageAsync(int id)
        {
            try
            {
                var data = await _iPageRepository.GetPageAsync(id);
                return _iMapper.Map<Page, PageViewModel>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PageViewModel> GetPageByNameAsync(string name)
        {
            try
            {
                var data = await _iPageRepository.GetPageByNameAsync(name);
                return _iMapper.Map<Page, PageViewModel>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PageViewModel> GetPageByUrlAsync(string url)
        {
            try
            {
                var data = await _iPageRepository.GetPageByUrlAsync(url);
                return _iMapper.Map<Page, PageViewModel>(data);
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
                var modelList = await _iPageRepository.GetPagesAsync();
                var viewModelList = _iMapper.Map<IEnumerable<Page>, IEnumerable<PageViewModel>>(modelList);

                // Global filtering.
                // Filter is being manually applied due to in-memmory (IEnumerable) data.
                // If you want something rather easier, check IEnumerableExtensions Sample.

                int dataCount = viewModelList.Count();
                int filteredDataCount = 0;
                IEnumerable<PageViewModel> dataPage;
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

        public async Task<IEnumerable<PageViewModel>> GetPagesAsync()
        {
            try
            {
                var data = await _iPageRepository.GetPagesAsync();
                return _iMapper.Map<IEnumerable<Page>, IEnumerable<PageViewModel>>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> InsertOrUpdatetPageAsync(PageViewModel model)
        {
            var data = _iMapper.Map<PageViewModel, Page>(model);
            return await _iPageRepository.InsertOrUpdatetPageAsync(data);
        }

        public async Task<Result> InsertPageAsync(PageViewModel model)
        {
            try
            {
                var data = _iMapper.Map<PageViewModel, Page>(model);

                var saveChange = await _iPageRepository.InsertPageAsync(data);

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

        public async Task<Result> UpdatePageAsync(PageViewModel model)
        {
            try
            {
                var data = _iMapper.Map<PageViewModel, Page>(model);

                var saveChange = await _iPageRepository.UpdatePageAsync(data);

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

        public async Task<Result> DeletePageAsync(int id)
        {
            try
            {
                var data = await _iPageRepository.GetPageAsync(id);
                if (data != null)
                {
                    var saveChange = await _iPageRepository.DeletePageAsync(data);

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

    public interface IPageManager
    {
        Task<PageViewModel> GetPageAsync(int id);
        Task<PageViewModel> GetPageByNameAsync(string name);
        Task<PageViewModel> GetPageByUrlAsync(string name);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<PageViewModel>> GetPagesAsync();
        Task<int> InsertOrUpdatetPageAsync(PageViewModel model);
        Task<Result> InsertPageAsync(PageViewModel model);
        Task<Result> UpdatePageAsync(PageViewModel model);
        Task<Result> DeletePageAsync(int id);
    }
}
