using System.ComponentModel.DataAnnotations.Schema;

namespace March.Models
{
    [Table("UserRoles", Schema = "dbo")]
    public class UserRoles
    {
        public int Id { get; set; }

        public int RoleId { get; set; }
    }
}
