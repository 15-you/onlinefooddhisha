using Microsoft.EntityFrameworkCore;
using Online_Food_Ordering_System.OrderandPayment.Business_Layer.DTO.OrderandPayment.Business_Layer.DTO;
using Online_Food_Ordering_System.OrderandPayment.Data_Access_Layer.Models;
using Online_Food_Ordering_System.UserMicroservice.Business_Layer.DTO;

namespace Online_Food_Ordering_System.OrderandPayment.Data_Access_Layer.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
 
        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _appDbContext.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return _appDbContext.Orders.FirstOrDefault(o => o.Id == id);
        }

        public void AddOrder(Order order)
        {
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _appDbContext.Orders.Update(order);
            _appDbContext.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = _appDbContext.Orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                _appDbContext.Orders.Remove(order);
                _appDbContext.SaveChanges();
            }
        }
        public OrderDto GetUser(OrderDto order)
        {
            Order objorder = _appDbContext.Orders.Where(x => x.UserId == order.UserId
            && x.FoodId == order.FoodId
            && x.CustomerName == order.CustomerName && x.CustomerEmail == order.CustomerEmail).OrderByDescending(y => y.Id).FirstOrDefault();

            OrderDto objOrderDto = new OrderDto();
            objOrderDto.Id = objorder.Id;
            return objOrderDto;
        }
    }
}