using AutoMapper;
using ecommerce.Encomenda.Application.ViewModels;

namespace ecommerce.WebApi.Config.AutoMapper
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile()
        {
            CreateMap<Encomenda.Domain.Entities.Produto, ProdutoViewModel>();
            CreateMap<Encomenda.Domain.Entities.Equipe, EquipeViewModel>();
            CreateMap<Encomenda.Domain.Entities.Pedido, PedidoViewModel>().
               ForMember(destino => destino.Itens, origem => origem.MapFrom(x => x.Produtos)).
               ForMember(destino => destino.Equipe, origem => origem.MapFrom(x => x.Equipe));
        }
    }
}
