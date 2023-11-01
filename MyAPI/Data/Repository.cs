using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Hosting;
using MyAPI.Models;
using System;

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
            return get;
            //return _ctx.Services.ToList();
        }


        //public void UpdateService(Service service) - БЫЛО
        public void UpdateService(AppDbContext context, Service service)
        {
            //service.UpdatedAt = DateTime.Now;
            //_ctx.Services.Update(service); - БЫЛО
            context.Services.Update(service);
            context.SaveChanges();

            var a = GetService(context, 1);
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
}
