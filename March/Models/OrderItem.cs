using System.ComponentModel.DataAnnotations.Schema;

namespace March.Models
{
    [Table("OrderItem", Schema ="dbo")]
    public class OrderItem
    {
        public int Id { get; set; }

        public int ItemOrdered_ProductId { get; set; }

        public string ItemOrdered_Name { get; set; }

        public string ItemOrdered_PictureUrl { get; set; }

        public long Price { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }
    }
}
