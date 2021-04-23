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
    public class SocialMediaConfigManager : ISocialMediaConfigManager
    {
        private readonly ISocialMediaConfigRepository _iSocialMediaConfigRepository;
        private readonly IMapper _iMapper;

        public SocialMediaConfigManager(ISocialMediaConfigRepository iSocialMediaConfigRepository, IMapper iMapper)
        {
            _iSocialMediaConfigRepository = iSocialMediaConfigRepository;
            _iMapper = iMapper;
        }

        public async Task<SocialMediaConfigViewModel> GetSocialMediaConfigAsync()
        {
            try
            {
                var dataList = await _iSocialMediaConfigRepository.GetSocialMediaConfigsAsync();
                var data = dataList.FirstOrDefault();
                return _iMapper.Map<SocialMediaConfig, SocialMediaConfigViewModel>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SocialMediaConfigViewModel> GetSocialMediaConfigAsync(int id)
        {
            try
            {
                var data = await _iSocialMediaConfigRepository.GetSocialMediaConfigAsync(id);
                return _iMapper.Map<SocialMediaConfig, SocialMediaConfigViewModel>(data);
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
                var modelList = await _iSocialMediaConfigRepository.GetSocialMediaConfigsAsync();
                var viewModelList = _iMapper.Map<IEnumerable<SocialMediaConfig>, IEnumerable<SocialMediaConfigViewModel>>(modelList);

                // Global filtering.
                // Filter is being manually applied due to in-memmory (IEnumerable) data.
                // If you want something rather easier, check IEnumerableExtensions Sample.

                int dataCount = viewModelList.Count();
                int filteredDataCount = 0;
                IEnumerable<SocialMediaConfigViewModel> dataPage;
                if (viewModelList.Count() > 0 && request != null)
                {
                    var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                    ? viewModelList
                    : viewModelList.Where(_item => _item.FacebookUrl.Contains(request.Search.Value));

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

        public async Task<IEnumerable<SocialMediaConfigViewModel>> GetSocialMediaConfigsAsync()
        {
            try
            {
                var data = await _iSocialMediaConfigRepository.GetSocialMediaConfigsAsync();
                return _iMapper.Map<IEnumerable<SocialMediaConfig>, IEnumerable<SocialMediaConfigViewModel>>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> InsertOrUpdatetSocialMediaAsync(SocialMediaConfigViewModel model)
        {
            var data = _iMapper.Map<SocialMediaConfigViewModel, SocialMediaConfig>(model);
            return await _iSocialMediaConfigRepository.InsertOrUpdatetSocialMediaConfigAsync(data);
        }

        public async Task<Result> InsertSocialMediaConfigAsync(SocialMediaConfigViewModel model)
        {
            try
            {
                var data = _iMapper.Map<SocialMediaConfigViewModel, SocialMediaConfig>(model);

                var saveChange = await _iSocialMediaConfigRepository.InsertSocialMediaConfigAsync(data);

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

        public async Task<Result> UpdateSocialMediaConfigAsync(SocialMediaConfigViewModel model)
        {
            try
            {
                var data = _iMapper.Map<SocialMediaConfigViewModel, SocialMediaConfig>(model);

                var saveChange = await _iSocialMediaConfigRepository.UpdateSocialMediaConfigAsync(data);

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

        public async Task<Result> DeleteSocialMediaConfigAsync(int id)
        {
            try
            {
                var model = await GetSocialMediaConfigAsync(id);
                if (model != null)
                {
                    var data = _iMapper.Map<SocialMediaConfigViewModel, SocialMediaConfig>(model);

                    var saveChange = await _iSocialMediaConfigRepository.DeleteSocialMediaConfigAsync(data);

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

    public interface ISocialMediaConfigManager
    {
        Task<SocialMediaConfigViewModel> GetSocialMediaConfigAsync();
        Task<SocialMediaConfigViewModel> GetSocialMediaConfigAsync(int id);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<SocialMediaConfigViewModel>> GetSocialMediaConfigsAsync();
        Task<int> InsertOrUpdatetSocialMediaAsync(SocialMediaConfigViewModel model);
        Task<Result> InsertSocialMediaConfigAsync(SocialMediaConfigViewModel model);
        Task<Result> UpdateSocialMediaConfigAsync(SocialMediaConfigViewModel model);
        Task<Result> DeleteSocialMediaConfigAsync(int id);
    }
}
