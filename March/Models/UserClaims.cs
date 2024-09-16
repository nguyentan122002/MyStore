using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace March.Models
{
    [Table("UserClaims", Schema = "dbo")]
    public class UserClaims
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }
    }
}
