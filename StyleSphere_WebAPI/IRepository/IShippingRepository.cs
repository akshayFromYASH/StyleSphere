using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;

namespace StyleSphere.Repository{
    // Interface that inherits IRepository Interface with specialized type User
    public interface IShippingRepository: IRepository<Shipping_Detail>{
        public Task<ActionResult<Shipping_Detail>> GetById(int id);
        public Task<ActionResult<Shipping_Detail>> GetByOrderId(int id);
    }

}