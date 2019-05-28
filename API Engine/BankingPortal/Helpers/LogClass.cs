using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Tracing;
using NLog;
using System.Net.Http;
using System.Text;
using BankingPortal.Helpers;

using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace BankingPortal.Helpers
{
    public class LogClass : ActionFilterAttribute, IExceptionFilter
    {
       

        public void LogExecutionTime(string data)
        {
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Data/Data.txt"), data);

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string message = "\n" + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "***"
                 + filterContext.ActionDescriptor.ActionName + "**On Action Executing \t- " + DateTime.Now.ToString() + "\n";
            LogExecutionTime(message);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string message = "\n" + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "***"
                   + filterContext.ActionDescriptor.ActionName + "**On Action Executed \t- " + DateTime.Now.ToString() + "\n";
            LogExecutionTime(message);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string message = "\n" +filterContext.RouteData.Values["controller"].ToString()+ "***"
                   + filterContext.RouteData.Values["action"].ToString() + "**On Result Executing \t- " + DateTime.Now.ToString() + "\n";
            LogExecutionTime(message);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string message = "\n" + filterContext.RouteData.Values["controller"].ToString() + "***"
                   + filterContext.RouteData.Values["action"].ToString() + "**On Result Executed \t- " + DateTime.Now.ToString() + "\n";
            LogExecutionTime(message);
        }
        public void OnException(ExceptionContext filterContext)
        {
            string message = "\n" + filterContext.RouteData.Values["controller"].ToString() + "***"
                  + filterContext.RouteData.Values["action"].ToString() + "**On Exception \t- " + filterContext.Exception.Message+ DateTime.Now.ToString() + "\n";
            LogExecutionTime(message);
        }
    }
}