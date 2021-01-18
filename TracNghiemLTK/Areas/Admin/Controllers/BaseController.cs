using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TracNghiemLTK.Common;

namespace TracNghiemLTK.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var sesson = (ManagerInfo)Session[CommonConstantsManager.MANAGER_SESSION];
			if (sesson == null)
			{
				filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
			}
			base.OnActionExecuting(filterContext);
		}
		protected void SetAlert(string message, string type)
		{
			TempData["AlertMessage"] = message;
			if(type == "success")
			{
				TempData["AlertType"] = "arlert-success";
			}
			else
				if(type == "warning")
			{
				TempData["AlertType"] = "alert-warning";
			}
			else
				if(type == "error")
			{
				TempData["ArlertType"] = "alert-danger";
			}
		}
	}
}
