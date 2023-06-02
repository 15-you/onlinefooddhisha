using Online_Food_Ordering_System.OrderandPayment.Business_Layer.DTO.OrderandPayment.Business_Layer.DTO;

namespace Online_Food_Ordering_System.OrderandPayment.Business_Layer.Service
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetAllOrders();
        OrderDto GetOrderById(int id);
        void PlaceOrder(OrderDto orderDto);
        void UpdateOrder(OrderDto orderDto);
        void DeleteOrder(int id);
        OrderDto GetUser(OrderDto orderDto);
    }
}
