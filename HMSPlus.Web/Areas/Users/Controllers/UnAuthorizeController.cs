﻿using HMSPlus.DataAccess.Contracts;
using HMSPlus.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMSPlus.Web.Areas.Users.Controllers
{
    public class UnAuthorizeController : BaseController
    {
        // GET: Users/UnAuthorize
        public ActionResult Index()
        {
            return View();
        }

        public UnAuthorizeController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}