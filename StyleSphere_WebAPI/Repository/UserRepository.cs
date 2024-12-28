using System.Formats.Asn1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleSphere.Models;
namespace StyleSphere.Repository{
    public class UserRepository : Repository<User>,IUserRepository
    {
        
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<ActionResult<User>> GetById(int id)
        {
            var data = await dbset.FindAsync(id);
            return data;
        }
    }
}