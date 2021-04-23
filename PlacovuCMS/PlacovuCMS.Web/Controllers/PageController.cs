using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PlacovuCMS.Web.Infrastructure;
using PlacovuCMS.Model;
using PlacovuCMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using PlacovuCMS.Core.Helpers;
using log4net;
using AutoMapper;
using PlacovuCMS.Manager;
using DataTables.AspNet.Core;
using DataTables.AspNet.AspNetCore;
using System.Threading.Tasks;
using PlacovuCMS.Core.Helper;
using PlacovuCMS.Core.Extensions;

namespace PlacovuCMS.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PageController : BaseController
    {
        #region Global Variable Declaration
        private readonly IMapper _iMapper;
        private readonly IPageManager _iPageManager;
        private readonly ILog _log;
        private readonly AppDbContext context;

        #endregion

        #region Constructor
        public PageController(IPageManager iPageManager
            , IMapper iMapper,AppDbContext dbContext
        )
        {
            _iPageManager = iPageManager;
            _iMapper = iMapper;
            _log = LogManager.GetLogger(typeof(PageController));
            context = dbContext;
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
                PageViewModel pageViewModel = new PageViewModel();
                if (id != null)
                {
                    pageViewModel = await _iPageManager.GetPageAsync(id.ToInt());
                    if (pageViewModel != null)
                    {
                        ViewBag.Title = "Update Page";
                        return View(pageViewModel);
                    }
                }
                ViewBag.Title = "Add Page";
                return View();
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(PageViewModel pageViewModel, int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var context = new AppDbContext())
                    {
                        if (id == null)
                        {
                            var param = new SqlParameter[] {
                                    new SqlParameter() {
                                        ParameterName = "@Name",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size=100,
                                        Value = pageViewModel.Name
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@Url",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size=100,
                                        Value = CommonFunction.Url(pageViewModel.Url)
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@MetaTitle",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size=250,
                                        Value = pageViewModel.MetaTitle ?? (object)DBNull.Value
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@MetaKeyword",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size=250,
                                        Value = pageViewModel.MetaKeyword ?? (object)DBNull.Value
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@MetaDescription",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size=250,
                                        Value = pageViewModel.MetaDescription ?? (object)DBNull.Value
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@Description",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size=-1,
                                        Value = pageViewModel.Description
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@Status",
                                        SqlDbType =  System.Data.SqlDbType.Bit,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Value = pageViewModel.Status
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@Result",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Output,
                                        Size=50
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@CreatedId",
                                        SqlDbType =  System.Data.SqlDbType.Int,
                                        Direction = System.Data.ParameterDirection.Output,
                                    }};

                            context.Database.ExecuteSqlRaw("[dbo].[sp_InsertPage] @Name, @Url, @MetaTitle, @MetaKeyword, @MetaDescription, @Description, @Status, @Result out, @CreatedId out", param);

                            TempData["result"] = Convert.ToString(param[7].Value);
                            if (Convert.ToString(param[7].Value) == "Saved Successfully.")
                                return RedirectToAction("Add", new { id = Convert.ToInt32(param[8].Value) });
                        }
                        else
                        {
                            var param = new SqlParameter[] {
                                    new SqlParameter() {
                                        ParameterName = "@Id",
                                        SqlDbType =  System.Data.SqlDbType.Int,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Value = pageViewModel.Id
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@Name",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size=100,
                                        Value = pageViewModel.Name
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@Url",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size=100,
                                        Value =  CommonFunction.Url(pageViewModel.Url)
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@MetaTitle",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size=250,
                                        Value = pageViewModel.MetaTitle ?? (object)DBNull.Value
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@MetaKeyword",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size=250,
                                        Value = pageViewModel.MetaKeyword ?? (object)DBNull.Value
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@MetaDescription",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size=250,
                                        Value = pageViewModel.MetaDescription ?? (object)DBNull.Value
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@Description",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size=-1,
                                        Value = pageViewModel.Description
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@Status",
                                        SqlDbType =  System.Data.SqlDbType.Bit,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Value = pageViewModel.Status
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@Result",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Output,
                                        Size=50
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@CreatedUrl",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Output,
                                        Size=100
                                    }};
                            context.Database.ExecuteSqlRaw("[dbo].[sp_UpdatePage] @Id, @Name, @Url, @MetaTitle, @MetaKeyword, @MetaDescription, @Description, @Status, @Result out, @CreatedUrl out", param);
                            ModelState.Clear();
                            pageViewModel.Url = Convert.ToString(param[9].Value);
                            TempData["result"] = Convert.ToString(param[8].Value);
                        }
                    }
                }
                ViewBag.Title = id == null ? "Add Page" : "Update Page";
                return View(pageViewModel);
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Add[POST]"));
            }
            this.FlashError(MessageHelper.UnhandelledError, "PageMessage");
            return RedirectToAction("Index", "Page");
        }

        public string UpdateBulkPageStatus(string idChecked, string statusToChange)
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
                        context.Database.ExecuteSqlRaw("[dbo].[sp_UpdateBulkPageStatus] @Id, @Status, @Result out", param);
                        result = Convert.ToString(param[2].Value);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "UpdateBulkPageStatus"));
            }
            return result;
        }

        public PageList GetPage(int? page, string searchText, int? status)
        {
            try
            {
                int pageSize = 3;
                int pageNo = page == null ? 1 : Convert.ToInt32(page);

                List<Page> list = new List<Page>();
                PageExtraData pageExtraData = new PageExtraData();
                PageList pageList = new PageList();
                using (var cnn = context.Database.GetDbConnection())
                {
                    var param = new SqlParameter[] {
                                    new SqlParameter() {
                                        ParameterName = "@PageNo",
                                        SqlDbType =  System.Data.SqlDbType.Int,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Value = page
                                    },
                                    new SqlParameter() {
                                        ParameterName = "@Name",
                                        SqlDbType =  System.Data.SqlDbType.VarChar,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Size=100,
                                        Value = searchText ?? (object)DBNull.Value
                                    },
                                    new SqlParameter()
                                    {
                                        ParameterName = "@PageSize",
                                        SqlDbType = System.Data.SqlDbType.Int,
                                        Direction = System.Data.ParameterDirection.Input,
                                        Value = pageSize
                                    },
                                    new SqlParameter()
                                    {
                                        ParameterName = "@Status",
                                        SqlDbType = System.Data.SqlDbType.Int,
                                        Direction = System.Data.ParameterDirection.Input,
                                         Value=status ?? (object)DBNull.Value
                                    }
                };

                    {
                        var cmm = cnn.CreateCommand();
                        cmm.CommandType = System.Data.CommandType.StoredProcedure;
                        cmm.CommandText = "[dbo].[sp_GetPageWithPaging]";
                        cmm.Parameters.AddRange(param);
                        cmm.Connection = cnn;
                        cnn.Open();
                        var reader = cmm.ExecuteReader();

                        while (reader.Read())
                        {
                            Page pages = new Page();
                            pages.Id = Convert.ToInt32(reader["Id"]);
                            pages.Name = Convert.ToString(reader["Name"]);
                            pages.Url = Convert.ToString(reader["Url"]);
                            pages.MetaTitle = Convert.ToString(reader["MetaTitle"]);
                            pages.MetaKeyword = Convert.ToString(reader["MetaKeyword"]);
                            pages.MetaDescription = Convert.ToString(reader["MetaDescription"]);
                            pages.Description = Convert.ToString(reader["Description"]);
                            pages.AddedOn = Convert.ToDateTime(reader["AddedOn"]);
                            pages.Status = Convert.ToBoolean(reader["Status"]);
                            list.Add(pages);
                        }
                        reader.NextResult();
                        while (reader.Read())
                        {
                            PagingInfo pagingInfo = new PagingInfo();
                            pagingInfo.CurrentPage = pageNo;
                            pagingInfo.TotalItems = Convert.ToInt32(reader["Total"]);
                            pagingInfo.ItemsPerPage = pageSize;

                            pageList.page = list;
                            pageList.allTotalPage = Convert.ToInt32(reader["AllTotalPage"]);
                            pageList.activeTotalPage = Convert.ToInt32(reader["ActiveTotalPage"]);
                            pageList.inactiveTotalPage = Convert.ToInt32(reader["InActiveTotalPage"]);
                            pageList.searchText = searchText;
                            pageList.status = status;
                            pageList.pagingInfo = pagingInfo;
                        }
                    }
                    //var result = context.sp_GetPageWithPaging(pageNo, searchText, pageSize, status);
                    //list = result.Select(x => new Models.Page() { id = x.Id, name = x.Name, url = x.Url, metaTitle = x.MetaTitle, metaKeyword = x.MetaKeyword, metaDescription = x.MetaDescription, description = x.Description, addedOn = x.AddedOn, status = Convert.ToInt32(x.Status) }).ToList();

                    //var pageExtraDataResult = result.GetNextResult<sp_PageExtraData>();
                    //pageExtraData = pageExtraDataResult.ToList().FirstOrDefault();
                }
                return pageList;
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "GetPage"));
                return null;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    _result = await _iPageManager.DeletePageAsync(id);
                }
                else
                {
                    _result = Result.Fail(MessageHelper.DeleteFail);
                }

                if (_result.Success)
                {
                    this.FlashSuccess(MessageHelper.Delete, "PageMessage");
                }
                else
                {
                    this.FlashError(_result.Error, "PageMessage");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Delete[POST]"));
                _result = Result.Fail(MessageHelper.UnhandelledError);
            }

            return JsonResult(_result);
        }

        [HttpGet]
        [Route("/Page/GetDataAsync")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public async Task<IActionResult> GetDataAsync(IDataTablesRequest request)
        {
            try
            {
                DataTablesResponse response = await _iPageManager.GetDataTablesResponseAsync(request);
                return new DataTablesJsonResult(response, true);
            }
            catch (Exception ex)
            {
                return ErrorPartialView(ex);
            }
        }
        #endregion

    }
}