// using Microsoft.AspNetCore.Mvc;
// using StyleSphere.Models;
// namespace StyleSphere.Repository{
//     public class ShippingRepository : Repository<ShippingRepository>,IShippingRepository
//     {
//         public ShippingRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
//         {
//         }

//         public async Task<ActionResult<Shipping_Detail>> GetById(int id)
//         {
//             var data = await dbset.FindAsync(id);
//             return data;
//         }
//     }
// }