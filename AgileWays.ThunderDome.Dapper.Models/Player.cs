using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileWays.ThunderDome.Dapper.Models
{
    public class Player
    {
        public String PlayerId { get; set; }
        public Name Name { get; set; }

        public Int32 Weight { get; set; }
        public Double Height { get; set; }
        public String Bats { get; set; }
        public String Throws { get; set; }
        public Team Team { get; set; }
    }
}