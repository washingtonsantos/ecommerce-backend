using ecommerce.Encomenda.Application.ViewModels;
using ecommerce.Encomenda.Domain.Entities;
using System.Threading.Tasks;

namespace ecommerce.Encomenda.Application.Interfaces
{
    public interface IPedidoApplicationService
    {
        Task<PagedResults<PedidoViewModel>> ObterPedidos(int numeroPagina, int linhasPorPagina);
    }
}
