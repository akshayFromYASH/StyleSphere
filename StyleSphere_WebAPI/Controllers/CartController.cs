
using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;
using StyleSphere.Repository;

namespace StyleSphere.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase{
        // initialize field for IUnitOfWork interface
        private readonly IUnitOfWork _unitOfWork;

        // ==> Cant use IRepository<User> if we have custom methods defined for User model
        // IRepository<Cart> CartRepository;  

        // We cannot access custom methods without this line 
        private readonly ICartRepository cartRepository;
        
        // Constructor with injection of interface IUnitOfWork and UserRepository
        public CartController(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
            cartRepository = new CartRepository(_unitOfWork);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> Get(){
            return await cartRepository.Get();
    
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCartById(int id){
            return await cartRepository.GetById(id);
        
        }

        [HttpPost]
        public async Task<ActionResult<Cart>> Create(Cart data){
            return await cartRepository.Create(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id){
            return await cartRepository.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Cart data){
            return await cartRepository.Update(id,data);
        }

    }
}