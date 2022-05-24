using GreenhouseWebAPI.Data.Repositories;
using GreenhouseWebAPI.Models;

namespace GreenhouseWebAPI.Services
{
    public class OrderService : ICrudService<OrderItem, int>
    {
        private readonly ICrudRepository<OrderItem, int> _orderRepository;
        public OrderService(ICrudRepository<OrderItem, int> orderRepository)
        {
            _orderRepository = orderRepository; 
        }
        public void Add(OrderItem element)
        {
            _orderRepository.Add(element);
            _orderRepository.Save();
        }
        public void Delete(int id)
        {
            _orderRepository.Delete(id);
            _orderRepository.Save();
        }
        public OrderItem Get(int id)
        {
            return _orderRepository.Get(id);
        }
        public IEnumerable<OrderItem> GetAll()
        {
            return _orderRepository.GetAll();
        }
        public void Update(OrderItem old, OrderItem newT)
        {
            old.Description = newT.Description;
            old.Status = newT.Status;
            _orderRepository.Update(old);
            _orderRepository.Save();
        }
    }
}

