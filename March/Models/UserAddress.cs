using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace March.Models
{
    [Table("UserAddress", Schema = "dbo")]
    public class UserAddress
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Zip {  get; set; }    
    }
}
