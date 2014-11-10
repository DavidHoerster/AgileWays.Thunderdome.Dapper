using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using AgileWays.ThunderDome.Dapper.Models;

namespace AgileWays.ThunderDome.Dapper.Repository.Query
{
    public class GetPlayerByIdAndYearDynamic
    {
        readonly IDbConnection _conn;
        const String _sql = @"SELECT playerID, weight, height, bats, throws, 
                                     nameFirst as First, nameLast as Last, nameGiven as Given
                                FROM master
                                WHERE playerID = @playerId";
        public GetPlayerByIdAndYearDynamic(IDbConnection ctx)
        {
            _conn = ctx;
        }

        public async Task<Player> QueryAsync(Object parameters)
        {
            var results = await _conn.QueryAsync(_sql, parameters);
            var result = results.FirstOrDefault();

            if (result!=null)
            {
                var player = new Player
                {
                    Bats = result.bats,
                    Height = result.height,
                    Name = new Name
                    {
                        First = result.First,
                        Last = result.Last,
                        Given = result.Given
                    },
                    PlayerId = result.playerID,
                    Team = new Team(),
                    Throws = result.throws,
                    Weight = result.weight
                };
                return player;
            }
            return null;
        }
    }
}