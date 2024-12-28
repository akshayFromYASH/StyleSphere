using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace StyleSphere.Models{

//  UnitOfWork Class ==> - Responsible for managing transactions.
                    // - Coordinates the operations on multiple repositories.
                    // - Contains methods to commit or rollback transactions.

    public class UnitOfWork : IUnitOfWork
    {
        // declaring readonly AppDbContext property
        private readonly AppDbContext _context;
        private bool _disposed = false;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public DbContext Context => _context;

    // Asynchronous method that calls SaveChangesAsync() method on _context 
    // This method calls the commit changes to the databse
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    // Implements the Dispose method of IDisposable interface
        public void Dispose(){
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    // If true, it disposes of managed resources, in this case, _context.
        protected virtual void Dispose(bool disposing){
            if(!_disposed){
                if(disposing){
                    _context.Dispose();
                }
                _disposed = true;
            }
        }
    }
}