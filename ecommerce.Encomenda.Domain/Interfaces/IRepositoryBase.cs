namespace ecommerce.Encomenda.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
       void Dispose();
    }
}
