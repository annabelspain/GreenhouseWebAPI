using GreenhouseWebAPI.Models;

namespace GreenhouseWebAPI.Data.Repositories
{
    public class CustomerRepository : ICrudRepository<Customer, int>
    {
        private readonly GreenhouseContext _greenhouseContext;
        public CustomerRepository(GreenhouseContext customerContext)
        {
            _greenhouseContext = customerContext ?? throw new
            ArgumentNullException(nameof(customerContext));
        }
        public void Add(Customer element)
        {
            _greenhouseContext.Customers.Add(element);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _greenhouseContext.Customers.Remove(Get(id));
        }
        public bool Exists(int id)
        {
            return _greenhouseContext.Customers.Any(u => u.CustomerId == id);
        }
        public Customer Get(int id)
        {
            return _greenhouseContext.Customers.FirstOrDefault(u => u.CustomerId == id);
        }
        public IEnumerable<Customer> GetAll()
        {
            return _greenhouseContext.Customers.ToList();
        }

        /*
        public IEnumerable<string> GetJoinedData()
        {
            List<Customer> customers = _customerContext.Customers.ToList();
            List<GreenhouseItem> greenhouseItems = _customerContext.Greenhouse.ToList();

            var result = from customer in customers
                         join greenhouseItem in greenhouseItems
                         on customer.Order equals customers.Order
                         select $"{customer.CustomerId} {greenhouseItem.Order}";
            return result;

        }
        */

        public bool Save()
        {
            return _greenhouseContext.SaveChanges() > 0;
        }
        public void Update(Customer element)
        {
            _greenhouseContext.Update(element);
        }
    }
}
