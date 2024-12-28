using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;
namespace StyleSphere.Repository{
    public class ProductRepository : Repository<Product>,IProductRepository
    {

        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<ActionResult<Product>> GetById(int id)
        {
            var data = await dbset.FindAsync(id);
            return data;
        }
    }
}