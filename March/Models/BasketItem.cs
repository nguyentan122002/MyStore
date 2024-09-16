using System.ComponentModel.DataAnnotations.Schema;

namespace March.Models
{
    [Table("BasketItem")]
    public class BasketItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public Products Product { get; set; }

        public int BasketId { get; set; }

        public Basket Baskets { get; set; }

    }
}
