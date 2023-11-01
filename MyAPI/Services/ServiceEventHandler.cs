
using MyAPI.Services.Service1Folder;
using System.Diagnostics;
using System.Timers;
using MyAPI.Data;
using MyAPI.Models;
using Microsoft.EntityFrameworkCore;
using MyAPI.Services.Service2Folder;
using MyAPI.Services.Service3Folder;
//using MyAPI.Services.CreateServicesFolder;

namespace MyAPI.Services
{
    public class ServiceEventHandler : IServiceEventHandler
    {
        //private Service1 _service1;


        //public EventHandler(Service1 service1)
        //{
        //    //_service1 = service1;
        //    service1.NoticeFromService += ServiceMsg;
        //}

        //private Stopwatch sw = new Stopwatch();
        //private static System.Timers.Timer timer;
        //private bool isFirstTime = true;
        private static Dictionary<int, string> StatusStatistic = new Dictionary<int, string>();
        private IRepository repository;

        //private Service service1_db_ekz, service2_db_ekz, service3_db_ekz; // БЫЛО
        private static Service service1_db_ekz, service2_db_ekz, service3_db_ekz;
        //private ServiceVariables s1, s2, s3;
        //private ServiceVariables s; 
        private static bool servicesIsCreated = false;
        private static Service1 service1;
        private static Service2 service2;
        private static Service3 service3;

        private int structureEkzCount = 0;
        private static int count = 0;

        //private ICreateServices _createServices;
        //private Service1 _service1;

        // Эта структура нужна для временного хранения данных
        //struct ServiceVariables
        //{
        //    public bool isFirstTime = true;
        //    public Stopwatch? sw = new Stopwatch();
        //    public int DownTime = 0;
        //    public int WorkTime = 0;
        //    public int BadWorkTime = 0;
        //    public string? Status;

        //    public ServiceVariables() {
        //        //isFirstTime = true;
        //    }
        //}

        public ServiceEventHandler(IRepository _repository)
        {

            // using (var scope = Services.CreateScope())
            //{
            //    var myScopedService = scope.GetRequiredService<IScopedService>();

            repository = _repository;

            //Console.WriteLine("EventHandler");

            //_createServices = createServices;


            //if (servicesIsCreated == false)
            //{
            //    CreateServices();
            //    // НАДО ЗАПИЛИТЬ ИНТЕРФЕЙС
            //    //Service1 service1 = new Service1();

            //    //var sp = new ServicePapaz();

            //    //sp.NoticeFromService += ServiceHandler;


            //    service1 = new Service1();
            //    service1.NoticeFromService += ServiceHandler;
            //    //service1.NoticeFromService += Service1Handler;

            //    service2 = new Service2();
            //    service2.NoticeFromService += ServiceHandler;
            //    //service2.NoticeFromService += Service2Handler;


            //    service3 = new Service3();
            //    service3.NoticeFromService += ServiceHandler;

            //    //service3 = new Service3();
            //    //service3.NoticeFromService += ServiceHandler;

            //    servicesIsCreated = true;
            //    // Вызываю позже (а не в конструкторе класса Service1), тк метод должен быть вызван после подписки на событие
            //    await service1.Work1();
            //    service2.Work2();
            //    service3.Work3();
            //}

            //else
            //{
            //    service1.Work1();
            //    service2.Work2();
            //    service3.Work3();
            //}
        }


        // Метод обработчик
        private void ServiceHandler(object sender, DescriptionOfEventArgs e)
        {
            if (e.ServiceId == 1)
                AddCounter(ref service1_db_ekz, e);

            else if (e.ServiceId == 2)
                AddCounter(ref service2_db_ekz, e);

            else if (e.ServiceId == 3)
                AddCounter(ref service3_db_ekz, e);
        }

        //private void Service1Handler(object sender, DescriptionOfEventArgs e)
        //{
        //        AddCounter(ref service1_db_ekz, e);
        //}

        //private void Service2Handler(object sender, DescriptionOfEventArgs e)
        //{
        //    AddCounter(ref service2_db_ekz, e);
        //}

        //private void AddCounter(ref ServiceVariables s, Service service, DescriptionOfEventArgs e)
        private void AddCounter(ref Service service_db, DescriptionOfEventArgs e)
        {

            count++;

            // Если запускаем метод для этого экземпляра в первый раз
            if (service_db.isFirstTime)
            {

                //service_db.Timer = new Stopwatch();
                service_db.Timer.Start();
                service_db.isFirstTime = false;
            }
            service_db.Status = e.Message;
            //Console.WriteLine(e.Message);
            if (e.Message == "Не работает")
            {
                service_db.DownTime += service_db.Timer.Elapsed.Seconds;
                //s.DownTime += s.sw.
                //s.Status = e.Message;
                //sw.Restart();

                //service_db.Timer.Reset();
                service_db.Timer.Restart();
                //Change();
            }
            else if (e.Message == "Работает")
            {
                service_db.WorkTime += service_db.Timer.Elapsed.Seconds;
                //service_db.Timer.Reset();
                service_db.Timer.Restart();
            }

            else if (e.Message == "Нестабильно работает")
            {
                service_db.BadWorkTime += service_db.Timer.Elapsed.Seconds;
                //service_db.Timer.Reset();
                service_db.Timer.Restart();
            }

            if (count % 9 == 0 && count != 0)
            {
                UpdateDB();
            }

            Console.WriteLine("Podpischik");
        }

        //private async Task UpdateDB()
        private void UpdateDB()
        {
            using (var context = new AppDbContext())
            {
                //var user = _userRepository.Get(context, userId);
                //user.IsPremiumUser = true;
                //context.SaveChanges();

                repository.UpdateService(context, service1_db_ekz);
                repository.UpdateService(context, service2_db_ekz);
                repository.UpdateService(context, service3_db_ekz);

                //repository.UpdateService(service2_db_ekz); БЫЛО
                //repository.UpdateService(service3_db_ekz); БЫЛО

                Console.WriteLine("Update");

                //await repository.SaveChangesAsync();
            }


            // БЫЛО
            //repository.UpdateService(service1_db_ekz);
            ////repository.UpdateService(service2_db_ekz); БЫЛО
            ////repository.UpdateService(service3_db_ekz); БЫЛО

            //Console.WriteLine("Update");

            //await repository.SaveChangesAsync();
        }

        //public void CreateServices()
        //public async void CreateServices()
        public async Task<bool> CreateServices()
        {

            Console.WriteLine("CreateServices");

            var _service1_db_ekz = new Service
            {
                Id = 1,
                Name = "Service1",
                Description = "Service1Description",
                WorkTime = 0,
                DownTime = 0,
                BadWorkTime = 0,
                UpdatedAt = DateTime.Now,
                CreatedAt = DateTime.Now,
                Status = "DontWork",
                isFirstTime = true,
                Timer = new Stopwatch()

            };
            service1_db_ekz = _service1_db_ekz;

            // НА ВРЕМЯ

            var _service2_db_ekz = new Service
            {
                Id = 2,
                Name = "Service2",
                Description = "Service2Description",
                WorkTime = 0,
                DownTime = 0,
                BadWorkTime = 0,
                UpdatedAt = DateTime.Now,
                CreatedAt = DateTime.Now,
                Status = "DontWork",
                isFirstTime = true,
                Timer = new Stopwatch()
            };
            service2_db_ekz = _service2_db_ekz;

            var _service3_db_ekz = new Service
            {
                Id = 3,
                Name = "Service3",
                Description = "Service3Description",
                WorkTime = 0,
                DownTime = 0,
                BadWorkTime = 0,
                UpdatedAt = DateTime.Now,
                CreatedAt = DateTime.Now,
                Status = "DontWork",
                isFirstTime = true,
                Timer = new Stopwatch()
            };
            service3_db_ekz = _service3_db_ekz;

            repository.AddService(_service1_db_ekz);
            repository.AddService(_service2_db_ekz);
            repository.AddService(_service3_db_ekz);

            //await repository.SaveChangesAsync();

            //int y = 0;
            //for (int i = 0; i < 1000; i++)
            //    y++;

            if (await repository.SaveChangesAsync())
                return true;

            return false;
        }


        public async void StartServices()
        {
            if (await CreateServices())
                Console.WriteLine("Сервисы созданы успешно");

            service1 = new Service1();
            service1.NoticeFromService += ServiceHandler;

            service2 = new Service2();
            service2.NoticeFromService += ServiceHandler;

            service3 = new Service3();
            service3.NoticeFromService += ServiceHandler;

            // Вызываю позже (а не в конструкторе класса Service1), тк метод должен быть вызван после подписки на событие

            //for(int i = 0; i < 10; i ++)
            //{
            while(true) { 
                await service1.Work1();
                await service2.Work2();
                await service3.Work3();
            }

        }
    }
}

        

        // Этот метод может выполняться для отмены регистрации объекта Fax
        // в качестве получтеля уведомлений о событии NewMail
        //public void Unregister(Service1 mm)
        //{
        //    // Отменить регистрацию на уведомление о событии NewMail объекта
        //    Service1.mm.NewMail -= FaxMsg;
        //}
    

