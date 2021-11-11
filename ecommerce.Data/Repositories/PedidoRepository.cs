using Dapper;
using ecommerce.Domain.Entities;
using ecommerce.Domain.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Data.Repositories
{
    public class PedidoRepository : RepositoryBase<Pedido>, IPedidoRepository
    {
        public PedidoRepository(IDbConnection dbconnection) : base(dbconnection)
        {
           
        }

        public Task<IEnumerable<Pedido>> GetPedidos()
        {
            var query = @"SELECT 
                            PEd.Id, 
                            PEd.DataCriacao, 
                            PEd.DataEntregaRealizada, 
                            PEd.Endereco,
                            Prod.*
                         FROM Pedido Ped
                            INNER JOIN PedidoProdutos PedProd on PedProd.IdPedido = Ped.Id
                            INNER JOIN Produto Prod on Prod.Id = PedProd.IdProduto
                         ORDER BY Ped.DataCriacao";

            return connection.QueryAsync<Pedido, Produto, Pedido>(query, 
                               (pedido, produto) =>
                           {
                               pedido.Produtos.Add(produto);
                               return pedido;
                           }, splitOn: "Id, Id");
        }
    }
}
