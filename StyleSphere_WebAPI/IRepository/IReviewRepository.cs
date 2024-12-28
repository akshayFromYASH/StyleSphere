using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;

namespace StyleSphere.Repository{
    // Interface that inherits IRepository Interface with specialized type User
    public interface IReviewandRatingRepository: IRepository<ReviewandRating>{
        public Task<ActionResult<ReviewandRating>> GetById(int id);
    }
}