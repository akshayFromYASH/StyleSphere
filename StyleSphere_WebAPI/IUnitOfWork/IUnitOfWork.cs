using Microsoft.EntityFrameworkCore;

namespace StyleSphere.Models{
    public interface IUnitOfWork{
        DbContext Context {get;}
        public Task SaveChangesAsync();

    }
}