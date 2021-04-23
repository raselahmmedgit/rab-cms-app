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
    public class EmailSmsConfigManager : IEmailSmsConfigManager
    {
        private readonly IEmailSmsConfigRepository _iEmailSmsConfigRepository;
        private readonly IMapper _iMapper;

        public EmailSmsConfigManager(IEmailSmsConfigRepository iEmailSmsConfigRepository, IMapper iMapper)
        {
            _iEmailSmsConfigRepository = iEmailSmsConfigRepository;
            _iMapper = iMapper;
        }

        public async Task<EmailSmsConfigViewModel> GetEmailSmsConfigAsync(int id)
        {
            try
            {
                var data = await _iEmailSmsConfigRepository.GetEmailSmsConfigAsync(id);
                return _iMapper.Map<EmailSmsConfig, EmailSmsConfigViewModel>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EmailSmsConfigViewModel> GetEmailSmsConfigFirstOrDefaultAsync()
        {
            var data = await _iEmailSmsConfigRepository.GetEmailSmsConfigFirstOrDefaultAsync();
            return _iMapper.Map<EmailSmsConfig, EmailSmsConfigViewModel>(data);
        }

        public async Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request)
        {
            try
            {
                var modelList = await _iEmailSmsConfigRepository.GetEmailSmsConfigsAsync();
                var viewModelList = _iMapper.Map<IEnumerable<EmailSmsConfig>, IEnumerable<EmailSmsConfigViewModel>>(modelList);

                // Global filtering.
                // Filter is being manually applied due to in-memmory (IEnumerable) data.
                // If you want something rather easier, check IEnumerableExtensions Sample.

                int dataCount = viewModelList.Count();
                int filteredDataCount = 0;
                IEnumerable<EmailSmsConfigViewModel> dataPage;
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

        public async Task<IEnumerable<EmailSmsConfigViewModel>> GetEmailSmsConfigsAsync()
        {
            try
            {
                var data = await _iEmailSmsConfigRepository.GetEmailSmsConfigsAsync();
                return _iMapper.Map<IEnumerable<EmailSmsConfig>, IEnumerable<EmailSmsConfigViewModel>>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> InsertOrUpdatetEmailSmsConfigAsync(EmailSmsConfigViewModel model)
        {
            var data = _iMapper.Map<EmailSmsConfigViewModel, EmailSmsConfig>(model);
            return await _iEmailSmsConfigRepository.InsertOrUpdatetEmailSmsConfigAsync(data);
        }

        public async Task<Result> InsertEmailSmsConfigAsync(EmailSmsConfigViewModel model)
        {
            try
            {
                var data = _iMapper.Map<EmailSmsConfigViewModel, EmailSmsConfig>(model);

                var saveChange = await _iEmailSmsConfigRepository.InsertEmailSmsConfigAsync(data);

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

        public async Task<Result> UpdateEmailSmsConfigAsync(EmailSmsConfigViewModel model)
        {
            try
            {
                var data = _iMapper.Map<EmailSmsConfigViewModel, EmailSmsConfig>(model);

                var saveChange = await _iEmailSmsConfigRepository.UpdateEmailSmsConfigAsync(data);

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

        public async Task<Result> DeleteEmailSmsConfigAsync(int id)
        {
            try
            {
                var model = await GetEmailSmsConfigAsync(id);
                if (model != null)
                {
                    var data = _iMapper.Map<EmailSmsConfigViewModel, EmailSmsConfig>(model);

                    var saveChange = await _iEmailSmsConfigRepository.DeleteEmailSmsConfigAsync(data);

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

    public interface IEmailSmsConfigManager
    {
        Task<EmailSmsConfigViewModel> GetEmailSmsConfigAsync(int id);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<EmailSmsConfigViewModel>> GetEmailSmsConfigsAsync();
        Task<int> InsertOrUpdatetEmailSmsConfigAsync(EmailSmsConfigViewModel model);
        Task<Result> InsertEmailSmsConfigAsync(EmailSmsConfigViewModel model);
        Task<Result> UpdateEmailSmsConfigAsync(EmailSmsConfigViewModel model);
        Task<Result> DeleteEmailSmsConfigAsync(int id);
    }
}
