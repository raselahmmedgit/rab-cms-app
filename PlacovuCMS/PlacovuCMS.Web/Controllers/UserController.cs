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
    public class UserController : BaseController
    {
        #region Global Variable Declaration
        private readonly IMapper _iMapper;
        private readonly ILog _log;
        #endregion

        #region Constructor
        public UserController(IMapper iMapper
        )
        {
            _iMapper = iMapper;
            _log = LogManager.GetLogger(typeof(UserController));
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
        #endregion
    }
}
