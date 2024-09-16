using System.ComponentModel.DataAnnotations.Schema;

namespace March.Models
{
    //[Table("Baskets", Schema ="dbo")]
    public class Basket
    {
        public int Id { get; set; }

        public string BuyerId { get; set; }

        public List<BasketItem> Items { get; set; } = new();
        // List<BasketItem>()
        public void AddItem(Products product, int quantity)
        {
            if (Items.All(item => item.ProductId != product.Id))
            {
                Items.Add(new BasketItem { Product = product, Quantity = quantity });
            }

            var existingItem = Items.FirstOrDefault(item => item.ProductId == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
        }


        public void RemoveItem(int productId, int quantity)
        {
            var item = Items.FirstOrDefault(item => item.ProductId == productId);

            if (item != null)
            {
                item.Quantity -= quantity;
            }

            else
            {
                return;
            }

            if (item.Quantity == 0)
            {
                Items.Remove(item);
            }
        }
        public string PaymentIntentId { get; set; }

        public string ClientSecret { get; set; }
    }
}
