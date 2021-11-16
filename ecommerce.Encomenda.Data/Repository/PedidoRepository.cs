using Dapper;
using ecommerce.Encomenda.Domain.Entities;
using ecommerce.Encomenda.Domain.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Encomenda.Data.Repository
{
    public class PedidoRepository : RepositoryBase<Pedido> , IPedidoRepository
    {
        public PedidoRepository(IDbConnection connection) : base(connection)
        {

        }

        public async Task<IEnumerable<Pedido>> GetPedidos()
        {
            var query = @"select 
                            pedido.Id,
                            pedido.DataCriacao,
                            pedido.DataEntrega,
                            pedido.Endereco,
                            prod.Id,
                            prod.Nome,
                            prod.Descricao,
                            prod.Valor,
                            eq.Id,
                            eq.Nome,
							eq.Descricao,
							eq.Placa
                         from Ecommerce.dbo.Pedido pedido
                            inner join Ecommerce.dbo.PedidoProdutos pp on pp.IdPedido = pedido.Id
                            inner join Ecommerce.dbo.Produto prod on prod.Id = pp.IdProduto
							inner join Ecommerce.dbo.PedidoEquipe pe on pe.IdPedido = pedido.Id
							inner join Ecommerce.dbo.Equipe eq on eq.Id = pe.IdEquipe
                         order by pedido.DataCriacao";

            var pedidos = new Dictionary<int, Pedido>();

           List<Pedido> _pedidos = (await _connection.QueryAsync<Pedido, Produto, Equipe, Pedido>(query, (pedido, produto, equipe) =>
              {
                  Pedido _pedido = null;

                  if (!pedidos.TryGetValue(pedido.Id, out _pedido))
                  {
                      pedidos.Add(pedido.Id, _pedido = pedido);
                  }

                  _pedido.AdicionarEquipeDoPedido(equipe);
                  _pedido.AdicionarProdutoPedido(produto);
                  
                  return _pedido;
              }, splitOn: "Id,Id,Id")).ToList();

            return _pedidos = pedidos.Values.ToList();
        }
    }
}
