using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;
namespace StyleSphere.Repository{
    public class OrderRepository : Repository<Order>,IOrderRepository
    {

        public OrderRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<ActionResult<Order>> GetById(int id)
        {
            var data = await dbset.FindAsync(id);
            return data;
        }
        
    }
}