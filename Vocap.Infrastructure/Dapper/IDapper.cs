using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocap.Infrastructure.Dapper
{
    public interface IDapper
    {
        Task<IEnumerable<T>?> GetAllAsync<T>(string query, object parameters = null);
        Task<T> QueryFirstAsync<T>(string query, object parameters = null);
    }
}
