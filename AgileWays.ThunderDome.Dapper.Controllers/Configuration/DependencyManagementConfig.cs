using AgileWays.ThunderDome.Dapper.Attributes;
using AgileWays.ThunderDome.Dapper.Models;
using Microsoft.Practices.ServiceLocation;
using MySql.Data.MySqlClient;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SolrNet;
using SolrNet.Mapping;
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
            var mgr = new MappingManager();
            var playerType = typeof(PlayerLookup);
            var idProp = playerType.GetProperty("Id");
            mgr.Add(idProp, "id");
            mgr.SetUniqueKey(idProp);
            mgr.Add(playerType.GetProperty("PlayerId"), "playerId");
            mgr.Add(playerType.GetProperty("FirstName"), "firstName");
            mgr.Add(playerType.GetProperty("LastName"), "lastName");

            Startup.Container.RemoveAll<IReadOnlyMappingManager>();
            Startup.Container.Register<IReadOnlyMappingManager>(c => mgr);
            Startup.Init<PlayerLookup>("http://localhost:8983/solr/baseball");

            var container = new Container();

            container.Options.PropertySelectionBehavior = new ImportPropertySelectionBehavior();
            container.Register<IDbConnection>(() => new MySqlConnection("Server=localhost;Database=demo;Uid=root;Pwd=root;"));
            container.RegisterWebApiRequest<ISolrOperations<PlayerLookup>>(() => ServiceLocator.Current.GetInstance<ISolrOperations<PlayerLookup>>(), false);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}