using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

using MyAPI.Data;
using MyAPI.Services;
using System.Reflection.Emit;
//using MyAPI.Services.CreateServicesFolder;
//internal class Program
//{
//private static void Main(string[] args)
//{
    var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Entity<AccessLevel>().OwnsOne(x => x.Access);

var services = builder.Services;

    services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();


    services.AddMvc();
    //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Не использую норм БД, создаю только временную в памяти
services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("db_API"));
//services.AddS

//services.AddHostedService<ServiceEventHandler>();
//services.Add

services.AddTransient<IRepository, Repository>();   //БЫЛО

//services.AddScoped<IRepository, Repository>();   // СТАЛО
//services.AddSingleton<IServiceEventHandler, ServiceEventHandler>();
//services.AddSingleton<>

services.AddTransient<IServiceEventHandler, ServiceEventHandler>();

//services.AddScoped<IServiceEventHandler, ServiceEventHandler>();
//services.AddSingleton<IServiceEventHandler, ServiceEventHandler>();
var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
    app.UseSwagger();
    app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();


// Позволяет создать Singleton объект (создаётся только 1 раз),
// который является одноэлементным и имеет одноразовые зависимости (нап Transient repository)

var scope = app.Services.CreateScope();
var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();

//var serviceEventHandler = scope.ServiceProvider.GetRequiredService<IServiceEventHandler>();

//services.AddSingleton<ICreateServices, CreateServices>();


//var serviceEventHandler = scope.ServiceProvider.GetRequiredService<IServiceEventHandler>();
//ctx.Database.EnsureCreated();
//var a = new CreateServices(IRepository repo);

app.Run();
//    }
//}