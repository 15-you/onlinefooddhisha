using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Food_Ordering_System.OrderandPayment.Business_Layer.DTO;
using Online_Food_Ordering_System.OrderandPayment.Business_Layer.Service;
using System.Linq.Expressions;

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

        [HttpGet("{paymentid}")]
        public IActionResult GetPaymentById(int paymentid)
        {
            try
            {
                var payment = _paymentService.GetPaymentById(paymentid);

                if (payment == null)
                {
                    return NotFound();
                }

                return Ok(payment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("orders/{orderId}")]
        public ActionResult<IEnumerable<PaymentDto>> GetPaymentsByorderId(int orderId)
        {
            try
            {
                var payments = _paymentService.GetPaymentsByOrderId(orderId);
                return Ok(payments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddPayment(PaymentDto paymentDto)
        {
            try
            {
                _paymentService.AddPayment(paymentDto);
                return Ok();

            }
            catch (DbUpdateException ex)
            {
               
                // Return the error message
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}