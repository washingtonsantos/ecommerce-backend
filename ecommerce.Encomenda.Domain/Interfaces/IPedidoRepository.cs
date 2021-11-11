using ecommerce.Encomenda.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.Encomenda.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> GetPedidos();
    }
}
