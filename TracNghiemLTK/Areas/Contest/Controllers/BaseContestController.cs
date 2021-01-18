using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TracNghiemLTK.Common;

namespace TracNghiemLTK.Areas.Contest.Controllers
{
    public class BaseContestController : Controller
    {
			protected override void OnActionExecuting(ActionExecutingContext filterContext)
			{
				var sesson = (ThiSinhInfo)Session[CommonConstantsStudent.STUDENT_SESSION];
				if (sesson == null)
				{
					filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index", Area = "" }));
				}
				base.OnActionExecuting(filterContext);
			}
	}
}