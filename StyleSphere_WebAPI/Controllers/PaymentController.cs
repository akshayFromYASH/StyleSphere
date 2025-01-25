
using Microsoft.AspNetCore.Mvc;
using StyleSphere.Models;
using StyleSphere.Repository;

// namespace StyleSphere.Controllers{
//     [ApiController]
//     [Route("[controller]")]
//     public class PaymentController : ControllerBase{
//         // initialize field for IUnitOfWork interface
//         private readonly IUnitOfWork _unitOfWork;

//         // ==> Cant use IRepository<User> if we have custom methods defined for User model
//         // IRepository<Payment> paymentRepository;  

//         // We cannot access custom methods without this line 
//         private readonly IPaymentRepository paymentRepository;
        
//         // Constructor with injection of interface IUnitOfWork and UserRepository
//         public PaymentController(IUnitOfWork unitOfWork){
//             _unitOfWork = unitOfWork;
//             paymentRepository = new PaymentRepository(_unitOfWork);
//         }

//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Payment>>> Get(){
//             return await paymentRepository.Get();
    
//         }

//         [HttpGet("{id}")]
//         public async Task<ActionResult<Payment>> GetPaymentById(int id){
//             return await paymentRepository.GetById(id);
//         }

//         [HttpPost]
//         public async Task<ActionResult<Payment>> Create([FromBody] Payment data){
//             return await paymentRepository.Create(data);
//         }

//         [HttpDelete("{id}")]
//         public async Task<ActionResult> Delete(int id){
//             return await paymentRepository.Delete(id);
//         }

//         [HttpPut("{id}")]
//         public async Task<ActionResult> Update(int id, Payment data){
//             return await paymentRepository.Update(id,data);
//         }

//     }
// }

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPaymentRepository paymentRepository;

    public PaymentController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        paymentRepository = new PaymentRepository(_unitOfWork);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Payment>>> Get()
    {
        return Ok(await paymentRepository.Get());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Payment>> GetPaymentById(int id)
    {
        var payment = await paymentRepository.GetById(id);
        if (payment == null)
        {
            return NotFound();
        }
        return Ok(payment);
    }

    [HttpPost]
    public async Task<ActionResult<Payment>> Create([FromBody] Payment data)
    {
        System.Console.WriteLine("Payment is processing==========");
        if (data == null)
        {
            return BadRequest("Invalid payment data.");
        }

        var createdPayment = await paymentRepository.Create(data);
        return Ok(createdPayment);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await paymentRepository.Delete(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] Payment data)
    {
        if (data == null || id != data.PaymentId)
        {
            return BadRequest("Invalid payment data.");
        }

        await paymentRepository.Update(id, data);
        return NoContent();
    }
}
