using Microsoft.AspNetCore.Mvc;
using Online_Food_Ordering_System.OrderandPayment.Business_Layer.DTO;
using Online_Food_Ordering_System.OrderandPayment.Business_Layer.Service;

namespace Online_Food_Ordering_System.OrderandPayment.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("{id}")]
        public IActionResult GetPaymentById(int id)
        {
            var payment = _paymentService.GetPaymentById(id);

            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        [HttpGet("orders/{orderId}")]
        public IActionResult GetPaymentsByOrderId(int orderId)
        {
            var payments = _paymentService.GetPaymentsByOrderId(orderId);
            return Ok(payments);
        }

        [HttpPost]
        public IActionResult AddPayment([FromBody] PaymentDto paymentDto)
        {
            if (paymentDto == null)
            {
                return BadRequest("Invalid payment data");
            }

            _paymentService.AddPayment(paymentDto);

            return CreatedAtAction(nameof(GetPaymentById), new { id = paymentDto.Id }, paymentDto);
        }
    }
}
