using GreenhouseWebAPI.Data.Repositories;
using GreenhouseWebAPI.Models;

namespace GreenhouseWebAPI.Services
{
    public class GreenhouseService : ICrudService<GreenhouseItem, int>
    {
        private readonly ICrudRepository<GreenhouseItem, int> _greenhouseRepository;
        public GreenhouseService(ICrudRepository<GreenhouseItem, int> greenhouseRepository)
        {
            _greenhouseRepository = greenhouseRepository;
        }
        public void Add(GreenhouseItem element)
        {
            _greenhouseRepository.Add(element);
            _greenhouseRepository.Save();
        }
        public void Delete(int id)
        {
            _greenhouseRepository.Delete(id);
            _greenhouseRepository.Save();
        }
        public GreenhouseItem Get(int id)
        {
            return _greenhouseRepository.Get(id);
        }
        public IEnumerable<GreenhouseItem> GetAll()
        {
            return _greenhouseRepository.GetAll();
        }
        public void Update(GreenhouseItem old, GreenhouseItem newT)
        {
            old.Description = newT.Description;
            old.Status = newT.Status;
            _greenhouseRepository.Update(old);
            _greenhouseRepository.Save();
        }
    }
}
