
using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;
using StyleSphere.Repository;

namespace StyleSphere.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase{
        // initialize field for IUnitOfWork interface
        private readonly IUnitOfWork _unitOfWork;

        // ==> Cant use IRepository<User> if we have custom methods defined for User model
        // IRepository<User> userRepository;  

        // We cannot access custom methods in IUserRepository  without this line 
        private readonly IUserRepository userRepository;
        
        // Constructor injection of interface IUnitOfWork and UserRepository
        public UserController(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
            userRepository = new UserRepository(_unitOfWork);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get(){
            return await userRepository.Get();  
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id){
            return await userRepository.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] User user){
            return await userRepository.Create(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id){
            return await userRepository.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, User user){
            return await userRepository.Update(id,user);
        }

    }
}