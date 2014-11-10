using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgileWays.ThunderDome.Dapper.Controllers.Mvc
{
    public class HomeController : BaseDataMvcController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}