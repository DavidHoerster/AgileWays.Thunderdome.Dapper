using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
namespace AgileWays.ThunderDome.Dapper.Repository.Command
{
    public class CreateSalary
    {
        readonly IDbConnection _conn;
        const String _sql = @"INSERT INTO salaries (playerID, yearID, lgID, teamID, salary)
                                VALUES(@PlayerId, @Year, 'NL', 'PIT', @Amount)";
        public CreateSalary(IDbConnection ctx)
        {
            _conn = ctx;
        }

        public async Task<Int32> ExecuteAsync(Object parameters)
        {
            return await _conn.ExecuteAsync(_sql, parameters);
        }
    }
}
