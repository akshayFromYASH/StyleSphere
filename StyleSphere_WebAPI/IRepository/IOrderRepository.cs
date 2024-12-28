using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;

namespace StyleSphere.Repository{
    // Interface that inherits IRepository Interface with specialized type User
    public interface IOrderRepository: IRepository<Order>{
        public Task<ActionResult<Order>> GetById(int id);
    }
}