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
    public class EmailSmsConfigController : BaseController
    {
        #region Global Variable Declaration
        private readonly IMapper _iMapper;
        private readonly IEmailSmsConfigManager _iEmailSmsConfigManager;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public EmailSmsConfigController(IEmailSmsConfigManager iEmailSmsConfigManager
            , IMapper iMapper
        )
        {
            _iEmailSmsConfigManager = iEmailSmsConfigManager;
            _iMapper = iMapper;
            _log = LogManager.GetLogger(typeof(EmailSmsConfigController));
        }
        #endregion

        #region Actions
        [HttpGet]
        [Route("/EmailSmsConfig/GetDataAsync")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public async Task<IActionResult> GetDataAsync(IDataTablesRequest request)
        {
            try
            {
                DataTablesResponse response = await _iEmailSmsConfigManager.GetDataTablesResponseAsync(request);
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
                return View(new EmailSmsConfigViewModel());
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
                var isAdded = await _iEmailSmsConfigManager.GetEmailSmsConfigsAsync();
                if (isAdded.Any())
                {
                    this.FlashSuccess(MessageHelper.AlreadyAdded, "EmailSmsConfigMessage");
                    return RedirectToAction("Index", "EmailSmsConfig");
                }

                var model = new EmailSmsConfigViewModel();
                if (model != null)
                {
                    return View("Add", model);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "EmailSmsConfigMessage");
                    return RedirectToAction("Index", "EmailSmsConfig");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Add[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "EmailSmsConfigMessage");
            return RedirectToAction("Index", "EmailSmsConfig");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await _iEmailSmsConfigManager.GetEmailSmsConfigAsync(id);

                if (model != null)
                {
                    return View("Edit", model);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "EmailSmsConfigMessage");
                    return RedirectToAction("Index", "EmailSmsConfig");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Edit[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "EmailSmsConfigMessage");
            return RedirectToAction("Index", "EmailSmsConfig");
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var configViewModel = await _iEmailSmsConfigManager.GetEmailSmsConfigAsync(id);

                if (configViewModel != null)
                {
                    return View("Details", configViewModel);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "EmailSmsConfigMessage");
                    return RedirectToAction("Index", "EmailSmsConfig");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Details[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "EmailSmsConfigMessage");
            return RedirectToAction("Index", "EmailSmsConfig");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(EmailSmsConfigViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //add
                    if (viewModel.Id == 0)
                    {
                        _result = await _iEmailSmsConfigManager.InsertEmailSmsConfigAsync(viewModel);
                    }
                    else if (viewModel.Id > 0) //edit
                    {
                        _result = await _iEmailSmsConfigManager.UpdateEmailSmsConfigAsync(viewModel);
                    }

                    if (_result.Success)
                    {
                        this.FlashSuccess(MessageHelper.Save, "EmailSmsConfigMessage");
                        return RedirectToAction("Index", "EmailSmsConfig");
                    }
                    else
                    {
                        this.FlashError(_result.Error, "EmailSmsConfigMessage");
                        return View(viewModel);
                    }
                }
                else
                {
                    this.FlashError(ExceptionHelper.ModelStateErrorFirstFormat(ModelState), "EmailSmsConfigMessage");
                    return View(viewModel);
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Save[POST]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "EmailSmsConfigMessage");
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    _result = await _iEmailSmsConfigManager.DeleteEmailSmsConfigAsync(id);
                }
                else
                {
                    _result = Result.Fail(MessageHelper.DeleteFail);
                }

                if (_result.Success)
                {
                    this.FlashSuccess(MessageHelper.Delete, "EmailSmsConfigMessage");
                    return RedirectToAction("Index", "EmailSmsConfig");
                }
                else
                {
                    this.FlashError(_result.Error, "EmailSmsConfigMessage");
                    return RedirectToAction("Index", "EmailSmsConfig");
                }
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
