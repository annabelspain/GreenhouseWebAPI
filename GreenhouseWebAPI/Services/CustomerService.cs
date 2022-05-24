using GreenhouseWebAPI.Data.Repositories;
using GreenhouseWebAPI.Models;

namespace GreenhouseWebAPI.Services
{
    public class CustomerService : ICrudService<Customer, int>
    {
        private readonly ICrudRepository<Customer, int> _customerRepository;
        public CustomerService(ICrudRepository<Customer, int> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void Add(Customer element)
        {
            _customerRepository.Add(element);
            _customerRepository.Save();
        }
        public void Delete(int id)
        {
            _customerRepository.Delete(id);
            _customerRepository.Save();
        }
        public Customer Get(int id)
        {
            return _customerRepository.Get(id);
        }
        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }
        public void Update(Customer old, Customer newT)
        {
            old.Description = newT.Description;
            old.Status = newT.Status;
            _customerRepository.Update(old);
            _customerRepository.Save();
        }
    }
}
