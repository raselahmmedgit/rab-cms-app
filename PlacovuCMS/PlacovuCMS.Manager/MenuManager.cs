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
    public class MenuManager : IMenuManager
    {
        private readonly IMenuRepository _iMenuRepository;
        private readonly IMapper _iMapper;

        public MenuManager(IMenuRepository iMenuRepository, IMapper iMapper)
        {
            _iMenuRepository = iMenuRepository;
            _iMapper = iMapper;
        }

        public async Task<Menu> GetMenuAsync(int id)
        {
            try
            {
                var data = await _iMenuRepository.GetMenuAsync(id);
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MenuList> GetMenusAsync(int? page, string searchText, int? status)
        {
            try
            {
                int pageSize = 10;
                int pageNo = page == null ? 1 : Convert.ToInt32(page);

                var skip = pageSize * (Convert.ToInt32(pageNo) - 1);
                MenuList list = new MenuList();


                var result = await _iMenuRepository.GetMenusAsync(pageSize, skip, searchText, status);

                int total = await _iMenuRepository.GetTotalMenusAsync(searchText, status);

                PagingInfo pagingInfo = new PagingInfo();
                pagingInfo.CurrentPage = pageNo;
                pagingInfo.TotalItems = total;
                pagingInfo.ItemsPerPage = pageSize;

                list.menu = result;
                list.allTotal = await _iMenuRepository.GetTotalMenusAsync();
                list.activeTotal = await _iMenuRepository.GetTotalActiveMenusAsync();
                list.inactiveTotal = await _iMenuRepository.GetTotalInactiveMenusAsync();
                list.searchText = searchText;
                list.status = status;
                list.pagingInfo = pagingInfo;


                return list;
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
                var modelList = await _iMenuRepository.GetMenusAsync();
                var viewModelList = _iMapper.Map<IEnumerable<Menu>, IEnumerable<MenuViewModel>>(modelList);

                // Global filtering.
                // Filter is being manually applied due to in-memmory (IEnumerable) data.
                // If you want something rather easier, check IEnumerableExtensions Sample.

                int dataCount = viewModelList.Count();
                int filteredDataCount = 0;
                IEnumerable<MenuViewModel> dataPage;
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

        public async Task<IEnumerable<MenuViewModel>> GetMenusAsync()
        {
            try
            {
                var data = await _iMenuRepository.GetMenusAsync();
                return _iMapper.Map<IEnumerable<Menu>, IEnumerable<MenuViewModel>>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Result> AddOrEdit(Menu menu, int? id)
        {
            try
            {
                if (id == null)
                {
                    int saveChange = await _iMenuRepository.InsertOrUpdatetMenuAsync(menu);
                    if (saveChange > 0)
                    {
                        return Result.Ok(MessageHelper.Save);
                    }
                    else
                    {
                        return Result.Fail(MessageHelper.SaveFail);
                    }
                }
                else
                {
                    var menuResult = await _iMenuRepository.GetMenuAsync(id.Value) ;
                    menuResult.Id = menu.Id;
                    menuResult.Name = menu.Name;
                    menuResult.Item = menu.Item;
                    menuResult.Status = Convert.ToBoolean(menu.Status);
                    int saveChange = await _iMenuRepository.InsertOrUpdatetMenuAsync(menuResult);
                    if (saveChange > 0)
                    {
                        return Result.Ok(MessageHelper.Update);
                    }
                    else
                    {
                        return Result.Fail(MessageHelper.UpdateFail);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> InsertOrUpdatetMenuAsync(MenuViewModel model)
        {
            var data = _iMapper.Map<MenuViewModel, Menu>(model);
            return await _iMenuRepository.InsertOrUpdatetMenuAsync(data);
        }
        
        public async Task<Result> InsertMenuAsync(MenuViewModel model)
        {
            try
            {
                var data = _iMapper.Map<MenuViewModel, Menu>(model);

                var saveChange = await _iMenuRepository.InsertMenuAsync(data);

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

        public async Task<Result> UpdateMenuAsync(MenuViewModel model)
        {
            try
            {
                var data = _iMapper.Map<MenuViewModel, Menu>(model);

                var saveChange = await _iMenuRepository.UpdateMenuAsync(data);

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

        public async Task<Result> DeleteMenuAsync(int id)
        {
            try
            {
                var data = await _iMenuRepository.GetMenuAsync(id);
                if (data != null)
                {
                    var saveChange = await _iMenuRepository.DeleteMenuAsync(data);

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

    public interface IMenuManager
    {
        Task<Menu> GetMenuAsync(int id);
        Task<MenuList> GetMenusAsync(int? page, string searchText, int? status);
        Task<DataTablesResponse> GetDataTablesResponseAsync(IDataTablesRequest request);
        Task<IEnumerable<MenuViewModel>> GetMenusAsync();
        Task<int> InsertOrUpdatetMenuAsync(MenuViewModel model);
        Task<Result> InsertMenuAsync(MenuViewModel model);
        Task<Result> UpdateMenuAsync(MenuViewModel model);
        Task<Result> DeleteMenuAsync(int id);
        Task<Result> AddOrEdit(Menu menu, int? id);
    }
}
