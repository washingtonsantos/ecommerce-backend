using Dapper;
using ecommerce.Encomenda.Domain.Entities;
using ecommerce.Encomenda.Domain.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Encomenda.Data.Repository
{
    public class PedidoRepository : RepositoryBase<Pedido> , IPedidoRepository
    {
        string _connectionString;

        public PedidoRepository(IDbConnection connection) : base(connection)
        {
            _connectionString = connection.ConnectionString;
        }

        public async Task<PagedResults<Pedido>> GetPedidos(int numeroPagina, int linhasPorPagina = 20)
        {
            int skip = (numeroPagina - 1) * linhasPorPagina;
            var results = new PagedResults<Pedido>();

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
                         order by pedido.DataCriacao
						 OFFSET @skip ROWS FETCH NEXT @linhasPorPagina ROWS ONLY
                    ";

            var queryTotal = @"select COUNT(*)                           
                         from Ecommerce.dbo.Pedido pedido
                            inner join Ecommerce.dbo.PedidoProdutos pp on pp.IdPedido = pedido.Id
                            inner join Ecommerce.dbo.Produto prod on prod.Id = pp.IdProduto
							inner join Ecommerce.dbo.PedidoEquipe pe on pe.IdPedido = pedido.Id
							inner join Ecommerce.dbo.Equipe eq on eq.Id = pe.IdEquipe";

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
                   },
                    param: new { skip, linhasPorPagina },
                    splitOn: "Id,Id,Id"))
                      .ToList();              
                results.Items = _pedidos;

            var total = (await _connection.QueryAsync<int>(queryTotal)).FirstOrDefault();
                results.TotalCount = total;

            return results;
        }
    }
}
