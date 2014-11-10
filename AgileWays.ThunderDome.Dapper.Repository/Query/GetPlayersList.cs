using AgileWays.ThunderDome.Dapper.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dapper;

namespace AgileWays.ThunderDome.Dapper.Repository.Query
{
    public class GetPlayersList
    {
        readonly IDbConnection _conn;
        const String _sql = @"SELECT playerID, weight, height, bats, throws, 
                                     nameFirst as First, nameLast as Last, nameGiven as Given
                                FROM master
                                WHERE playerID in @PlayerIds";
        public GetPlayersList(IDbConnection ctx)
        {
            _conn = ctx;
        }

        public async Task<IEnumerable<Player>> QueryAsync(Object parameters)
        {
            return await _conn.QueryAsync<Player, Name, Player>(
                                        _sql,
                                        (p, n) =>
                                        {
                                            p.Name = n;
                                            return p;
                                        },
                                        parameters,
                                        splitOn: "First"
                                        );
        }
    }
}