using System.Collections.Generic;

namespace ecommerce.Encomenda.Domain.Entities
{
    public class PagedResults<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
