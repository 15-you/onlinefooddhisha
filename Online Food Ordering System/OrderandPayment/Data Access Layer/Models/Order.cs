using Online_Food_Ordering_System.FoodMicroservice.Data_Access_Layer.Models;
using Online_Food_Ordering_System.UserMicroservice.Data_Access_Layer.Models;
using System.Reflection;

namespace Online_Food_Ordering_System.OrderandPayment.Data_Access_Layer.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public int UserId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsShipped { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Food Food { get; set; }
    }
}
