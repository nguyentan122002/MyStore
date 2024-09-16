using March.Models;
using Microsoft.EntityFrameworkCore;

namespace March.Context
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Products> Products { get; set; }

        public DbSet<Basket> Baskets { get; set; }
    }
}
