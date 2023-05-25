using Online_Food_Ordering_System.OrderandPayment.Business_Layer.DTO;
using Online_Food_Ordering_System.OrderandPayment.Data_Access_Layer.Models;
using Online_Food_Ordering_System.OrderandPayment.Data_Access_Layer.Repository;

namespace Online_Food_Ordering_System.OrderandPayment.Business_Layer.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public PaymentDto GetPaymentById(int paymentId)
        {
            var payment = _paymentRepository.GetPaymentById(paymentId);
            if (payment == null)
            {
                // Handle not found scenario
                return null;
            }

            return MapToDto(payment);
        }

        public IEnumerable<PaymentDto> GetPaymentsByOrderId(int orderId)
        {
            var payments = _paymentRepository.GetPaymentsByOrderId(orderId);
            return payments.Select(MapToDto);
        }

        public void AddPayment(PaymentDto paymentDto)
        {
            var payment = MapToModel(paymentDto);

            _paymentRepository.AddPayment(payment);

        }

        private PaymentDto MapToDto(Payment payment)
        {
            return new PaymentDto
            {
                Id = payment.PaymentId,
                Amount = payment.Amount,
                OrderId = payment.OrderId,
                PaymentDate = payment.PaymentDate
            };
        }

        private Payment MapToModel(PaymentDto paymentDto)
        {
            return new Payment
            {
                PaymentId = paymentDto.Id,
                Amount = paymentDto.Amount,
                OrderId = paymentDto.OrderId,
                PaymentDate = paymentDto.PaymentDate
            };
        }
    }
}
