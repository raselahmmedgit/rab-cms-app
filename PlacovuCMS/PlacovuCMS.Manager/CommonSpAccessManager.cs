using Microsoft.AspNetCore.Mvc.Rendering;
using PlacovuCMS.Model;
using PlacovuCMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacovuCMS.Manager
{
    public class CommonSpAccessManager : ICommonSpAccessManager
    {
        ICommonSpAccessRepository _commonSpAccessRepository;
        public CommonSpAccessManager(ICommonSpAccessRepository commonSpAccessRepository)
        {
            _commonSpAccessRepository = commonSpAccessRepository;
        }

        public async Task<List<SelectListItem>> GetMediaDate()
        {
            try
            {
                return await _commonSpAccessRepository.GetMediaDate();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<List<Media>> GetMediaWithPaging(string date, int page, string name)
        {
            try
            {
                return await _commonSpAccessRepository.GetMediaWithPaging(date,page,name);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Media>> GetMediaWithPaging(string fileType, string date, int page, string name)
        {
            try
            {
                return await _commonSpAccessRepository.GetMediaWithPaging(fileType,date, page, name);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string> GetUrl(int? id, string url)
        {
            try
            {
                return await _commonSpAccessRepository.GetUrl(id, url);
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
                return await _commonSpAccessRepository.GetMediaWithPagingForBlog(date, page, name);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    public interface ICommonSpAccessManager
    {
        Task<string> GetUrl(int? id, string url);
        Task<List<SelectListItem>> GetMediaDate();
        Task<List<Media>> GetMediaWithPaging(string date, int page, string name);
        Task<List<Media>> GetMediaWithPaging(string fileType, string date, int page, string name);

        Task<List<Media>> GetMediaWithPagingForBlog(string date, int page, string name);
    }
}
