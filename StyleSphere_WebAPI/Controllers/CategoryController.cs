
using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;
using StyleSphere.Repository;

namespace StyleSphere.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase{
        // initialize field for IUnitOfWork interface
        private readonly IUnitOfWork _unitOfWork;

        // ==> Cant use IRepository<User> if we have custom methods defined for User model
        // IRepository<Category> categoryRepository;  

        // We cannot access custom methods without this line 
        private readonly ICategoryRepository categoryRepository;
        
        // Constructor with injection of interface IUnitOfWork and UserRepository
        public CategoryController(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
            categoryRepository = new CategoryRepository(_unitOfWork);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get(){
            return await categoryRepository.Get();
    
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id){
            return await categoryRepository.GetById(id);
        
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Create(Category data){
            return await categoryRepository.Create(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id){
            return await categoryRepository.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Category data){
            return await categoryRepository.Update(id,data);
        }

    }
}