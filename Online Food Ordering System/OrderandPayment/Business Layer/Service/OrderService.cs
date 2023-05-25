using Online_Food_Ordering_System.OrderandPayment.Data_Access_Layer.Models;
using Online_Food_Ordering_System.OrderandPayment.Data_Access_Layer.Repository;
using Online_Food_Ordering_System.OrderandPayment.Business_Layer.DTO.OrderandPayment.Business_Layer.DTO;
using Online_Food_Ordering_System.OrderandPayment.Business_Layer.Service;

namespace Online_Food_Ordering_System.OrderMicroservice.Business_Layer.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<OrderDto> GetAllOrders()
        {
            var orders = _orderRepository.GetAllOrders();
            var orderDtos = new List<OrderDto>();

            foreach (var order in orders)
            {
                var orderDto = new OrderDto
                {
                    Id = order.Id,
                    FoodId = order.FoodId,
                    UserId = order.UserId,
                    CustomerName = order.CustomerName,
                    CustomerEmail = order.CustomerEmail,
                    ShippingAddress = order.ShippingAddress,
                    OrderDate = order.OrderDate,
                    IsShipped = order.IsShipped
                };

                orderDtos.Add(orderDto);
            }

            return orderDtos;
        }

        public OrderDto GetOrderById(int id)
        {
            var order = _orderRepository.GetOrderById(id);

            if (order == null)
            {
                // Handle not found case or throw an exception
                return null;
            }

            var orderDto = new OrderDto
            {
                Id = order.Id,
                FoodId = order.FoodId,
                UserId = order.UserId,
                CustomerName = order.CustomerName,
                CustomerEmail = order.CustomerEmail,
                ShippingAddress = order.ShippingAddress,
                OrderDate = order.OrderDate,
                IsShipped = order.IsShipped
            };

            return orderDto;
        }

        public void PlaceOrder(OrderDto orderDto)
        {
            var order = new Order
            {
                Id = orderDto.Id,
                FoodId = orderDto.FoodId,
                UserId = orderDto.UserId,
                CustomerName = orderDto.CustomerName,
                CustomerEmail = orderDto.CustomerEmail,
                ShippingAddress = orderDto.ShippingAddress,
                OrderDate = orderDto.OrderDate,
                IsShipped = orderDto.IsShipped
            };

            _orderRepository.AddOrder(order);
        }

        public void UpdateOrder(OrderDto orderDto)
        {
            var order = new Order
            {
                Id = orderDto.Id,
                FoodId = orderDto.FoodId,
                UserId = orderDto.UserId,
                CustomerName = orderDto.CustomerName,
                CustomerEmail = orderDto.CustomerEmail,
                ShippingAddress = orderDto.ShippingAddress,
                OrderDate = orderDto.OrderDate,
                IsShipped = orderDto.IsShipped
            };

            _orderRepository.UpdateOrder(order);
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.DeleteOrder(id);
        }
    }
}
