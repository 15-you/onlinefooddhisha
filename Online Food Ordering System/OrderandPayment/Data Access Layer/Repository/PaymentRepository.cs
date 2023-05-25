using Microsoft.EntityFrameworkCore;
using Online_Food_Ordering_System.OrderandPayment.Data_Access_Layer.Models;
using Online_Food_Ordering_System.UserMicroservice.Business_Layer.DTO;

namespace Online_Food_Ordering_System.OrderandPayment.Data_Access_Layer.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _dbContext;

        public PaymentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Payment GetPaymentById(int paymentId)
        {
            return _dbContext.Payments.FirstOrDefault(p => p.PaymentId == paymentId);
        }

        public IEnumerable<Payment> GetPaymentsByOrderId(int orderId)
        {
            return _dbContext.Payments.Where(p => p.OrderId == orderId).ToList();
        }

        public void AddPayment(Payment payment)
        {
            _dbContext.Payments.Add(payment);
            _dbContext.SaveChanges();
        }


    }
}
