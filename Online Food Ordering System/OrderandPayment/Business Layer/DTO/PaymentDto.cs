namespace Online_Food_Ordering_System.OrderandPayment.Business_Layer.DTO
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }

}
