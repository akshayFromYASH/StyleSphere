
using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;
using StyleSphere.Repository;

namespace StyleSphere.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class ReviewandRatingController : ControllerBase{
        // initialize field for IUnitOfWork interface
        private readonly IUnitOfWork _unitOfWork;

        // ==> Cant use IRepository<User> if we have custom methods defined for User model
        // IRepository<ReviewandRating> ReviewandRatingRepository;  

        // We cannot access custom methods without this line 
        private readonly IReviewandRatingRepository reviewandRatingRepository;
        
        // Constructor with injection of interface IUnitOfWork and UserRepository
        public ReviewandRatingController(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
            reviewandRatingRepository = new ReviewandRatingRepository(_unitOfWork);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewandRating>>> Get(){
            return await reviewandRatingRepository.Get();
    
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewandRating>> GetReviewandRatingById(int id){
            return await reviewandRatingRepository.GetById(id);
        
        }

        [HttpPost]
        public async Task<ActionResult<ReviewandRating>> Create(ReviewandRating data){
            return await reviewandRatingRepository.Create(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id){
            return await reviewandRatingRepository.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ReviewandRating data){
            return await reviewandRatingRepository.Update(id,data);
        }

    }
}