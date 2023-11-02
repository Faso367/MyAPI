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
        //public Repository()
        {
            _ctx = ctx;
            //_ctx = new AppDbContext();
        }

        // Добавляем запись в БД
        public void AddService(Service service)
        {
            _ctx.Services.Add(service);
        }

        public void AddService(AppDbContext context, Service service)
        {
            //_ctx.Services.Add(service);
            context.Services.Add(service);
        }


        // РАБОЧИЙ МЕТОД
        //public Service GetService(int id) - БЫЛО
        public Service GetService(AppDbContext context, int id)
        {
            // Если полученный id совпадает с найденным в БД, то возвращаем (достаем) эту запись
            //return _ctx.Services.FirstOrDefault(p => p.Id == id); - БЫЛО
            var get = context.Services.FirstOrDefault(p => p.Id == id);
            return get;
        }

        //public async Service GetService(int id)
        //{
        //    // Если полученный id совпадает с найденным в БД, то возвращаем (достаем) эту запись
        //    //return await _ctx.Services.FirstOrDefault(p => p.Id == id);
        //    await _ctx.Services.FirstOrDefault(p => p.Id == id);

        //    if (await _ctx.SaveChangesAsync() > 0)
        //        return true;

        //    return false;
        //}

        //public List<Service> GetAllServices()
        //{
        //    return _ctx.Services.ToList();
        //}

        public List<Service> GetAllServices(AppDbContext context)
        {
            var get = context.Services.ToList();
            //get.Remove(context.Services.);
            //var get2 = _ctx.Services.ToList();
            return get;
            //return _ctx.Services.ToList();
        }

        public List<PartOfService> GetServicesInfo(AppDbContext context)
        //public List<System.Reflection.PropertyInfo> GetServicesInfo(AppDbContext context)
        {

            //var get = context.Services.Where(
            //    x => x.Id != -1,
            //    x => x.Name != "",
            //    x => x.WorkTime != -1,
            //    x => x.Descriprion != ""
            //);



            //var get = context.Services.;



            //var get2 = get.

            //for(int i = 0; i < 3; i++)
            //{
            //    for(int j = 0; j < 12; j++)
            //    {
            //        if get2[i] == Service.DownTime;
            //    }
            //}

            //get.ToList();
            //var get = context.Services.Where(x => x.Timer == null).ToList();

            //List <System.Reflection.PropertyInfo> result = new List<System.Reflection.PropertyInfo>();

            //var properties = context.Services.GetType().GetProperties();
            //foreach (var property in properties)
            //    if (property.Name != "isFirstTime" && property.Name != "Timer")
            //        result.Add(property);

            List<PartOfService> servicesInfo = context.Services.Select(service => new PartOfService
            {

                //var service = context.Services;

                //  var Myservice = new Service({
                Name = service.Name,
                Description = service.Description,
                Status = service.Status,
                StatusHistory = service.StatusHistory,
                WorkTime = service.WorkTime,
                BadWorkTime = service.BadWorkTime,
                DownTime = service.DownTime
            }).ToList();

            return servicesInfo;

                //CreatedAt = ser
                //});

            //var get2 = _ctx.Services.ToList();
            //return get.ToList();
            //return result.ToList();
        }

        public List<Service> GetAllServices()
        {

            return _ctx.Services.ToList();
        }


        //public void UpdateService(Service service) - БЫЛО
        public void UpdateService(AppDbContext context, Service service)
        {
            //service.UpdatedAt = DateTime.Now;
            //_ctx.Services.Update(service); - БЫЛО


            //context.Services.Update(service);
            context.Services.Update(service);

            Console.WriteLine("UpdateService");
        }

        public void UpdateService(Service service)
        {
            _ctx.Services.Update(service);
            _ctx.SaveChanges();

            //var a = GetService(context, 1);
            Console.WriteLine("UpdateService2");
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
        public string StatusHistory { get; set; }
        public int? WorkTime { get; set; }
        public int? BadWorkTime { get; set;}
        public int? DownTime { get; set; }

    }
}
