using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace March.Models
{
    [Table("Products", Schema = "dbo")]
    public class Products
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long Price { get; set; }

        public string PictureUrl { get; set; }

        public string Type { get; set;}

        public string Brand { get; set; }

        public int QuantityInStock { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
