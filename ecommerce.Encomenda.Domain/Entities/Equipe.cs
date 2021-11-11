using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Encomenda.Domain.Entities
{
    public class Equipe : Entity
    {
        protected Equipe() { }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Placa { get; private set; }
    }
}
