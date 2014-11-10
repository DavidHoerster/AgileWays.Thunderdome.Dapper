using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgileWays.ThunderDome.Dapper.Controllers.Mvc
{
    public class BaseDataMvcController : Controller
    {
        protected IDbConnection Context { get; set; }
    }
}