using Online_Food_Ordering_System.OrderandPayment.Data_Access_Layer.Models;

namespace Online_Food_Ordering_System.OrderandPayment.Data_Access_Layer.Repository
{
    public interface IPaymentRepository
    {
        Payment GetPaymentById(int paymentId);
        IEnumerable<Payment> GetPaymentsByOrderId(int orderId);
        void AddPayment(Payment payment);
    }
}
