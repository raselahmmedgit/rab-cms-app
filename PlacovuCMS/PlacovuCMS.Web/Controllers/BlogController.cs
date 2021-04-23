using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PlacovuCMS.Core.Exception;
using PlacovuCMS.Core.Helper;
using PlacovuCMS.Core.Helpers;
using PlacovuCMS.Manager;
using PlacovuCMS.Model;
using PlacovuCMS.ViewModel;
using PlacovuCMS.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacovuCMS.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BlogController : BaseController
    {
        #region Global Variable Declaration
        private readonly IMapper _iMapper;
        private readonly IBlogManager _iBlogManager;
        private readonly IBlogCategoryManager _iBlogCategoryManager;
        private readonly ICommonSpAccessManager _commonSpAccessManager;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public BlogController(IBlogManager iBlogManager, IBlogCategoryManager iBlogCategoryManager, ICommonSpAccessManager commonSpAccessManager
            , IMapper iMapper
        )
        {
            _iBlogManager = iBlogManager;
            _iBlogCategoryManager = iBlogCategoryManager;
            _commonSpAccessManager = commonSpAccessManager;
            _iMapper = iMapper;
            _log = LogManager.GetLogger(typeof(BlogController));
        }
        #endregion

        #region Actions
        public IActionResult Index(int? id, string searchText, int? status)
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        public async Task<IActionResult> Add(int? id)
        {
            try
            {
                ViewBag.CategoryList = await _iBlogCategoryManager.GetActiveCategory();
                ViewBag.MediaDate = await _commonSpAccessManager.GetMediaDate();

                BlogViewModel blogViewModel = new BlogViewModel();
                blogViewModel.PrimaryImageUrl = "/default/images/default-addphoto-image.jpg";
                if (id != null)
                {
                    blogViewModel = await _iBlogManager.GetBlogAsync(id.Value);
                    ViewBag.Title = "Update Blog";
                }

                ViewBag.Title = "Add New Blog";
                return View(blogViewModel);
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(BlogViewModel blogViewModel, int? id)
        {
            try
            {
                ViewBag.CategoryList = await _iBlogCategoryManager.GetActiveCategory();
                ViewBag.MediaDate = await _commonSpAccessManager.GetMediaDate();
                ViewBag.Title = id == null ? "Add New Blog" : "Update Blog";

                if (ModelState.IsValid)
                {
                    _result = await _iBlogManager.AddOrEdit(blogViewModel, id, CommonFunction.Url(blogViewModel.Url));
                    
                    blogViewModel.PrimaryImageUrl = blogViewModel.PrimaryImageUrl ?? "~/default/images/default-image.png";
                    if (_result.Success)
                    {
                        this.FlashSuccess(MessageHelper.Save, "BlogMessage");
                        return RedirectToAction("Index", "Blog");
                    }
                    else
                    {
                        this.FlashError(_result.Error, "BlogMessage");
                        return View(blogViewModel);
                    }
                }
                else
                {
                    this.FlashError(ExceptionHelper.ModelStateErrorFirstFormat(ModelState), "BlogMessage");
                    return View(blogViewModel);
                }
                
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Add[POST]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "BlogMessage");
            return View(blogViewModel);
        }

        public BlogList GetBlog(int? page, string searchText, int? status)
        {
            BlogList bList = new BlogList();
            try
            {
                int pageSize = 3;
                int pageNo = page == null ? 1 : Convert.ToInt32(page);

                //int total;
                //using (var context = new CMSEntities())
                //{
                //    total = context.Blogs.Where(x => x.Name == (searchText == null ? x.Name : searchText) && x.Status == (status == null ? x.Status : (status == 1 ? true : false))).Count();
                //}

                var skip = pageSize * (Convert.ToInt32(pageNo) - 1);
                //var canPage = skip < total;
                
                //if (canPage)
                //{
                using (var context = new AppDbContext())
                {
                    // bool searchVal = string.IsNullOrEmpty(searchText);

                    var result = context.Blog.Where(x => x.Status == (status == null ? x.Status : (status == 1 ? true : false)) && x.Name.Contains(searchText == null ? x.Name : searchText)).OrderByDescending(x => x.Id).Skip(skip).Take(pageSize).ToList();

                    int total = context.Blog.Where(x => x.Status == (status == null ? x.Status : (status == 1 ? true : false)) && x.Name.Contains(searchText == null ? x.Name : searchText)).Count();

                    PagingInfo pagingInfo = new PagingInfo();
                    pagingInfo.CurrentPage = pageNo;
                    pagingInfo.TotalItems = total;
                    pagingInfo.ItemsPerPage = pageSize;

                    bList.blog = result;
                    bList.allTotal = context.Blog.Count();
                    bList.activeTotal = context.Blog.Where(x => x.Status == true).Count();
                    bList.inactiveTotal = context.Blog.Where(x => x.Status == false).Count();
                    bList.searchText = searchText;
                    bList.status = status;
                    bList.pagingInfo = pagingInfo;
                }
                //}
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "GetBlog"));
            }
            return bList;
        }

        public string UpdateBulkStatus(string idChecked, string statusToChange)
        {
            string result = "";
            try
            {
                
                if (statusToChange == "Status")
                    result = "Select Status";
                else if (idChecked == "")
                    result = "Select at least 1 item";
                else
                {
                    using (var context = new AppDbContext())
                    {
                        var blog = context.Blog.Where(x => idChecked.Contains(x.Id.ToString())).ToList();
                        blog.ForEach(x => x.Status = Convert.ToBoolean(Convert.ToInt32(statusToChange)));
                        context.SaveChanges().ToString();
                        result = "Updated Successfully.";
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "UpdateBulkStatus"));
            }
            return result;
        }

        [HttpGet]
        [Route("/Blog/GetDataAsync")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public async Task<IActionResult> GetDataAsync(IDataTablesRequest request)
        {
            try
            {
                DataTablesResponse response = await _iBlogManager.GetDataTablesResponseAsync(request);
                return new DataTablesJsonResult(response, true);
            }
            catch (Exception ex)
            {
                return ErrorPartialView(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    _result = await _iBlogManager.DeleteBlogAsync(id);
                }
                else
                {
                    _result = Result.Fail(MessageHelper.DeleteFail);
                }

                if (_result.Success)
                {
                    this.FlashSuccess(MessageHelper.Delete, "BlogMessage");
                }
                else
                {
                    this.FlashError(_result.Error, "BlogMessage");
                }

                return JsonResult(_result);
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Delete[POST]"));
                _result = Result.Fail(MessageHelper.UnhandelledError);
                return JsonResult(_result);
            }
        }

        public async Task<string> GetMediaWithPaging(string date, int page, string name)
        {
            string result = string.Empty;
            try
            {
                var mediaList = await _iBlogManager.GetMediaWithPagingForBlog(date, page, name);
                
                StringBuilder stringBuilder = new StringBuilder();
                foreach (Media media in mediaList)
                {
                    string url = media.ThumbUrl == null ? media.Url : media.ThumbUrl;
                    stringBuilder.Append("<div class=\"col-6 mb-2\"><input class=\"mr-2\" type=\"checkbox\"/><a target=\"_blank\" href=\"" + Url.Action("Update", "Media", new { id = media.Id }) + "\"><img data-url=\"/" + media.Url + "\" width =\"135\" src=\"" + Url.Content("~/" + url) + "\"/></a></div>");
                }

                result = stringBuilder.ToString();

                return result;
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "GetMediaWithPaging"));
            }

            return result;
        }

        #endregion
    }
}