namespace MyAPI.Services
{
    public interface IServiceEventHandler
    {
        //public void CreateServices();
        public Task<bool> CreateServices();
        public void StartServices();

    }
}
