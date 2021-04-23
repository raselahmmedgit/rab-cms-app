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
    public class ContactUsConfigController : BaseController
    {
        #region Global Variable Declaration
        private readonly IMapper _iMapper;
        private readonly IContactUsConfigManager _iContactUsConfigManager;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public ContactUsConfigController(IContactUsConfigManager iContactUsConfigManager
            , IMapper iMapper
        )
        {
            _iContactUsConfigManager = iContactUsConfigManager;
            _iMapper = iMapper;
            _log = LogManager.GetLogger(typeof(ContactUsConfigController));
        }
        #endregion

        [HttpGet]
        [Route("/ContactUsConfig/GetDataAsync")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public async Task<IActionResult> GetDataAsync(IDataTablesRequest request)
        {
            try
            {
                DataTablesResponse response = await _iContactUsConfigManager.GetDataTablesResponseAsync(request);
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
                return View(new ContactUsConfigViewModel());
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
                var isAdded = await _iContactUsConfigManager.GetContactUsConfigsAsync();
                if (isAdded.Any())
                {
                    this.FlashSuccess(MessageHelper.AlreadyAdded, "ContactUsConfigMessage");
                    return RedirectToAction("Index", "ContactUsConfig");
                }

                var model = new ContactUsConfigViewModel();
                if (model != null)
                {
                    return View("Add", model);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "ContactUsConfigMessage");
                    return RedirectToAction("Index", "ContactUsConfig");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Add[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "ContactUsConfigMessage");
            return RedirectToAction("Index", "ContactUsConfig");
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await _iContactUsConfigManager.GetContactUsConfigAsync(id);

                if (model != null)
                {
                    return View("Edit", model);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "ContactUsConfigMessage");
                    return RedirectToAction("Index", "ContactUsConfig");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Edit[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "ContactUsConfigMessage");
            return RedirectToAction("Index", "ContactUsConfig");
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var configViewModel = await _iContactUsConfigManager.GetContactUsConfigAsync(id);

                if (configViewModel != null)
                {
                    return View("Details", configViewModel);
                }
                else
                {
                    this.FlashError(ExceptionHelper.ExceptionErrorMessageForNullObject(), "ContactUsConfigMessage");
                    return RedirectToAction("Index", "ContactUsConfig");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Details[GET]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "ContactUsConfigMessage");
            return RedirectToAction("Index", "ContactUsConfig");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(ContactUsConfigViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //add
                    if (viewModel.Id == 0)
                    {
                        _result = await _iContactUsConfigManager.InsertContactUsConfigAsync(viewModel);
                    }
                    else if (viewModel.Id > 0) //edit
                    {
                        _result = await _iContactUsConfigManager.UpdateContactUsConfigAsync(viewModel);
                    }

                    if (_result.Success)
                    {
                        this.FlashSuccess(MessageHelper.Save, "ContactUsConfigMessage");
                        return RedirectToAction("Index", "ContactUsConfig");
                    }
                    else
                    {
                        this.FlashError(_result.Error, "ContactUsConfigMessage");
                        return View(viewModel);
                    }
                }
                else
                {
                    this.FlashError(ExceptionHelper.ModelStateErrorFirstFormat(ModelState), "ContactUsConfigMessage");
                    return View(viewModel);
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Save[POST]"));
            }

            this.FlashError(MessageHelper.UnhandelledError, "ContactUsConfigMessage");
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    _result = await _iContactUsConfigManager.DeleteContactUsConfigAsync(id);
                }
                else
                {
                    _result = Result.Fail(MessageHelper.DeleteFail);
                }

                if (_result.Success)
                {
                    this.FlashSuccess(MessageHelper.Delete, "ContactUsConfigMessage");
                    return RedirectToAction("Index", "ContactUsConfig");
                }
                else
                {
                    this.FlashError(_result.Error, "ContactUsConfigMessage");
                    return RedirectToAction("Index", "ContactUsConfig");
                }
            }
            catch (Exception ex)
            {
                _log.Error(LogMessageHelper.FormateMessageForException(ex, "Delete[POST]"));
                _result = Result.Fail(MessageHelper.UnhandelledError);
                return JsonResult(_result);
            }
        }
    }
}
