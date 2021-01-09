﻿using CurosOnline.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CursoOnline.Web.Filters
{
    public class CustonExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            bool isAjaxCall = context.HttpContext.Request.Headers["x-requested-with"] == "XMLHtmlRequest";

            if (isAjaxCall)
            {
                context.HttpContext.Response.ContentType = "application.json";
                context.HttpContext.Response.StatusCode = context.Exception is ExcecaoDeDominio  ? 502 : 500;
                context.Result = context.Exception is ExcecaoDeDominio dominio ?
                    new JsonResult(dominio.MensagensDeErro) :
                    new JsonResult("An error ocorred");
                context.ExceptionHandled = true;
            }
            base.OnException(context);
        }
    }
}