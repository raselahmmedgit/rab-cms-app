using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PlacovuCMS.Core.Helper;
using PlacovuCMS.Core.Helpers;
using PlacovuCMS.Manager;
using PlacovuCMS.Model;
using PlacovuCMS.ViewModel;
using PlacovuCMS.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacovuCMS.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BlogCategoryController : BaseController
    {
        #region Global Variable Declaration
        private readonly IMapper _iMapper;
        private readonly IBlogCategoryManager _iBlogCategoryManager;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public BlogCategoryController(IBlogCategoryManager iBlogCategoryManager
            , IMapper iMapper
        )
        {
            _iBlogCategoryManager = iBlogCategoryManager;
            _iMapper = iMapper;
            _log = LogManager.GetLogger(typeof(BlogCategoryController));
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
                var activeCategorys = await _iBlogCategoryManager.GetActiveCategory();
                ViewBag.CategoryList = id != null ? activeCategorys.Where(x => x.Value != id.ToString()) : activeCategorys;
                BlogCategoryViewModel blogCategoryViewModel = new BlogCategoryViewModel();
                if (id != null)
                {
                    blogCategoryViewModel = await _iBlogCategoryManager.GetBlogCategoryAsync(id.Value);
                    ViewBag.Title = "Update Blog Category";
                }
                else
                {
                    ViewBag.Title = "Add New Blog Category";
                }

                return View(blogCategoryViewModel);
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(BlogCategoryViewModel blogCategoryViewModel, int? id)
        {
            try
            {
                var activeCategorys = await _iBlogCategoryManager.GetActiveCategory();
                ViewBag.CategoryList = id != null ? activeCategorys.Where(x => x.Value != id.ToString()) : activeCategorys;
                ViewBag.Title = id == null ? "Add New Blog Category" : "Update Blog Category";

                if (ModelState.IsValid)
                {
                    _result = await _iBlogCategoryManager.AddOrEdit(blogCategoryViewModel, id, CommonFunction.Url(blogCategoryViewModel.Url));
                    if (_result.Success)
                    {
                        this.FlashSuccess(MessageHelper.Save, "BlogCategoryMessage");
                        return RedirectToAction("Index", "BlogCategory");
                    }
                    else
                    {
                        this.FlashError(_result.Error, "BlogCategoryMessage");
                        return View(blogCategoryViewModel);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Add[POST]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "BlogCategoryMessage");
            return View(blogCategoryViewModel);
        }

        public string UpdateBulkStatus(string idChecked, string statusToChange)
        {
            string result = "";
            try
            {
                if (statusToChange == "Status")
                    result = "Select Status";
                else if (idChecked == null)
                    result = "Select at least 1 item";
                else
                {
                    using (var context = new AppDbContext())
                    {
                        var param = new SqlParameter[] {
                                    new SqlParameter() {
                                        ParameterName = "@Id",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size = 50,
                                        Value = idChecked
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@Status",
                                        SqlDbType =  System.Data.SqlDbType.Bit,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Value =Convert.ToBoolean(Convert.ToInt32(statusToChange))
                                    },
                                    new SqlParameter()
                                    {
                                        ParameterName = "@Result",
                                        SqlDbType = System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Output,
                                        Size = 50
                                    }
                    };
                        context.Database.ExecuteSqlRaw("[dbo].[sp_UpdateBulkBlogCategoryStatus] @Id, @Status, @Result out", param);
                        result = Convert.ToString(param[2].Value);
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
        [Route("/BlogCategory/GetDataAsync")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public async Task<IActionResult> GetDataAsync(IDataTablesRequest request)
        {
            try
            {
                DataTablesResponse response = await _iBlogCategoryManager.GetDataTablesResponseAsync(request);
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
                    _result = await _iBlogCategoryManager.DeleteBlogCategoryAsync(id);
                }
                else
                {
                    _result = Result.Fail(MessageHelper.DeleteFail);
                }

                if (_result.Success)
                {
                    this.FlashSuccess(MessageHelper.Delete, "BlogCategoryMessage");
                }
                else
                {
                    this.FlashError(_result.Error, "BlogCategoryMessage");
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
        #endregion
    }
}