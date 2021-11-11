using Dapper.Contrib.Extensions;
using ecommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ecommerce.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public IDbConnection connection;

        public RepositoryBase(IDbConnection dbConnection)
        {
            connection = new SqlConnection(dbConnection.ConnectionString);
        }

        public Task<IEnumerable<T>> GetAll()
        {
            return connection.GetAllAsync<T>();
        }

        public void Dispose()
        {
            Dispose();
        }
    }
}
