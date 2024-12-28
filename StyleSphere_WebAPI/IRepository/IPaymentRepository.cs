using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;

namespace StyleSphere.Repository{
    // Interface that inherits IRepository Interface with specialized type User
    public interface IPaymentRepository: IRepository<Payment>{
        public Task<ActionResult<Payment>> GetById(int id);
    }
}