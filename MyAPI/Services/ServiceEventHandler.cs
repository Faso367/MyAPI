
using MyAPI.Services.Service1Folder;
using System.Diagnostics;
using System.Timers;
using MyAPI.Data;
using MyAPI.Models;
using Microsoft.EntityFrameworkCore;
using MyAPI.Services.Service2Folder;
using MyAPI.Services.Service3Folder;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.VisualBasic;
using System;
//using MyAPI.Services.CreateServicesFolder;

namespace MyAPI.Services
{
    public class ServiceEventHandler : IServiceEventHandler
    {
        private IRepository repository;
        private static Service service1_db_ekz, service2_db_ekz, service3_db_ekz;
        private static Service1 service1;
        private static Service2 service2;
        private static Service3 service3;
        private static Stopwatch Timer = new Stopwatch();
        private static DateTime StartTime;
        private static int count = 0;

        public ServiceEventHandler(IRepository _repository)
        {
            repository = _repository;
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

        private void AddCounter(ref Service service_db, DescriptionOfEventArgs e)
        {

            count++;


            // Если запускаем метод для этого экземпляра в первый раз
            if (service_db.isFirstTime)
            {
                //service_db.Timer.Start();
                StartTime = DateTime.Now;
                service_db.isFirstTime = false;
            }
            // Чтобы отсчёт времени начался с момента получения первого сообщения, а не
            //if (count == 2)
            //    service_db.Timer.Start();
            service_db.Status = e.Message;
            var new_zapis = e.Message + ": " + DateTime.Now.ToString();


            var record = new History(new_zapis);
            service_db.StatusHistory.Add(record);

            var currentTime = DateTime.Now;

            //var a = DateTime.Parse(service_db.StatusHistory.Last().Record).ToString();

            //dynamic max_dateTime = new DateTime(0);

            var max_dateTime = DateTime.MinValue;


            //comparison = (DateComparisonResult)thisDate.CompareTo(thisDateLastYear);

            

            foreach (History spisok in service_db.StatusHistory)
            {
                var loc_record = spisok.Record;

                var record_part = loc_record.Substring(loc_record.Length - 8);

                
                //if(max_dateTime.CompareTo(DateTime.Parse(spisok.Record)) < 0)
                if (DateTime.Parse(record_part) > max_dateTime)
                    max_dateTime = DateTime.Parse(record_part);

                Console.WriteLine(111);
            }
            string max_dateTimeStr = max_dateTime.ToString();

            //Console.WriteLine(max_dateTime.ToString());

            //var a = service_db.StatusHistory.Last().Record; // НЕ ВСЕГДА НАДО БРАТЬ ПОСЛЕДНИЙ ЭЛЕМЕНТ, надо брать от максимального времени

            var lastTime = DateTime.Parse(max_dateTimeStr.Substring(max_dateTimeStr.Length - 8));

            //Console.WriteLine(lastTime.ToString());

            //DateTime.Parse(lastTime);

            //service_db.StatusHistory.Add(zapis);

            //var statusRecord = new History(zapis);

            //History pl3 = new History {Record = zapis };

            //service_db.StatusRecords.Add(new History { Record = zapis });

            //Console.WriteLine(e.Message);
            if (e.Message == "Не работает")
            {
                service_db.DownTime += Convert.ToInt32(currentTime.Subtract(lastTime).TotalSeconds);

                
                //service_db.DownTime += service_db.Timer.Elapsed.Seconds;

                //if (count != 1)
                //    service_db.Timer.Restart();
            }
            else if (e.Message == "Работает")
            {
                service_db.WorkTime += Convert.ToInt32(currentTime.Subtract(lastTime).TotalSeconds);
                
                //service_db.WorkTime += service_db.Timer.Elapsed.Seconds;
                //if (count != 1)
                //  service_db.Timer.Restart();
            }

            else if (e.Message == "Нестабильно работает")
            {
                service_db.BadWorkTime += Convert.ToInt32(currentTime.Subtract(lastTime).TotalSeconds);

                //service_db.BadWorkTime += service_db.Timer.Elapsed.Seconds;
                //if (count != 1)
                //service_db.Timer.Restart();
            }
            
            if (count == 2)
                service_db.WorkTime += Convert.ToInt32(currentTime.Subtract(StartTime).TotalSeconds);

            Console.WriteLine("777");
            //service_db.WorkTime += service_db.Timer.Elapsed.Seconds;

            if (count % 9 == 0 && count != 0)
            {
                UpdateDB();
                //if (await UpdateDB())
                //    Console.WriteLine("База данных успешно обновлена");
                //else Console.WriteLine("При обновлении базы данных произошла ошибка");
            }
        }

        //private async Task<bool> UpdateDB()
        private void UpdateDB()
        {

            repository.UpdateService(service1_db_ekz);
            repository.UpdateService(service2_db_ekz);
            repository.UpdateService(service3_db_ekz);
            // БЫЛО
            //using (var context = new AppDbContext())
            //{

            //    repository.UpdateService(context, service1_db_ekz);
            //    repository.UpdateService(context, service2_db_ekz);
            //    repository.UpdateService(context, service3_db_ekz);

            //    context.SaveChanges();
            //}
            //SaveChanges();
            //if (await repository.SaveChangesAsync())

            //await repository.SaveChangesAsync();
            //if (await repository.SaveChangesAsync())
            //    return true;

            //return false;
        }

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
                //UpdatedAt = DateTimeOffset.Now,
                //CreatedAt = DateTimeOffset.Now,
                Status = "DontWork",
                isFirstTime = true,
                //Timer = new Stopwatch(),
                StatusHistory = new List<History>()
                //StatusHistory = ""

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
                //Timer = new Stopwatch(),
                //StatusHistory = new List<string>()
                //StatusHistory = ""
                StatusHistory = new List<History>()
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
                //Timer = new Stopwatch(),
                //StatusHistory = new List<string>()
                //StatusHistory = ""
                StatusHistory = new List<History>()
            };
            service3_db_ekz = _service3_db_ekz;

            //using (var context = new AppDbContext())
            //{
                repository.AddService(_service1_db_ekz);
                repository.AddService(_service2_db_ekz);
                repository.AddService(_service3_db_ekz);

            //repository.SaveCh
              //  context.SaveChanges();
            //}

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
            while(true) { 
                await service1.Work1();
                await service2.Work2();
                await service3.Work3();
            }

        }
    }
}

