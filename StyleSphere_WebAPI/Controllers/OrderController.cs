
using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;
using StyleSphere.Repository;

namespace StyleSphere.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase{
        // initialize field for IUnitOfWork interface
        private readonly IUnitOfWork _unitOfWork;

        // ==> Cant use IRepository<User> if we have custom methods defined for User model
        // IRepository<Order> orderRepository;  

        // We cannot access custom methods without this line 
        private readonly IOrderRepository orderRepository;
        
        // Constructor with injection of interface IUnitOfWork and UserRepository
        public OrderController(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
            orderRepository = new OrderRepository(_unitOfWork);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get(){
            return await orderRepository.Get();
    
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id){
            return await orderRepository.GetById(id);
        
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Create(Order data){
            return await orderRepository.Create(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id){
            return await orderRepository.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Order data){
            return await orderRepository.Update(id,data);
        }

    }
}