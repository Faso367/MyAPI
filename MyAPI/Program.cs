using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

using MyAPI.Data;
using MyAPI.Services;
using System.Reflection.Emit;
using Microsoft.Extensions.DependencyInjection;
using static System.Net.Mime.MediaTypeNames;
using System;
using Microsoft.Extensions.Options;
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

//services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("db_API")); //- БЫЛО

services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("db_API"), ServiceLifetime.Scoped);
//services.AddDbContext<AppDbContext>(options =>
//{
//    options.UseInMemoryDatabase("db_API")
//    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//}
//);
//services.AddS

//services.AddHostedService<ServiceEventHandler>();
//services.Add

//services.AddTransient<IRepository, Repository>();   //БЫЛО

services.AddTransient<IRepository, Repository>();   // СТАЛО

//services.AddSingleton<IServiceEventHandler, ServiceEventHandler>();
//services.AddSingleton<>

//var a = services.AddTransient<IServiceEventHandler, ServiceEventHandler>();

//services.AddTransient<IServiceEventHandler, ServiceEventHandler>();

//services.AddScoped<IServiceEventHandler, ServiceEventHandler>();
var context = new AppDbContext();
var repo = new Repository(context);

var api = new ServiceEventHandler(repo);
api.StartServices();
//builder.Services.AddSingleton<IServiceEventHandler>(api);

services.AddTransient<IServiceEventHandler, ServiceEventHandler>();


//services.AddScoped<IServiceEventHandler, ServiceEventHandler>();

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

// БЫЛО


//I build a new service provider from the services collection
//using (ServiceProvider serviceProvider = services.BuildServiceProvider())
//{
//    // Review the FormMain Singleton.
//    var formMain = serviceProvider.GetRequiredService<ServiceEventHandler>();
//    app.Run(formMain);
//}


//app.Run(async context =>
//{
//    var timeService = app.Services.GetService<ITimeService>();
//    await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");
//});


//var scope = app.Services.CreateScope();
//var ctx = scope.ServiceProvider.GetRequiredService<ServiceEventHandler>(); БЫЛО

//var ctx = app.Services.GetRequiredService<ServiceEventHandler>();

//-----------------------------------
//var scope = app.Services.CreateAsyncScope();
//var scope = app.Services.CreateAsyncScope();
//var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();

//var serv = scope.ServiceProvider.GetRequiredService<IServiceEventHandler>();

//serv.StartServices();

app.Run();


//var scope = app.Services.CreateAsyncScope();

//var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//ctx.Database.EnsureCreated();

//var ctx = scope.ServiceProvider.GetRequiredService<ServiceEventHandler>();


//var serviceEventHandler = scope.ServiceProvider.GetRequiredService<IServiceEventHandler>();

//services.AddSingleton<ICreateServices, CreateServices>();


//var serviceEventHandler = scope.ServiceProvider.GetRequiredService<IServiceEventHandler>();
//ctx.Database.EnsureCreated();
//var a = new CreateServices(IRepository repo);


//    }
//}