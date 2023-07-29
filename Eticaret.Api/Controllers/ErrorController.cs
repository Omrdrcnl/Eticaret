﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleError()
        {
            return Problem();
        }

        /*
        * Yazılım geliştirme aşamasında ise, debug modunda yani biz yazılımcılar hatayla ilgili daha fazla bilgi görmek istediğimizde
        * burası çalışacak
        */
        [Route("/error-development")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return Problem(detail: exceptionHandlerFeature.Error.StackTrace, title: exceptionHandlerFeature.Error.Message);
        }

        //[Route("Error")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        //public IActionResult HandleError() => Problem();


        //[Route("/Error-devolepment")]
        //[ApiExplorerSettings(IgnoreApi =true)]

        //public IActionResult HandleErrorDevolopment([FromServices] IHostEnvironment hostEnvironment)
        //{
        //    if (!hostEnvironment.IsDevelopment())
        //    {
        //        return NotFound();
        //    }

        //    var exeptionHanlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();

        //    return Problem(detail: exeptionHanlerFeature.Error.StackTrace, title: exeptionHanlerFeature.Error.Message);
        //}


    }


}



