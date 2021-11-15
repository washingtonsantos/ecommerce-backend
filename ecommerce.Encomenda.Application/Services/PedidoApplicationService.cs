using AutoMapper;
using ecommerce.Encomenda.Application.Interfaces;
using ecommerce.Encomenda.Application.ViewModels;
using ecommerce.Encomenda.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.Encomenda.Application.Services
{
    public class PedidoApplicationService : IPedidoApplicationService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidoApplicationService(IMapper mapper, IPedidoRepository pedidoRepository)
        {
            _mapper = mapper;
            _pedidoRepository = pedidoRepository;
        }

        public async Task<IEnumerable<PedidoViewModel>> ObterPedidos()
        {

           var pedidosDomain =  await _pedidoRepository.GetPedidos();

           var pedidosViewModel = _mapper.Map<IEnumerable<Domain.Entities.Pedido>, IEnumerable<PedidoViewModel>>(pedidosDomain);

           return pedidosViewModel;
        }

    }
}
