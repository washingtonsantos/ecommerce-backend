namespace ecommerce.Encomenda.Domain.Entities
{
    public class PedidoProduto : Entity
    {
        public int IdPedido { get; private set; }
        public int IdProduto { get; private set; }
    }
}
