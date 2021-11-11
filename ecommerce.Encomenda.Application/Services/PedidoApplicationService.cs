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
        private readonly AutoMapper.MapperConfiguration _config;

        public PedidoApplicationService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;

            _config = new AutoMapper.MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Domain.Entities.Produto, ProdutoViewModel>();
                cfg.CreateMap<Domain.Entities.Equipe, EquipeViewModel>();
                cfg.CreateMap<Domain.Entities.Pedido, PedidoViewModel>().
                   ForMember(destino => destino.ProdutosViewModel, origem => origem.MapFrom(x => x.Produtos)).
                   ForMember(destino => destino.EquipeViewModel, origem => origem.MapFrom(x => x.Equipe));
            });
        }

        public async Task<IEnumerable<PedidoViewModel>> ObterPedidos()
        {

           var pedidosDomain =  await _pedidoRepository.GetPedidos();

           var pedidosViewModel = _config.CreateMapper().Map< IEnumerable<Domain.Entities.Pedido>, IEnumerable<PedidoViewModel>>(pedidosDomain);

           return pedidosViewModel;
        }

    }
}
