using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleSphere.Models;
namespace StyleSphere.Repository{
    public class ShippingRepository : Repository<Shipping_Detail>,IShippingRepository
    {
        public ShippingRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<ActionResult<Shipping_Detail>> GetById(int id)
        {
            var data = await dbset.FindAsync(id);
            return data;
        }

        public async Task<ActionResult<Shipping_Detail>> GetByOrderId(int id)
        {
            var data = await dbset.FirstOrDefaultAsync(x => x.OrderId == id);
            return data;
        }
    }
}