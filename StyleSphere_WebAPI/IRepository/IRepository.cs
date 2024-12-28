using Microsoft.AspNetCore.Mvc;

namespace StyleSphere.Repository{

    // IRepository<T> ==> - This is generic interface ==> 
                // Generic allows you to create classes & interfaces & methods with palceholder for datatype 
                // This enables you to create reusable code that can work with any data type while providing type safety.
    public interface IRepository<T> where T:class{
        public Task<ActionResult<IEnumerable<T>>> Get();
        public Task<ActionResult<T>> Create(T entity);
        public Task<ActionResult> Update(int id, T entity);
        public Task<ActionResult> Delete(int id);
    }
}