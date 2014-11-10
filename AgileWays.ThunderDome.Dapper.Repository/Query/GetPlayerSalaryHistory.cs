using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using AgileWays.ThunderDome.Dapper.Models;
using System.Threading.Tasks;

namespace AgileWays.ThunderDome.Dapper.Repository.Query
{
    public class GetPlayerSalaryHistory
    {
        readonly IDbConnection _conn;
        const String _sql = @"SELECT playerID, weight, height, bats, throws, 
                                     nameFirst as First, nameLast as Last, nameGiven as Given
                                FROM master
                                WHERE playerID = @playerId;
                              SELECT yearID as Year, teamID, salary as Amount
                                FROM salaries
                                WHERE playerID = @playerId";
        public GetPlayerSalaryHistory(IDbConnection ctx)
        {
            _conn = ctx;
        }

        public async Task<PlayerSalaryHistory> QueryAsync(Object parameters)
        {
            using (var multiResults = await _conn.QueryMultipleAsync(_sql, parameters))
            {
                var player = multiResults.Read<Player, Name, Player>((p, n) =>
                                    {
                                        p.Name = n;
                                        return p;
                                    }, 
                                splitOn: "First")
                             .FirstOrDefault();
                var salaryHistory = await multiResults.ReadAsync<Salary>();

                var history = new PlayerSalaryHistory
                {
                    Player = player,
                    SalaryHistory = salaryHistory
                };
                return history;
            }
        }
    }
}