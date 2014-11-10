using AgileWays.ThunderDome.Dapper.Models;
using SolrNet;
using SolrNet.Commands.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AgileWays.ThunderDome.Dapper.Controllers.Api
{
    public class SearchController : ApiController
    {
        private readonly ISolrOperations<PlayerLookup> _search;
        public SearchController(ISolrOperations<PlayerLookup> search)
        {
            _search = search;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get(String q)
        {
            var options = new QueryOptions
            {
                Highlight = new HighlightingParameters
                {
                    AfterTerm = "</em></strong>",
                    BeforeTerm = "<strong><em>",
                    Fields = new List<String> { "firstName", "lastName" },
                    Fragsize = 100
                },
                Fields = new List<String> { "playerId", "firstName", "lastName" }
            };
            var results = _search.Query("firstName:" + q + "* lastName:" + q + "*", options) as SolrQueryResults<PlayerLookup>;

            var newResult = results.Select(r => new
            {
                PlayerName = r.FirstName + " " + r.LastName,
                PlayerId = r.PlayerId
            }).Distinct();

            return this.Request.CreateResponse(HttpStatusCode.OK, newResult);
        }
    }
}
