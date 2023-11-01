using MyAPI.Models;

namespace MyAPI.Data
{
    public interface IRepository
    {
        public void AddService(Service service);
        //public Service GetService(int id); - БЫЛО
        public Service GetService(AppDbContext context, int id);
        //public List<Service> GetAllServices();

        public List<Service> GetAllServices(AppDbContext context);

        //public void UpdateService(Service service); - БЫЛО
        public void UpdateService(AppDbContext context, Service service);
        public Task<bool> SaveChangesAsync();

    }
}
