using GreenhouseWebAPI.Models;

namespace GreenhouseWebAPI.Data.Repositories
{
    public class OrderRepository : ICrudRepository<OrderItem, int>
    {
        private readonly GreenhouseContext _greenhouseContext;
        public OrderRepository(GreenhouseContext greenhouseContext)
        {
            _greenhouseContext = greenhouseContext ?? throw new
            ArgumentNullException(nameof(greenhouseContext));
        }
        public void Add(OrderItem element)
        {
            _greenhouseContext.OrderItems.Add(element);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _greenhouseContext.OrderItems.Remove(Get(id));
        }
        public bool Exists(int id)
        {
            return _greenhouseContext.OrderItems.Any(u => u.OrderId == id);
        }
        public OrderItem Get(int id)
        {
            return _greenhouseContext.OrderItems.FirstOrDefault(u => u.OrderId == id);
        }
        public IEnumerable<OrderItem> GetAll()
        {
            return _greenhouseContext.OrderItems.ToList();
        }
        public bool Save()
        {
            return _greenhouseContext.SaveChanges() > 0;
        }
        public void Update(OrderItem element)
        {
            _greenhouseContext.Update(element);
        }
    }
}

