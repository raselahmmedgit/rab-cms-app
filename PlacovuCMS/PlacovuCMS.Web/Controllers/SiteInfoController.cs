using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlacovuCMS.Core.Exception;
using PlacovuCMS.Core.Helper;
using PlacovuCMS.Core.Helpers;
using PlacovuCMS.Manager;
using PlacovuCMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlacovuCMS.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SiteInfoController : BaseController
    {
        #region Global Variable Declaration
        private readonly IMapper _iMapper;
        private readonly ISiteInfoManager _iSiteInfoManager;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public SiteInfoController(ISiteInfoManager iSiteInfoManager
            , IMapper iMapper
        )
        {
            _iSiteInfoManager = iSiteInfoManager;
            _iMapper = iMapper;
            _log = LogManager.GetLogger(typeof(SiteInfoController));
        }
        #endregion

        #region Actions
        public IActionResult Index()
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

        [HttpGet]
        [Route("/SiteInfo/GetDataAsync")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public async Task<IActionResult> GetDataAsync(IDataTablesRequest request)
        {
            try
            {
                DataTablesResponse response = await _iSiteInfoManager.GetDataTablesResponseAsync(request);
                return new DataTablesJsonResult(response, true);
            }
            catch (Exception ex)
            {
                return ErrorPartialView(ex);
            }
        }

        public async Task<IActionResult> Add()
        {
            try
            {
                var isAdded = await _iSiteInfoManager.GetSiteInfosAsync();
                if (isAdded.Any())
                {
                    this.FlashSuccess(MessageHelper.AlreadyAdded, "SiteInfoMessage");
                    return RedirectToAction("Index", "SiteInfo");
                }

                var model = new SiteInfoViewModel();
                if (model != null)
                {
                    return View("AddOrEdit", model);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "SiteInfoMessage");
                    return RedirectToAction("Index", "SiteInfo");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Add[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "SiteInfoMessage");
            return RedirectToAction("Index", "SiteInfo");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await _iSiteInfoManager.GetSiteInfoAsync(id);

                if (model != null)
                {
                    return View("AddOrEdit", model);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "SiteInfoMessage");
                    return RedirectToAction("Index", "SiteInfo");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Edit[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "SiteInfoMessage");
            return RedirectToAction("Index", "SiteInfo");
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var siteInfoViewModel = await _iSiteInfoManager.GetSiteInfoAsync(id);
                var model = _iMapper.Map<SiteInfoViewModel, SiteInfoViewModel>(siteInfoViewModel);

                if (model != null)
                {
                    return View("Details", model);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "SiteInfoMessage");
                    return RedirectToAction("Index", "SiteInfo");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Details[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "SiteInfoMessage");
            return RedirectToAction("Index", "SiteInfo");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(SiteInfoViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //add
                    if (viewModel.Id == 0)
                    {
                        _result = await _iSiteInfoManager.InsertSiteInfoAsync(viewModel);
                    }
                    else if (viewModel.Id > 0) //edit
                    {
                        _result = await _iSiteInfoManager.UpdateSiteInfoAsync(viewModel);
                    }

                    if (_result.Success)
                    {
                        this.FlashSuccess(MessageHelper.Save, "SiteInfoMessage");
                        return RedirectToAction("Index", "SiteInfo");
                    }
                    else
                    {
                        this.FlashError(_result.Error, "SiteInfoMessage");
                        return View(viewModel);
                    }
                }
                else
                {
                    this.FlashError(ExceptionHelper.ModelStateErrorFirstFormat(ModelState), "SiteInfoMessage");
                    return View(viewModel);
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Save[POST]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "SiteInfoMessage");
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    _result = await _iSiteInfoManager.DeleteSiteInfoAsync(id);
                }
                else
                {
                    _result = Result.Fail(MessageHelper.DeleteFail);
                }

                if (_result.Success)
                {
                    this.FlashSuccess(MessageHelper.Delete, "SiteInfoMessage");
                }
                else
                {
                    this.FlashError(_result.Error, "SiteInfoMessage");
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
