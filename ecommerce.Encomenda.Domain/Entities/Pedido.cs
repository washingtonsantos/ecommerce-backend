using System;
using System.Collections.Generic;

namespace ecommerce.Encomenda.Domain.Entities
{
    public class Pedido : Entity
    {
        protected Pedido() 
        {
            produtos = new List<Produto>();
        }

        public DateTime DataCriacao { get; private set; }
        public DateTime DataEntregaRealizada { get; private set; }
        public string Endereco { get; private set; }

        private readonly List<Produto> produtos;
        public IReadOnlyCollection<Produto> Produtos => produtos;

        public Equipe Equipe { get; private set; }

        public void AdicionarProdutoPedido(Produto produto)
        {
            produtos.Add(produto);
        }

        public void AdicionarEquipeDoPedido(Equipe equipe)
        {
            Equipe = equipe;
        }
    }
}
