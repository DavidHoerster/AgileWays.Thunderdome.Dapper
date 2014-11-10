using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileWays.ThunderDome.Dapper.Models
{
    public class Pitcher
    {
        public Int32 Year { get; set; }
        public Int32 Stint { get; set; }
        public String TeamId { get; set; }
        public Int32 Games { get; set; }
        public Int32 Wins { get; set; }
        public Int32 Losses { get; set; }
        public Int32 GamesStarted { get; set; }
        public Int32 CompleteGames { get; set; }
        public Int32 Saves { get; set; }
        public Int32 Shutouts { get; set; }
        public Int32 InningsPitchedOuts { get; set; }
        public Double Era { get; set; }
        public Int32 Strikeouts { get; set; }
    }
}
