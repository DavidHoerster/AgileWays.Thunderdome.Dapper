using AgileWays.ThunderDome.Dapper.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using System.Threading.Tasks;

namespace AgileWays.ThunderDome.Dapper.Repository.Command
{
    public class CreatePlayer
    {
        readonly IDbConnection _conn;
        const String _sql = @"INSERT INTO master (playerID, nameFirst, nameLast, nameGiven, bats, throws, weight, height)
                                VALUES(@PlayerId, @First, @Last, @Given, @Bats, @Throws, @Weight, @Height)";
        public CreatePlayer(IDbConnection ctx)
        {
            _conn = ctx;
        }

        public async Task<Int32> ExecuteAsync(Object parameters)
        {
            return await _conn.ExecuteAsync(_sql, parameters);
        }
    }
}