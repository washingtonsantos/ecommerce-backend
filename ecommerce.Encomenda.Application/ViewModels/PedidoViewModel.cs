using System;
using System.Collections.Generic;

namespace ecommerce.Encomenda.Application.ViewModels
{
    public class PedidoViewModel
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataEntrega { get; set; }
        public string Endereco { get; set; }
        public List<ProdutoViewModel> Itens { get; set; }
        public EquipeViewModel Equipe { get; set; }
    }
}
