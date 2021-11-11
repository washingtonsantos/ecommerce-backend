using ecommerce.Encomenda.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.Encomenda.Application.Interfaces
{
    public interface IPedidoApplicationService
    {
        Task<IEnumerable<PedidoViewModel>> ObterPedidos();
    }
}
