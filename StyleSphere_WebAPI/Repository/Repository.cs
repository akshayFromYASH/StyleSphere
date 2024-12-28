using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleSphere.Models;

namespace StyleSphere.Repository{

    // Defines an abstract class that can be used as a base for other repository classes.
    public abstract class Repository<T> : ControllerBase, IRepository<T> where T:class{
        protected readonly DbContext _context;

        // Represents the set of entities of type T.
        protected DbSet<T> dbset;

        // Manages the transaction context.
        private readonly IUnitOfWork _unitOfWork;

        // Constructor ==> Initializes _unitOfWork and dbset using the injected IUnitOfWork instance.
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            dbset = unitOfWork.Context.Set<T>();
        }

        // Post Request
        // ActionResult ==> - Allows an action method to return different types of responses like JSON data, HTML content, etc.
                        // - Helps in setting the appropriate HTTP status code for the response, such as --
                            // OkResult: Returns a 200 OK response.
                            // NotFoundResult: Returns a 404 Not Found response.
                            // BadRequestResult: Returns a 400 Bad Request response.
                            // RedirectResult: Redirects to a different URL.
                            // FileResult: Returns a file to be downloaded.
        public async Task<ActionResult<T>> Create(T entity)   
        {
            dbset.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        // Delete Request
        public async Task<ActionResult> Delete(int id)
        {
            var data = await dbset.FindAsync(id);
            if(data == null){
                return NotFound();
            }
            dbset.Remove(data);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();     // This is typically used to indicate that a request has been successfully processed, but there is no content to return.
        }

        // Get Request
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            var data = await dbset.ToListAsync();
            return Ok(data);
        }

        // Put Request
        public async Task<ActionResult> Update(int id, T entity)
        {
            var existingRecord = await dbset.FindAsync(id);
            if(existingRecord == null){
                return NotFound();
            }

            _unitOfWork.Context.Entry(existingRecord).CurrentValues.SetValues(entity);
            try{
                await _unitOfWork.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException){
                throw;
            }
            return NoContent();
        }
    }
}