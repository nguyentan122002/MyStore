using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace March.Models
{
    [Table("Orders", Schema = "dbo")]
    public class Orders
    {
        [Key]
        public int Id { get; set; } 

        public string BuyerId { get; set; }

        public string ShippingAddress_FullName { get; set; }

        public string ShippingAddress_Address1 { get; set; }

        public string ShippingAddress_Address2 { get; set; }

        public string ShippingAddress_City { get; set; }

        public string ShippingAddress_State { get; set; }

        public string ShippingAddress_Zip {  get; set; }

        public string ShippingAddress_Country { get; set; }

        public DateTime OrderDate { get; set;}

        public long Subtotal { get; set; }

        public long DeliveryFee { get; set; }

        public int OrderStatus { get; set; }

        public string PaymentIntentId { get; set; }

    }
}
