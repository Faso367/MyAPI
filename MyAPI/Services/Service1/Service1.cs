using MyAPI.Controllers.Main;
using MyAPI.Data;
using MyAPI.Services;

namespace MyAPI.Services.Service1
{
    //public class Service1 : IService1, IServiceEvent
    public class Service1 : IService1
    {
        private IRepository _repo;

        public Service1(IRepository repo)
        {
            _repo = repo; // Получаем экземпляр интерфейса для доступа ко всем методам его методам
        }

        public string Work1()
        {
            //_repo.

            int x = 0;
            for (int i = 1000000; i < 0; i++)
                x++;


            Random rnd = new Random();
            int value = rnd.Next(0, 10);



            return "Сервис 1 отработал";
        }
    }
}
