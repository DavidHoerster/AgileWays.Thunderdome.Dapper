using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgileWays.ThunderDome.Dapper.Controllers.Api
{
    public class BaseDataApiController : ApiController, IDataContextAware
    {
        public BaseDataApiController() { }
        public IDbConnection Context { get; set; }
    }
}
