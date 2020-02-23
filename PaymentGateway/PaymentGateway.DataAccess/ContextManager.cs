using PaymentGateway.Domain.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace PaymentGateway.DataAccess
{
    //public class ContextManager : IContextManager
    //{               
        
    //    public ContextManager(IDbConnection connection)
    //    {
    //        _connection = connection;            
    //    }
       
    //    public async Task ExecuteAsync(string sql)
    //    {
    //        await ExecuteAsync(sql, null);
    //    }

    //    public async Task ExecuteAsync(string sql, object parameters)
    //    {
    //        try
    //        {
    //            _connection.Open();
    //            await _connection.ExecuteAsync(sql, parameters);
    //        }
    //        finally
    //        {
    //            _connection.Close();
    //        }
    //    }

    //    public async Task<IEnumerable<T>> QueryAsync<T>(string sql)
    //    {
    //        return await QueryAsync<T>(sql, null);
    //    }

    //    public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters)
    //    {
    //        IEnumerable<T> ret;

    //        try
    //        {
    //            _connection.Open();
    //            ret = await _connection.QueryAsync<T>(sql, parameters);
    //        }
    //        finally
    //        {
    //            _connection.Close();
    //        }

    //        return ret;
    //    }
    //}
}
