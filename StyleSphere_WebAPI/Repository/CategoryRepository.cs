using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;
namespace StyleSphere.Repository{
    public class CategoryRepository : Repository<Category>,ICategoryRepository
    {

        public CategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<ActionResult<Category>> GetById(int id)
        {
            var data = await dbset.FindAsync(id);
            return data;
        }
    }
}