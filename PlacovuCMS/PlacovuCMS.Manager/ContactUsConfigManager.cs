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
    public class ContactUsConfigManager : IContactUsConfigManager
    {
        private readonly IContactUsConfigRepository _iContactUsConfigRepository;
        private readonly IMapper _iMapper;

        public ContactUsConfigManager(IContactUsConfigRepository iContactUsConfigRepository, IMapper iMapper)
        {
            _iContactUsConfigRepository = iContactUsConfigRepository;
            _iMapper = iMapper;
        }

        public async Task<ContactUsConfigViewModel> GetContactUsConfigAsync(int id)
        {
            try
            {
                var data = await _iContactUsConfigRepository.GetContactUsConfigAsync(id);
                return _iMapper.Map<ContactUsConfig, ContactUsConfigViewModel>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ContactUsConfigViewModel> GetContactUsConfigFirstOrDefaultAsync()
        {
            var data = await _iContactUsConfigRepository.GetContactUsConfigFirstOrDefaultAsync();
            return _iMapper.Map<ContactUsConfig, ContactUsConfigViewModel>(data);
        }

        public async Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request)
        {
            try
            {
                var modelList = await _iContactUsConfigRepository.GetContactUsConfigsAsync();
                var viewModelList = _iMapper.Map<IEnumerable<ContactUsConfig>, IEnumerable<ContactUsConfigViewModel>>(modelList);

                // Global filtering.
                // Filter is being manually applied due to in-memmory (IEnumerable) data.
                // If you want something rather easier, check IEnumerableExtensions Sample.

                int dataCount = viewModelList.Count();
                int filteredDataCount = 0;
                IEnumerable<ContactUsConfigViewModel> dataPage;
                if (viewModelList.Count() > 0 && request != null)
                {
                    var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                    ? viewModelList
                    : viewModelList.Where(_item => _item.FromEmailAddressDisplayName.Contains(request.Search.Value));

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

        public async Task<IEnumerable<ContactUsConfigViewModel>> GetContactUsConfigsAsync()
        {
            try
            {
                var data = await _iContactUsConfigRepository.GetContactUsConfigsAsync();
                return _iMapper.Map<IEnumerable<ContactUsConfig>, IEnumerable<ContactUsConfigViewModel>>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> InsertOrUpdatetContactUsConfigAsync(ContactUsConfigViewModel model)
        {
            var data = _iMapper.Map<ContactUsConfigViewModel, ContactUsConfig>(model);
            return await _iContactUsConfigRepository.InsertOrUpdatetContactUsConfigAsync(data);
        }

        public async Task<Result> InsertContactUsConfigAsync(ContactUsConfigViewModel model)
        {
            try
            {
                var data = _iMapper.Map<ContactUsConfigViewModel, ContactUsConfig>(model);

                var saveChange = await _iContactUsConfigRepository.InsertContactUsConfigAsync(data);

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

        public async Task<Result> UpdateContactUsConfigAsync(ContactUsConfigViewModel model)
        {
            try
            {
                var data = _iMapper.Map<ContactUsConfigViewModel, ContactUsConfig>(model);

                var saveChange = await _iContactUsConfigRepository.UpdateContactUsConfigAsync(data);

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

        public async Task<Result> DeleteContactUsConfigAsync(int id)
        {
            try
            {
                var model = await GetContactUsConfigAsync(id);
                if (model != null)
                {
                    var data = _iMapper.Map<ContactUsConfigViewModel, ContactUsConfig>(model);

                    var saveChange = await _iContactUsConfigRepository.DeleteContactUsConfigAsync(data);

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

    public interface IContactUsConfigManager
    {
        Task<ContactUsConfigViewModel> GetContactUsConfigAsync(int id);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<ContactUsConfigViewModel>> GetContactUsConfigsAsync();
        Task<int> InsertOrUpdatetContactUsConfigAsync(ContactUsConfigViewModel model);
        Task<Result> InsertContactUsConfigAsync(ContactUsConfigViewModel model);
        Task<Result> UpdateContactUsConfigAsync(ContactUsConfigViewModel model);
        Task<Result> DeleteContactUsConfigAsync(int id);
    }
}
