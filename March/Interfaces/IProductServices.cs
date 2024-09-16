using March.Dtos;

namespace March.Interfaces
{
    public interface IProductServices
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductsAsync(int id);
    }
}
