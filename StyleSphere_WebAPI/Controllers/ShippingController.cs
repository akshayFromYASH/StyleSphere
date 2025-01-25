
using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;
using StyleSphere.Repository;

namespace StyleSphere.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class ShippingController : ControllerBase{
        // initialize field for IUnitOfWork interface
        private readonly IUnitOfWork _unitOfWork;

        // ==> Cant use IRepository<User> if we have custom methods defined for User model
        // IRepository<Shipping> ShippingRepository;  

        // We cannot access custom methods without this line 
        private readonly IShippingRepository shippingRepository;
        
        // Constructor with injection of interface IUnitOfWork and UserRepository
        public ShippingController(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
            shippingRepository = new ShippingRepository(_unitOfWork);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipping_Detail>>> Get(){
            return await shippingRepository.Get();
    
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shipping_Detail>> GetShippingById(int id){
            return await shippingRepository.GetById(id);
        }

        [HttpGet("byOrderid/{orderid}")]
        public async Task<ActionResult<Shipping_Detail>> GetShippingByOrderId(int orderid){
            return await shippingRepository.GetByOrderId(orderid);
        }
        [HttpPost]
        public async Task<ActionResult<Shipping_Detail>> Create(Shipping_Detail data){
            return await shippingRepository.Create(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id){
            return await shippingRepository.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Shipping_Detail data){
            return await shippingRepository.Update(id,data);
        }

    }
}