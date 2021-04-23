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
    public class EmailSmsHistoryManager : IEmailSmsHistoryManager
    {
        private readonly IEmailSmsHistoryRepository _iEmailSmsHistoryRepository;
        private readonly IMapper _iMapper;

        public EmailSmsHistoryManager(IEmailSmsHistoryRepository iEmailSmsHistoryRepository, IMapper iMapper)
        {
            _iEmailSmsHistoryRepository = iEmailSmsHistoryRepository;
            _iMapper = iMapper;
        }

        public async Task<EmailSmsHistoryViewModel> GetEmailSmsHistoryAsync(int id)
        {
            try
            {
                var data = await _iEmailSmsHistoryRepository.GetEmailSmsHistoryAsync(id);
                return _iMapper.Map<EmailSmsHistory, EmailSmsHistoryViewModel>(data);
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
                var modelList = await _iEmailSmsHistoryRepository.GetEmailSmsHistorysAsync();
                var viewModelList = _iMapper.Map<IEnumerable<EmailSmsHistory>, IEnumerable<EmailSmsHistoryViewModel>>(modelList);

                // Global filtering.
                // Filter is being manually applied due to in-memmory (IEnumerable) data.
                // If you want something rather easier, check IEnumerableExtensions Sample.

                int dataCount = viewModelList.Count();
                int filteredDataCount = 0;
                IEnumerable<EmailSmsHistoryViewModel> dataPage;
                if (viewModelList.Count() > 0 && request != null)
                {
                    var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                    ? viewModelList
                    : viewModelList.Where(_item => _item.ReciverName.Contains(request.Search.Value));

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

        public async Task<IEnumerable<EmailSmsHistoryViewModel>> GetEmailSmsHistorysAsync()
        {
            try
            {
                var data = await _iEmailSmsHistoryRepository.GetEmailSmsHistorysAsync();
                return _iMapper.Map<IEnumerable<EmailSmsHistory>, IEnumerable<EmailSmsHistoryViewModel>>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> InsertOrUpdatetEmailSmsHistoryAsync(EmailSmsHistoryViewModel model)
        {
            var data = _iMapper.Map<EmailSmsHistoryViewModel, EmailSmsHistory>(model);
            return await _iEmailSmsHistoryRepository.InsertOrUpdatetEmailSmsHistoryAsync(data);
        }

        public async Task<Result> InsertEmailSmsHistoryAsync(EmailSmsHistoryViewModel model)
        {
            try
            {
                var data = _iMapper.Map<EmailSmsHistoryViewModel, EmailSmsHistory>(model);

                var saveChange = await _iEmailSmsHistoryRepository.InsertEmailSmsHistoryAsync(data);

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

        public async Task<Result> UpdateEmailSmsHistoryAsync(EmailSmsHistoryViewModel model)
        {
            try
            {
                var data = _iMapper.Map<EmailSmsHistoryViewModel, EmailSmsHistory>(model);

                var saveChange = await _iEmailSmsHistoryRepository.UpdateEmailSmsHistoryAsync(data);

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

        public async Task<Result> DeleteEmailSmsHistoryAsync(int id)
        {
            try
            {
                var model = await GetEmailSmsHistoryAsync(id);
                if (model != null)
                {
                    var data = _iMapper.Map<EmailSmsHistoryViewModel, EmailSmsHistory>(model);

                    var saveChange = await _iEmailSmsHistoryRepository.DeleteEmailSmsHistoryAsync(data);

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

    public interface IEmailSmsHistoryManager
    {
        Task<EmailSmsHistoryViewModel> GetEmailSmsHistoryAsync(int id);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<EmailSmsHistoryViewModel>> GetEmailSmsHistorysAsync();
        Task<int> InsertOrUpdatetEmailSmsHistoryAsync(EmailSmsHistoryViewModel model);
        Task<Result> InsertEmailSmsHistoryAsync(EmailSmsHistoryViewModel model);
        Task<Result> UpdateEmailSmsHistoryAsync(EmailSmsHistoryViewModel model);
        Task<Result> DeleteEmailSmsHistoryAsync(int id);
    }
}
