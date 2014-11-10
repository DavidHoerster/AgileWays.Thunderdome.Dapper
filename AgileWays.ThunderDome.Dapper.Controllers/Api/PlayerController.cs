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
using System.Transactions;
using System.Web.Http;

namespace AgileWays.ThunderDome.Dapper.Controllers.Api
{
    [DataContext]
    public class PlayerController : BaseDataApiController
    {
        public PlayerController()
        {
        }

        public async Task<FullPlayer> Get(String id)
        {
            var player = await new GetFullPlayerInfo(Context)
                                    .QueryAsync(new { playerId = id });
            return player;
        }
        [Route("api/player/dynamic/{id}"), HttpGet]
        public async Task<Player> Dynamic(String id, String year)
        {
            var result = await new GetPlayerByIdAndYearDynamic(Context)
                                    .QueryAsync(new { playerId = id, year = year });
            return result;
        }

        //[Route("api/player/history/{id}"), HttpGet]
        //public async Task<PlayerSalaryHistory> History(String id)
        //{
        //    var result = await new GetPlayerSalaryHistory(Context)
        //                            .QueryAsync(new { playerId = id });
        //    return result;
        //}

        //[Route("api/player/create"), HttpGet]
        public async Task<Int32> Post([FromBody]Player player)
        {
            Int32 result = 0;
            using (var tranx = new TransactionScope(TransactionScopeOption.Required))
            {
                result = await new CreatePlayer(Context)
                                    .ExecuteAsync(new[]{
                                    new{PlayerId = player.PlayerId, 
                                        First=player.Name.First, 
                                        Last=player.Name.Last, 
                                        Given=player.Name.Given, 
                                        Bats=player.Bats, 
                                        Throws=player.Throws, 
                                        Weight=player.Weight, 
                                        Height=player.Height},
                                    new{PlayerId = "zzzzzz", 
                                        First="Will", 
                                        Last="Hoerster", 
                                        Given="William Hoerster", 
                                        Bats="R", 
                                        Throws="L",
                                        Weight=player.Weight,
                                        Height=player.Height}
                                    });

                result += await new CreateSalary(Context)
                                    .ExecuteAsync(new { PlayerId = player.PlayerId, Year = "2014", Amount = 10000000 });

                tranx.Complete();
            }
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

        [Route("api/player/lookup"), HttpGet]
        public async Task<IEnumerable<PlayerLookup>> PlayerLookup()
        {
            var players = await new GetPlayers(Context)
                                    .QueryAsync(new { });
            return players;
        }
    }
}
