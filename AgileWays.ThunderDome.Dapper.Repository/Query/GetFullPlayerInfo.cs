using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using AgileWays.ThunderDome.Dapper.Models;

namespace AgileWays.ThunderDome.Dapper.Repository.Query
{
    public class GetFullPlayerInfo
    {
         readonly IDbConnection _conn;
        const String _sql = @"SELECT playerID, weight, height, bats, throws, 
                                     nameFirst as First, nameLast as Last, nameGiven as Given
                                FROM master
                                WHERE playerID = @playerId;
                              SELECT playerID, yearID as Year, stint, teamID, G as Games, AB as AtBats,
                                     R as Runs, H as Hits, 2B as Doubles, 3B as Triples, HR as Homeruns,
                                     RBI as RunsBattedIn, BB as Walks, SB as StolenBases
                                FROM batting
                                WHERE playerID = @playerId
                                ORDER BY yearID DESC;
                               SELECT playerID, yearID as Year, stint, teamID, W as Wins, L as Losses, G as Games,
                                    GS as GamesStarted, CG as CompleteGames, SHO as Shutouts, SV as Saves,
                                    IPouts as InningsPitchedOuts, ERA as Era, SO as Strikeouts
                                FROM pitching
                                WHERE playerID = @playerId
                                ORDER BY yearID DESC;
                               SELECT yearID as Year, teamID, salary as Amount
                                FROM salaries
                                WHERE playerID = @playerId
                                ORDER BY yearID DESC";
        public GetFullPlayerInfo(IDbConnection ctx)
        {
            _conn = ctx;
        }

        public async Task<FullPlayer> QueryAsync(Object parameters)
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

                var batting = await multiResults.ReadAsync<Batter>();

                var pitching = await multiResults.ReadAsync<Pitcher>();

                var salaryHistory = await multiResults.ReadAsync<Salary>();

                var fullPlayer = new FullPlayer
                {
                    Player = player,
                    Batting = batting,
                    Pitching = pitching,
                    Salary = salaryHistory
                };

                return fullPlayer;
            }

        }
   }
}
