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
    public class SocialMediaConfigController : BaseController
    {
        #region Global Variable Declaration
        private readonly IMapper _iMapper;
        private readonly ISocialMediaConfigManager _iSocialMediaConfigManager;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public SocialMediaConfigController(ISocialMediaConfigManager iSocialMediaConfigManager
            , IMapper iMapper
        )
        {
            _iSocialMediaConfigManager = iSocialMediaConfigManager;
            _iMapper = iMapper;
            _log = LogManager.GetLogger(typeof(SocialMediaConfigController));
        }
        #endregion

        #region Actions
        [HttpGet]
        [Route("/SocialMediaConfig/GetDataAsync")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public async Task<IActionResult> GetDataAsync(IDataTablesRequest request)
        {
            try
            {
                DataTablesResponse response = await _iSocialMediaConfigManager.GetDataTablesResponseAsync(request);
                var result = new DataTablesJsonResult(response, true);
                return result;
            }
            catch (Exception ex)
            {
                return ErrorPartialView(ex);
            }
        }

        public IActionResult Index()
        {
            try
            {
                return View(new SocialMediaConfigViewModel());
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        public async Task<IActionResult> Add()
        {
            try
            {
                var isAdded = await _iSocialMediaConfigManager.GetSocialMediaConfigsAsync();
                if (isAdded.Any())
                {
                    this.FlashSuccess(MessageHelper.AlreadyAdded, "SocialMediaConfigMessage");
                    return RedirectToAction("Index", "SocialMediaConfig");
                }

                var model = new SocialMediaConfigViewModel();
                if (model != null)
                {
                    return View("Add", model);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "SocialMediaConfigMessage");
                    return RedirectToAction("Index", "SocialMediaConfig");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Add[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "SocialMediaConfigMessage");
            return RedirectToAction("Index", "SocialMediaConfig");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await _iSocialMediaConfigManager.GetSocialMediaConfigAsync(id);

                if (model != null)
                {
                    return View("Edit", model);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "SocialMediaConfigMessage");
                    return RedirectToAction("Index", "SocialMediaConfig");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Edit[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "SocialMediaConfigMessage");
            return RedirectToAction("Index", "SocialMediaConfig");
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var configViewModel = await _iSocialMediaConfigManager.GetSocialMediaConfigAsync(id);

                if (configViewModel != null)
                {
                    return View("Details", configViewModel);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "SocialMediaConfigMessage");
                    return RedirectToAction("Index", "SocialMediaConfig");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Details[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "SocialMediaConfigMessage");
            return RedirectToAction("Index", "SocialMediaConfig");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(SocialMediaConfigViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //add
                    if (viewModel.Id == 0)
                    {
                        _result = await _iSocialMediaConfigManager.InsertSocialMediaConfigAsync(viewModel);
                    }
                    else if (viewModel.Id > 0) //edit
                    {
                        _result = await _iSocialMediaConfigManager.UpdateSocialMediaConfigAsync(viewModel);
                    }

                    if (_result.Success)
                    {
                        this.FlashSuccess(MessageHelper.Save, "SocialMediaConfigMessage");
                        return RedirectToAction("Index", "SocialMediaConfig");
                    }
                    else
                    {
                        this.FlashError(_result.Error, "SocialMediaConfigMessage");
                        return View(viewModel);
                    }
                }
                else
                {
                    this.FlashError(ExceptionHelper.ModelStateErrorFirstFormat(ModelState), "SocialMediaConfigMessage");
                    return View(viewModel);
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Save[POST]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "SocialMediaConfigMessage");
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    _result = await _iSocialMediaConfigManager.DeleteSocialMediaConfigAsync(id);
                }
                else
                {
                    _result = Result.Fail(MessageHelper.DeleteFail);
                }

                if (_result.Success)
                {
                    this.FlashSuccess(MessageHelper.Delete, "SocialMediaConfigMessage");
                }
                else
                {
                    this.FlashError(_result.Error, "SocialMediaConfigMessage");
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
