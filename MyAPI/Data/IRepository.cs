using MyAPI.Models;

namespace MyAPI.Data
{
    public interface IRepository
    {
        public void AddService(Service service);
        public Service GetService(int id);
        public List<Service> GetAllServices();
        public void UpdateService(Service service);
        public Task<bool> SaveChangesAsync();

    }
}
