using ecommerce.Encomenda.Domain.Interfaces;
using System.Data;

namespace ecommerce.Encomenda.Data.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public IDbConnection _connection;

        public RepositoryBase(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Dispose()
        {
            Dispose();
        }
    }
}
