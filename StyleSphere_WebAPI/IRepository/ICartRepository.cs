using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;

namespace StyleSphere.Repository{
    // Interface that inherits IRepository Interface with specialized type User
    public interface ICartRepository: IRepository<Cart>{
        public Task<ActionResult<Cart>> GetById(int id);
    }
}