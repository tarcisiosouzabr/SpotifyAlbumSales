﻿using EasySoccer.WebApi.UoWs;
using Microsoft.AspNetCore.Mvc;

namespace EasySoccer.WebApi.Controllers.Base
{
    public class ApiBaseController : Controller
    {
        private UoWBase _uow;
        public ApiBaseController(UoWBase uow)
        {
            _uow = uow;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
                _uow.Dispose();
        }
    }
}
