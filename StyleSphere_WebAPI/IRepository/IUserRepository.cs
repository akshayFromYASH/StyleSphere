using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;

namespace StyleSphere.Repository{
    // Interface that inherits IRepository Interface with specialized type User
    public interface IUserRepository: IRepository<User>{
        public Task<ActionResult<User>> GetById(int id);
    }
}