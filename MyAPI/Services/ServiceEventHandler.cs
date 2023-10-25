﻿
using MyAPI.Services.Service1Folder;
using System.Diagnostics;
using System.Timers;
using MyAPI.Data;
using MyAPI.Models;
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
        private Service service1_db_ekz, service2_db_ekz, service3_db_ekz;
        //private ServiceVariables s1, s2, s3;
        //private ServiceVariables s; 
        private bool servicesIsCreated = false, structureEkz1IsCreated = false, structureEkz2IsCreated = false, structureEkz3IsCreated = false;
        private int structureEkzCount = 0;
        

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


            if (servicesIsCreated == false)
            {
                CreateServices();
                // НАДО ЗАПИЛИТЬ ИНТЕРФЕЙС
                Service1 service1 = new Service1();
                service1.NoticeFromService += ServiceHandler;
                
                var timer = new System.Timers.Timer();
                //timer.Interval = 60000; // Срабатывает раз в минуту
                timer.Interval = 20000;
                // Обновляем значения таймеров и статус в БД
                timer.Elapsed += UpdateDB;
                timer.AutoReset = true;

                // Start the timer
                timer.Enabled = true;
                servicesIsCreated = true;
                service1.Work1();
            }
        }


        // Метод обработчик
        private void ServiceHandler(object sender, DescriptionOfEventArgs e)
        {
            //ServiceVariables s = null;

            bool Check()
            {
                return true;
            }

            //if (structureEkzCount < 4)
            //{
            //    //var s = new ServiceVariables();
                
            //    structureEkzCount++;
            //}


            if (e.ServiceId == 1)
            {

                //if (service1_db_ekz.Id != 0) // Если 
                    //service1_db_ekz = new Service();

                AddCounter(ref service1_db_ekz, e);
                //structureEkz1IsCreated = true;
            }
            else if (e.ServiceId == 2)
            {
                //Service service2_db_ekz = new Service();
                AddCounter(ref service2_db_ekz, e);
                //structureEkz1IsCreated = true;
            }
            else if (e.ServiceId == 3)
            {
                //Service service3_db_ekz = new Service();
                AddCounter(ref service3_db_ekz, e);
                //structureEkz1IsCreated = true;
            }


        }


        //private void AddCounter(ref ServiceVariables s, Service service, DescriptionOfEventArgs e)
        private void AddCounter(ref Service service_db, DescriptionOfEventArgs e)
        {
            // Если запускаем метод для этого экземпляра в первый раз
            if (service_db.isFirstTime)
            {
                service_db.isFirstTime = false;
                service_db.Timer.Start();
            }
            service_db.Status = e.Message;
            //Console.WriteLine(e.Message);
            if (e.Message == "Не работает")
            {
                service_db.DownTime += service_db.Timer.Elapsed.Seconds;
                //s.DownTime += s.sw.
                //s.Status = e.Message;
                //sw.Restart();
                service_db.Timer.Reset();
                //Change();
            }
            else if (e.Message == "Работает")
            {
                service_db.WorkTime += service_db.Timer.Elapsed.Seconds;
                service_db.Timer.Reset();
            }

            else if (e.Message == "Нестабильно работает")
            {
                service_db.BadWorkTime += service_db.Timer.Elapsed.Seconds;
                service_db.Timer.Reset();
            }

            //service_db.Status = s.Status;
            //service_db.DownTime = s.DownTime;
            //service_db.WorkTime = s.WorkTime;
            //service_db.BadWorkTime = s.BadWorkTime;

            //Change(ref service1_db_ekz, s);
            //Change(ref service2_db_ekz, s);
            //Change(ref service3_db_ekz, s);

            Console.WriteLine("Podpischik");
        }


        //private void Change(Service service_db, ServiceVariables s)
        //private void Change(ref Service service_db, ServiceVariables s)
        //{
        //    service_db.Status = s.Status;
        //    service_db.DownTime = s.DownTime;
        //    service_db.WorkTime = s.WorkTime;
        //    service_db.BadWorkTime = s.BadWorkTime;
        //}

        private async void UpdateDB(object source, System.Timers.ElapsedEventArgs e)
        {
            //Func<Service, ServiceVariables, bool> {

            //}
            
            //Change(service1_db_ekz, s1);
            //Change(service2_db_ekz, s2);
            //Change(service3_db_ekz, s3);

            //Change(ref service1_db_ekz, s1);
            //Change(ref service2_db_ekz, s2);
            //Change(ref service3_db_ekz, s3);

            repository.UpdateService(service1_db_ekz);
            //repository.UpdateService(service2_db_ekz); БЫЛО
            //repository.UpdateService(service3_db_ekz); БЫЛО

            Console.WriteLine("Update");

            await repository.SaveChangesAsync();
            //service1_db_ekz.Status = s1.Status;
            //service1_db_ekz.DownTime = s1.DownTime;
            //service1_db_ekz.WorkTime = s1.WorkTime;
            //service1_db_ekz.BadWorkTime = s1.BadWorkTime;

            //service2_db_ekz.Status = s2.Status;
            //service2_db_ekz.DownTime = s2.DownTime;
            //service2_db_ekz.WorkTime = s2.WorkTime;
            //service2_db_ekz.BadWorkTime = s2.BadWorkTime;

            //service3_db_ekz.Status = s3.Status;
            //service3_db_ekz.DownTime = s3.DownTime;
            //service3_db_ekz.WorkTime = s3.WorkTime;
            //service3_db_ekz.BadWorkTime = s3.BadWorkTime;

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
                DownTime= 0,
                BadWorkTime= 0,
                UpdatedAt = DateTime.Now,
                CreatedAt = DateTime.Now,
                Status = "DontWork"
            };
            service1_db_ekz = _service1_db_ekz;
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
                Status = "DontWork"
            };
            service2_db_ekz = _service1_db_ekz;
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
                Status = "DontWork"
            };
            service3_db_ekz = _service3_db_ekz;

            repository.AddService(_service1_db_ekz);
            repository.AddService(_service2_db_ekz);
            repository.AddService(_service3_db_ekz);

            await repository.SaveChangesAsync();

            int y = 0;
            for (int i = 0; i < 1000; i++)
                y++;

            if (await repository.SaveChangesAsync())
                return true;

            return false;

            //Console.WriteLine("777");
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
    

