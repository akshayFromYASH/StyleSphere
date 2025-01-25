using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;

namespace StyleSphere.Repository{
    // Interface that inherits IRepository Interface with specialized type User
    public interface IProductRepository: IRepository<Product>{
        public Task<ActionResult<Product>> GetById(int id);

        public Task<ActionResult<List<Product>>> GetProductsByUserId(int userid);
    }
}