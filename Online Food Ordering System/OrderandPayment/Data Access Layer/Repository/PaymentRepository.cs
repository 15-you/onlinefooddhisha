using Microsoft.EntityFrameworkCore;
using Online_Food_Ordering_System.OrderandPayment.Data_Access_Layer.Models;
using Online_Food_Ordering_System.UserMicroservice.Business_Layer.DTO;

namespace Online_Food_Ordering_System.OrderandPayment.Data_Access_Layer.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _appDbContext;

        public PaymentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Payment GetPaymentById(int paymentId)
        {
            return _appDbContext.Payments.FirstOrDefault(p => p.PaymentId == paymentId);
        }

        public IEnumerable<Payment> GetPaymentsByOrderId(int orderId)
        {
            return _appDbContext.Payments.Where(p => p.OrderId == orderId).ToList();
        }

        public void AddPayment(Payment payment)
        {
            _appDbContext.Payments.Add(payment);
            _appDbContext.SaveChanges();
        }
    }
}
