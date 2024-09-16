using System.ComponentModel.DataAnnotations.Schema;

namespace March.Models
{
    [Table("UserLogins", Schema = "dbo")]
    public class UserLogins
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        public string ProviderDisplayName { get; set; }

        public int UserId { get; set; }
    }
}
