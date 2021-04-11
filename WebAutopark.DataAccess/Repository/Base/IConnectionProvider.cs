using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace WebAutopark.DataAccess.Repository.Base
{
    public interface IConnectionProvider
    {
        DbConnection GetConnection();
    }
}
