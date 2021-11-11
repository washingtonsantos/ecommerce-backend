namespace ecommerce.Encomenda.Domain.Entities
{
    public class Produto : Entity
    {
        protected Produto() { }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
    }
}
