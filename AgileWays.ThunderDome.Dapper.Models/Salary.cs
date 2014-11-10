using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileWays.ThunderDome.Dapper.Models
{
    public class Salary
    {
        public Int32 Year { get; set; }
        public String PlayerId { get; set; }
        public String TeamId { get; set; }
        public Double Amount { get; set; }
    }
}