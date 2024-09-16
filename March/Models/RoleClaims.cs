using System.ComponentModel.DataAnnotations.Schema;

namespace March.Models
{
    [Table ("RoleClaims" , Schema = "dbo")]
    public class RoleClaims
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set;}
    }
}
