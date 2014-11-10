using AgileWays.ThunderDome.Dapper.Attributes;
using AgileWays.ThunderDome.Dapper.Models;
using AgileWays.ThunderDome.Dapper.Repository.Command;
using AgileWays.ThunderDome.Dapper.Repository.Query;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AgileWays.ThunderDome.Dapper.Controllers.Api
{
    [DataContext]
    public class PlayerController : BaseDataApiController
    {
        public PlayerController()
        {
        }

        public async Task<Player> Get(String id, String year)
        {
            var results = await new GetPlayerByIdAndYear(Context)
                                    .QueryAsync(new { playerId = id, year = year });
            var player = results.FirstOrDefault();
            return player;
        }
        [Route("api/player/dynamic/{id}"), HttpGet]
        public async Task<Player> Dynamic(String id, String year)
        {
            var result = await new GetPlayerByIdAndYearDynamic(Context)
                                    .QueryAsync(new { playerId = id, year = year });
            return result;
        }

        [Route("api/player/history/{id}"), HttpGet]
        public async Task<PlayerSalaryHistory> History(String id)
        {
            var result = await new GetPlayerSalaryHistory(Context)
                                    .QueryAsync(new { playerId = id });
            return result;
        }

        [Route("api/player/create"), HttpGet]
        public async Task<Int32> Create()
        {
            var result = await new CreatePlayer(Context)
                                .ExecuteAsync(new[]{
                                    new{PlayerId = "zzhoer", First="David", Last="Hoerster", Given="David Hoerster", Bats="R", Throws="R"},
                                    new{PlayerId = "zzhoer1", First="Will", Last="Hoerster", Given="William Hoerster", Bats="R", Throws="L"}
                                });
            return result;
        }

        [Route("api/player/list"), HttpGet]
        public async Task<IEnumerable<Player>> GetPlayers(String player1, String player2)
        {
            var results = await new GetPlayersList(Context).QueryAsync(new { 
                PlayerIds = new String[] { player1, player2 } 
            });
            return results;
        }
    }
}
