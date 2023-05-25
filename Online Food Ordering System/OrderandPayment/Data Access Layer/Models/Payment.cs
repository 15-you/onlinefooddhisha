namespace Online_Food_Ordering_System.OrderandPayment.Data_Access_Layer.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        // Navigation properties for relationships
        public Order Order { get; set; }
    }
}
