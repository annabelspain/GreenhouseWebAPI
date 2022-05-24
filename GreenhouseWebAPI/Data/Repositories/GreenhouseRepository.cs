using GreenhouseWebAPI.Models;

namespace GreenhouseWebAPI.Data.Repositories
{
    public class GreenhouseRepository : ICrudRepository<GreenhouseItem, int>
    {
        private readonly GreenhouseContext _greenhouseContext;
        public GreenhouseRepository(GreenhouseContext greenhouseContext)
        {
            _greenhouseContext = greenhouseContext ?? throw new
            ArgumentNullException(nameof(greenhouseContext));
        }
        public void Add(GreenhouseItem element)
        {
            _greenhouseContext.GreenhouseItems.Add(element);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _greenhouseContext.GreenhouseItems.Remove(Get(id));
        }
        public bool Exists(int id)
        {
            return _greenhouseContext.GreenhouseItems.Any(u => u.GreenhouseId == id);
        }
        public GreenhouseItem Get(int id)
        {
            return _greenhouseContext.GreenhouseItems.FirstOrDefault(u => u.GreenhouseId == id);
        }
        public IEnumerable<GreenhouseItem> GetAll()
        {
            return _greenhouseContext.GreenhouseItems.ToList();
        }
        public bool Save()
        {
            return _greenhouseContext.SaveChanges() > 0;
        }
        public void Update(GreenhouseItem element)
        {
            _greenhouseContext.Update(element);
        }
    }
}
