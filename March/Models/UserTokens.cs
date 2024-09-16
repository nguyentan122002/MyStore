using System.ComponentModel.DataAnnotations.Schema;

namespace March.Models
{
    [Table("UserTokens", Schema = "dbo")]
    public class UserTokens
    {
        public int  UserId { get; set; }

        public string LoginProvider { get; set; }

        public string  Name { get; set; }

        public string Value { get; set; }
    }
}
