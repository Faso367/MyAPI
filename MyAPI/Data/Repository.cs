using Microsoft.Extensions.Hosting;
using MyAPI.Models;

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

        // РАБОЧИЙ МЕТОД
        public Service GetService(int id)
        {
            // Если полученный id совпадает с найденным в БД, то возвращаем (достаем) эту запись
            return _ctx.Services.FirstOrDefault(p => p.Id == id);
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

        public List<Service> GetAllServices()
        {
            return _ctx.Services.ToList();
        }


        public void UpdateService(Service service)
        {
            //service.UpdatedAt = DateTime.Now;
            Console.WriteLine("UpdateService");

            _ctx.Services.Update(service);
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
