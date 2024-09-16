using March.Context;
using March.Dtos;
using March.Dtos.Input;
using March.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace March.Services
{
    public class ProductServices : IProductServices
    {
        private StoreDbContext _context;
        public ProductServices(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await _context.Products.Where(o => o.IsDeleted == false).Select(a => new ProductDto
            {
                Id = a.Id, 
                Name = a.Name,
                Description = a.Description,
                PictureUrl = a.PictureUrl,
                Price = a.Price,
                Type = a.Type,
                Brand = a.Brand,
                QuantityInStock = a.QuantityInStock,
            }).ToListAsync();
            return products;
        }

        public async Task<ProductDto> GetProductsAsync( int id)
        {
            var product = await _context.Products.Where(o => o.IsDeleted == false).SingleOrDefaultAsync(product => product.Id == id);
            if (product != null)
            {
                return new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    PictureUrl = product.PictureUrl,
                    Price = product.Price,
                    Type = product.Type,
                    Brand = product.Brand,
                    QuantityInStock = product.QuantityInStock,
                };
            }
            return null;

        }
    }
}
