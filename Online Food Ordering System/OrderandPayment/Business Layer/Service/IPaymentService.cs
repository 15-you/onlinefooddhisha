using Online_Food_Ordering_System.OrderandPayment.Business_Layer.DTO;

namespace Online_Food_Ordering_System.OrderandPayment.Business_Layer.Service
{
    public interface IPaymentService
    {
        PaymentDto GetPaymentById(int paymentId);
        IEnumerable<PaymentDto> GetPaymentsByOrderId(int orderId);
        void AddPayment(PaymentDto paymentDto);
    }
}
