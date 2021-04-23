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
    public class SiteInfoManager : ISiteInfoManager
    {
        private readonly ISiteInfoRepository _iSiteInfoRepository;
        private readonly IMapper _iMapper;

        public SiteInfoManager(ISiteInfoRepository iSiteInfoRepository, IMapper iMapper)
        {
            _iSiteInfoRepository = iSiteInfoRepository;
            _iMapper = iMapper;
        }

        public async Task<string> GetSitePhoneNumberAsync()
        {
            try
            {
                var dataList = await _iSiteInfoRepository.GetSiteInfosAsync();
                var data = dataList.FirstOrDefault();
                string dataStr = "";
                if (data != null)
                {
                    dataStr = data.SitePhoneNumber;
                }
                return dataStr;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> GetSiteLogoUrlAsync()
        {
            try
            {
                var dataList = await _iSiteInfoRepository.GetSiteInfosAsync();
                var data = dataList.FirstOrDefault();
                string dataStr = "";
                if (data != null)
                {
                    dataStr = data.SiteLogoUrl;
                }
                return dataStr;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SiteInfoViewModel> GetSiteInfoAsync()
        {
            try
            {
                var dataList = await _iSiteInfoRepository.GetSiteInfosAsync();
                var data = dataList.FirstOrDefault();
                return _iMapper.Map<SiteInfo, SiteInfoViewModel>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SiteInfoViewModel> GetSiteInfoAsync(int id)
        {
            try
            {
                var data = await _iSiteInfoRepository.GetSiteInfoAsync(id);
                return _iMapper.Map<SiteInfo, SiteInfoViewModel>(data);
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
                var modelList = await _iSiteInfoRepository.GetSiteInfosAsync();
                var viewModelList = _iMapper.Map<IEnumerable<SiteInfo>, IEnumerable<SiteInfoViewModel>>(modelList);

                // Global filtering.
                // Filter is being manually applied due to in-memmory (IEnumerable) data.
                // If you want something rather easier, check IEnumerableExtensions Sample.

                int dataCount = viewModelList.Count();
                int filteredDataCount = 0;
                IEnumerable<SiteInfoViewModel> dataPage;
                if (viewModelList.Count() > 0 && request != null)
                {
                    var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                    ? viewModelList
                    : viewModelList.Where(_item => _item.SiteTitle.Contains(request.Search.Value));

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

        public async Task<IEnumerable<SiteInfoViewModel>> GetSiteInfosAsync()
        {
            try
            {
                var data = await _iSiteInfoRepository.GetSiteInfosAsync();
                return _iMapper.Map<IEnumerable<SiteInfo>, IEnumerable<SiteInfoViewModel>>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> InsertOrUpdatetSiteInfoAsync(SiteInfoViewModel model)
        {
            var data = _iMapper.Map<SiteInfoViewModel, SiteInfo>(model);
            return await _iSiteInfoRepository.InsertOrUpdatetSiteInfoAsync(data);
        }

        public async Task<Result> InsertSiteInfoAsync(SiteInfoViewModel model)
        {
            try
            {
                var data = _iMapper.Map<SiteInfoViewModel, SiteInfo>(model);

                var saveChange = await _iSiteInfoRepository.InsertSiteInfoAsync(data);

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

        public async Task<Result> UpdateSiteInfoAsync(SiteInfoViewModel model)
        {
            try
            {
                var data = _iMapper.Map<SiteInfoViewModel, SiteInfo>(model);

                var saveChange = await _iSiteInfoRepository.UpdateSiteInfoAsync(data);

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

        public async Task<Result> DeleteSiteInfoAsync(int id)
        {
            try
            {
                var model = await GetSiteInfoAsync(id);
                if (model != null)
                {
                    var data = _iMapper.Map<SiteInfoViewModel, SiteInfo>(model);

                    var saveChange = await _iSiteInfoRepository.DeleteSiteInfoAsync(data);

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

    public interface ISiteInfoManager
    {
        Task<string> GetSitePhoneNumberAsync();
        Task<string> GetSiteLogoUrlAsync();
        Task<SiteInfoViewModel> GetSiteInfoAsync();
        Task<SiteInfoViewModel> GetSiteInfoAsync(int id);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<SiteInfoViewModel>> GetSiteInfosAsync();
        Task<int> InsertOrUpdatetSiteInfoAsync(SiteInfoViewModel model);
        Task<Result> InsertSiteInfoAsync(SiteInfoViewModel model);
        Task<Result> UpdateSiteInfoAsync(SiteInfoViewModel model);
        Task<Result> DeleteSiteInfoAsync(int id);
    }
}
