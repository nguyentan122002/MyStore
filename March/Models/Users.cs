using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace March.Models
{
    [Table("Users", Schema = "dbo")]
    public class Users
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string NormalizedUserName { get; set; }

        public string Email { get; set; }

        public string NormalizedEmail { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string ConcurrencyStamp { get; set; }

        public  string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime LockoutEnd { get; set; }

        public bool LockoutEnabled { get; set; }

        public bool AccessFailedCount { get; set; }


    }
}
