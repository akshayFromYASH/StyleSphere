using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;
namespace StyleSphere.Repository{
    public class ReviewandRatingRepository : Repository<ReviewandRating>,IReviewandRatingRepository
    {
        public ReviewandRatingRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<ActionResult<ReviewandRating>> GetById(int id)
        {
            var data = await dbset.FindAsync(id);
            return data;
        }
    }
}