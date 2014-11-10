using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileWays.ThunderDome.Dapper.Models
{
    public class Batter : Player
    {
        public Int32 Year { get; set; }
        public Int32 Stint { get; set; }
        public String TeamId { get; set; }
        public Int32 Games { get; set; }
        public Int32 AtBats { get; set; }
        public Int32 Runs { get; set; }
        public Int32 Hits { get; set; }
        public Int32 Doubles { get; set; }
        public Int32 Triples { get; set; }
        public Int32 HomeRuns { get; set; }
        public Int32 RunsBattedIn { get; set; }
        public Int32 Walks { get; set; }
        public Int32 StolenBases { get; set; }

    }
}