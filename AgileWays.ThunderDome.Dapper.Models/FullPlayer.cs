using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileWays.ThunderDome.Dapper.Models
{
    public class FullPlayer
    {
        public Player Player { get; set; }
        public IEnumerable<Batter> Batting { get; set; }
        public IEnumerable<Pitcher> Pitching { get; set; }
        public IEnumerable<Salary> Salary { get; set; }
    }
}
