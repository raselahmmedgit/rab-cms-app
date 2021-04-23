using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Http;
using PlacovuCMS.Core.Helpers;
using PlacovuCMS.Model;
using PlacovuCMS.Repository;
using PlacovuCMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PlacovuCMS.Manager
{
    public class MediaManager : IMediaManager
    {
        private readonly IMediaRepository _iMediaRepository;
        private readonly ICommonSpAccessRepository _commonSpAccessRepository;
        private readonly IMapper _iMapper;

        public MediaManager(IMediaRepository iMediaRepository, ICommonSpAccessRepository commonSpAccessRepository, IMapper iMapper)
        {
            _iMediaRepository = iMediaRepository;
            _commonSpAccessRepository = commonSpAccessRepository;
            _iMapper = iMapper;
        }

        public async Task<MediaViewModel> GetMediaAsync(int id)
        {
            try
            {
                var data = await _iMediaRepository.GetMediaAsync(id);
                return _iMapper.Map<Media, MediaViewModel>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<MediaViewModel> GetMediaByIdAsync(int id, string WebRootPath)
        {
            MediaViewModel mediaViewModel = new MediaViewModel();
     
            var resultList = await _iMediaRepository.GetMediaById(id);
            if (resultList != null)
            {
                var media = resultList.AsEnumerable().FirstOrDefault();
                mediaViewModel = _iMapper.Map<Media, MediaViewModel>(media);
                mediaViewModel.DisplayUrl = "admin/images/file-icon.png";

                long fileSize = new FileInfo(Path.Combine(WebRootPath, Convert.ToString(resultList.Select(x => x.Url).FirstOrDefault()))).Length;

                float fileSizeValue;
                if (fileSize > 1024 * 1024)
                {
                    fileSizeValue = (float)fileSize / (1024 * 1024);
                    mediaViewModel.FileSize = fileSizeValue.ToString("0.00") + "MB";
                }
                else if (fileSize > 1024)
                {
                    fileSizeValue = (float)fileSize / 1024;
                    mediaViewModel.FileSize = fileSizeValue.ToString("0.00") + "KB";
                }
                else
                {
                    fileSizeValue = fileSize;
                    mediaViewModel.FileSize = fileSizeValue + "Bytes";
                }

                mediaViewModel.FileType = Path.GetExtension(Convert.ToString(resultList.Select(x => x.Name).FirstOrDefault()));
                if (ImageHelper.IsImage(Convert.ToString(resultList.Select(x => x.Name).FirstOrDefault())))
                {
                    var image = Image.FromFile(Path.Combine(WebRootPath, Convert.ToString(resultList.Select(x => x.Url).FirstOrDefault())));
                    mediaViewModel.Dimension = image.Width + "*" + image.Height;
                    mediaViewModel.DisplayUrl = Convert.ToString(resultList.Select(x => x.Url).FirstOrDefault());
                }
            }

            return mediaViewModel;
        }

        public async Task<string> UpdateMediaAsync(MediaViewModel mediaViewModel)
        {
            try
            {
                return await _iMediaRepository.UpdateMediaAsync(mediaViewModel);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request)
        {
            try
            {
                var modelList = await _iMediaRepository.GetMediasAsync();
                var viewModelList = _iMapper.Map<IEnumerable<Media>, IEnumerable<MediaViewModel>>(modelList);

                // Global filtering.
                // Filter is being manually applied due to in-memmory (IEnumerable) data.
                // If you want something rather easier, check IEnumerableExtensions Sample.

                int dataCount = viewModelList.Count();
                int filteredDataCount = 0;
                IEnumerable<MediaViewModel> dataPage;
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

        public async Task<IEnumerable<MediaViewModel>> GetMediasAsync()
        {
            try
            {
                var data = await _iMediaRepository.GetMediasAsync();
                return _iMapper.Map<IEnumerable<Media>, IEnumerable<MediaViewModel>>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> InsertOrUpdatetMediaAsync(MediaViewModel model)
        {
            var data = _iMapper.Map<MediaViewModel, Media>(model);
            return await _iMediaRepository.InsertOrUpdatetMediaAsync(data);
        }

        public async Task<string[]> InsertMediaAsync(IFormFile file, string fileName, int? parentId)
        {
            try
            {
                return await _iMediaRepository.InsertMediaAsync(file,fileName,parentId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteMediaAsync(string ids)
        {
            try
            {
                await _iMediaRepository.DeleteMediaAsync(ids);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Result> DeleteMediaAsync(int id)
        {
            try
            {
                var data = await _iMediaRepository.GetMediaAsync(id);
                if (data != null)
                {
                    var saveChange = await _iMediaRepository.DeleteMediaAsync(data);

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

    public interface IMediaManager
    {
        Task<MediaViewModel> GetMediaAsync(int id);
        Task<MediaViewModel> GetMediaByIdAsync(int id, string WebRootPath);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<MediaViewModel>> GetMediasAsync();
        Task<int> InsertOrUpdatetMediaAsync(MediaViewModel model);
        Task<string[]> InsertMediaAsync(IFormFile file, string fileName, int? parentId);
        Task<string> UpdateMediaAsync(MediaViewModel model);
        Task DeleteMediaAsync(string ids);
        Task<Result> DeleteMediaAsync(int id);
    }
}
