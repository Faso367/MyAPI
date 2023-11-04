using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Hosting;
using MyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyAPI.Data
{
    public class Repository : IRepository
    {
        private AppDbContext _ctx;

        // Получаем контекст текущей сессии с БД
        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        // Добавляем запись в БД
        public void AddService(Service service)
        {
            _ctx.Services.Add(service);
        }
        
        // Получаем данные о сервисе по идентификатору
        public Service GetService(int id)
        {
            // Если полученный id совпадает с найденным в БД, то возвращаем (достаем) эту запись
            return _ctx.Services.FirstOrDefault(p => p.Id == id);
        }

        public List<PartOfService> GetServicesInfo()
        {
            //var spisok = service.StatusHistory.A

            List<PartOfService> servicesInfo = _ctx.Services.Select(service => new PartOfService
            {
                Name = service.Name,
                Description = service.Description,
                Status = service.Status,
                //StatusHistory = service.StatusHistory,
                StatusHistory = service.StatusHistory.OrderBy(n => n).ToList(),
                //StatusHistory = from record in service.StatusHistory
                //                select record.ToString().Replace("record: ", ",")
                //                //where record
                //                ,
                WorkTime = service.WorkTime,
                BadWorkTime = service.BadWorkTime,
                DownTime = service.DownTime
            }).AsNoTracking().ToList();

            //servicesInfo.Status 

            //}).ToList();
            return servicesInfo;
        }

        public void UpdateService(Service service)
        {
            service.UpdatedAt = DateTime.Now;
            _ctx.Services.Update(service);
            _ctx.SaveChanges();
            Console.WriteLine("UpdateService2");
        }

        public void UpdateService(AppDbContext context, Service service)
        {
            service.UpdatedAt = DateTime.Now;
            context.Services.Update(service);
            //_ctx.SaveChanges();
            Console.WriteLine("UpdateService");
        }

        // Метод с подтверждением сохранения записи в БД
        public async Task<bool> SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync(); // сохраняем изменения в БД

            if (await _ctx.SaveChangesAsync() > 0)
                return true;

            return false;

        }
    }


    public class PartOfService
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public List<History> StatusHistory { get; set; }
        //public List<string> StatusHistory { get; set; }
        //public IEnumerable<string> StatusHistory { get; set; }

        //public List<PartOfHistory> StatusHistory { get; set; }

        //public string StatusHistory { get; set; }
        public int? WorkTime { get; set; }
        public int? BadWorkTime { get; set;}
        public int? DownTime { get; set; }

    }

    //public class PartOfHistory {
    //    public string Record { get; set; }
    //}
}
