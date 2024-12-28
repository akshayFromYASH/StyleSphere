using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;

namespace StyleSphere.Repository{
    // Interface that inherits IRepository Interface with specialized type User
    public interface ICategoryRepository: IRepository<Category>{
        public Task<ActionResult<Category>> GetById(int id);
    }
}