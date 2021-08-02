using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagmen.Controllers
{
    public class ErrorController : Controller
    {
        private ILogger<ErrorController> logger;

        //using asp.net core, injectionDependcy ILogger servece
        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }


        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {

            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the page you asking is not exist";
                    logger.LogWarning($"404 Error.");

                    //ViewBag.Path = statusCodeResult.OriginalPath;
                    //ViewBag.QueryStr = statusCodeResult.OriginalQueryString;
                    //ViewBag.BasePath = statusCodeResult.OriginalPathBase;
                    break;
            }
            return View("NotFound");
        }

        [AllowAnonymous]
        [Route("Error")]
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            //logger.LogError($"Path{exceptionHandlerPathFeature.Path}, have a error{exceptionHandlerPathFeature.Path}");
            ViewBag.ExceptionPath = exceptionHandlerPathFeature.Path;
            ViewBag.ExceptionMessage = exceptionHandlerPathFeature.Error.Message;
            ViewBag.StackTrace = exceptionHandlerPathFeature.Error.StackTrace;

            return View("Error");
        }
    }
}
