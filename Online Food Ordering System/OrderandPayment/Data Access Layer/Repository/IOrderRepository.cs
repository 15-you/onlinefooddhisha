using Online_Food_Ordering_System.OrderandPayment.Business_Layer.DTO.OrderandPayment.Business_Layer.DTO;
using Online_Food_Ordering_System.OrderandPayment.Data_Access_Layer.Models;

namespace Online_Food_Ordering_System.OrderandPayment.Data_Access_Layer.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
        OrderDto GetUser(OrderDto order);
    }
}