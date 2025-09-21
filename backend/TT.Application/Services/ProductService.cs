using TT.Application.Commons.Bases;
using TT.Application.Interfaces;
using TT.Domain.Entities;
using TT.Infrastructure.Persistences.Interfaces;

namespace TT.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product, int> _productRepo;

        public ProductService(IGenericRepository<Product, int> productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<BaseResponse<IEnumerable<Product>>> GetAvailableAsync()
        {
            var products = (await _productRepo.GetAllAsync())
                .Where(p => p.State == 1);
            return ResponseFactory.Success(products, "Productos disponibles");
        }
    }
}
