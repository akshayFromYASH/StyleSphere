
using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;
using StyleSphere.Repository;

namespace StyleSphere.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase{
        // initialize field for IUnitOfWork interface
        private readonly IUnitOfWork _unitOfWork;

        // ==> Cant use IRepository<User> if we have custom methods defined for User model
        // IRepository<Product> productRepository;  

        // We cannot access custom methods without this line 
        private readonly IProductRepository productRepository;
        
        // Constructor with injection of interface IUnitOfWork and UserRepository
        public ProductController(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
            productRepository = new ProductRepository(_unitOfWork);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get(){
            return await productRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id){
            return await productRepository.GetById(id);
        
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product data){
            return await productRepository.Create(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id){
            return await productRepository.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Product data){
            return await productRepository.Update(id,data);
        }

    }
}