using AgileWays.ThunderDome.Dapper.Attributes;
using MySql.Data.MySqlClient;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AgileWays.ThunderDome.Dapper
{
    public static class DependencyManagementConfig
    {
        public static void Config()
        {
            var container = new Container();

            container.Options.PropertySelectionBehavior = new ImportPropertySelectionBehavior();
            container.Register<IDbConnection>(() => new MySqlConnection("Server=localhost;Database=demo;Uid=root;Pwd=root;"));
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}