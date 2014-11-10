using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileWays.ThunderDome.Dapper.Controllers
{
    public interface IDataContextAware
    {
        IDbConnection Context { get; set; }
    }
}
