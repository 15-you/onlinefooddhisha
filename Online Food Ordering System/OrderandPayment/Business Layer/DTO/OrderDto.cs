using Online_Food_Ordering_System.FoodMicroservice.Business_Layer.DTO;

namespace Online_Food_Ordering_System.OrderandPayment.Business_Layer.DTO
{
    namespace OrderandPayment.Business_Layer.DTO
    {
        public class OrderDto
        {
            public int Id { get; set; }
            public int FoodId { get; set; }
            public int UserId { get; set; }
            public string CustomerName { get; set; }
            public string CustomerEmail { get; set; }
            public string ShippingAddress { get; set; }
            public DateTime OrderDate { get; set; }
            public bool IsShipped { get; set; }
          
        }
    }

}
