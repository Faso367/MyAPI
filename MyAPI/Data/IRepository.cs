using MyAPI.Models;

namespace MyAPI.Data
{
    public interface IRepository
    {
        public void AddService(Service service);

        public void AddService(AppDbContext context, Service service);

        //public Service GetService(int id); - БЫЛО
        public Service GetService(AppDbContext context, int id);
        //public List<Service> GetAllServices();

        public List<Service> GetAllServices(AppDbContext context);

        public List<Service> GetAllServices();

        //public List<Service> GetServicesInfo(AppDbContext context);

        public List<PartOfService> GetServicesInfo(AppDbContext context);

        //public void UpdateService(Service service); - БЫЛО
        public void UpdateService(AppDbContext context, Service service);
        public void UpdateService(Service service);
        public Task<bool> SaveChangesAsync();

    }
}
