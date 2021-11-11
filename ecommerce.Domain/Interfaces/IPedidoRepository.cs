using ecommerce.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.Domain.Interfaces
{
    public interface IPedidoRepository : IRepositoryBase<Pedido>
    {
        Task<IEnumerable<Pedido>> GetPedidos();
    }
}
