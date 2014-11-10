using AgileWays.ThunderDome.Dapper.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace AgileWays.ThunderDome.Dapper.Attributes
{
    public class DataContextAttribute : ActionFilterAttribute
    {
        [Import]
        public IDbConnection Context { get; set; }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            ((IDataContextAware)actionContext.ControllerContext.Controller).Context = Context;
            Context.Open();
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Context.Close();
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}