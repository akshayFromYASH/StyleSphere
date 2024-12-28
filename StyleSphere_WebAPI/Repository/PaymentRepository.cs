using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;
namespace StyleSphere.Repository{
    public class PaymentRepository : Repository<Payment>,IPaymentRepository
    {
        public PaymentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<ActionResult<Payment>> GetById(int id)
        {
            var data = await dbset.FindAsync(id);
            return data;
        }
    }
}