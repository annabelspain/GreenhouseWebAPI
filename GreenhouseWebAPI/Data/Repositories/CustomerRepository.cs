using GreenhouseWebAPI.Models;

namespace GreenhouseWebAPI.Data.Repositories
{
    public class CustomerRepository : ICrudRepository<Customer, int>
    {
        private readonly CustomerContext _customerContext;
        public CustomerRepository(CustomerContext customerContext)
        {
            _customerContext = customerContext ?? throw new
            ArgumentNullException(nameof(customerContext));
        }
        public void Add(Customer element)
        {
            _customerContext.Customers.Add(element);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _customerContext.Customers.Remove(Get(id));
        }
        public bool Exists(int id)
        {
            return _customerContext.Customers.Any(u => u.Id == id);
        }
        public Customer Get(int id)
        {
            return _customerContext.Customers.FirstOrDefault(u => u.Id == id);
        }
        public IEnumerable<Customer> GetAll()
        {
            return _customerContext.Customers.ToList();
        }
        public bool Save()
        {
            return _customerContext.SaveChanges() > 0;
        }
        public void Update(Customer element)
        {
            _customerContext.Update(element);
        }
    }
}
