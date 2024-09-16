using System.ComponentModel.DataAnnotations.Schema;

namespace March.Models
{
    [Table("Roles", Schema = "dbo")]
    public class Roles
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}
