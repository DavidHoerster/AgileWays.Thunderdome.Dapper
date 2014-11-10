using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileWays.ThunderDome.Dapper.Models
{
    public class PlayerSalaryHistory
    {
        public Player Player { get; set; }
        public IEnumerable<Salary> SalaryHistory { get; set; }
    }
}