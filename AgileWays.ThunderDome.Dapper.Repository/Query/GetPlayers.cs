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
    public class GetPlayers
    {
        readonly IDbConnection _conn;
        const String _sql = @"SELECT DISTINCT playerID as Id, CONCAT(nameLast,', ', nameFirst) as Name
                                FROM master
                                ORDER BY Name";
        public GetPlayers(IDbConnection ctx)
        {
            _conn = ctx;
        }

        public async Task<IEnumerable<PlayerLookup>> QueryAsync(Object parameters)
        {
            return await _conn.QueryAsync<PlayerLookup>(_sql);
        }
    }
}