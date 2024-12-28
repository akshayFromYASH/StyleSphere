using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;
namespace StyleSphere.Repository{
    public class CartRepository : Repository<Cart>,ICartRepository
    {

        public CartRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<ActionResult<Cart>> GetById(int id)
        {
            var data = await dbset.FindAsync(id);
            return data;
        }
    }
}