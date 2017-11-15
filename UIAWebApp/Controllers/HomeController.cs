using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Security.Claims;


namespace UIAWebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var cp = (ClaimsPrincipal)System.Web.HttpContext.Current.User;
           Models.GlobalVariables.fullname = "";
            Models.GlobalVariables.role = cp.FindFirst("roles").Value;
            Models.GlobalVariables.fullname = cp.FindFirst("name").Value;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}