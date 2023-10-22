using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

using MyAPI.Data;
using MyAPI.Services;
//using MyAPI.Services.CreateServicesFolder;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        var services = builder.Services;

        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();


        services.AddMvc();
        //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        // Не использую норм БД, создаю только временную в памяти
        services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("db_API"));
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

        var scope = app.Services.CreateScope();
        services.AddTransient<IRepository, Repository>();
        services.AddSingleton<ServiceEventHandler>();
        //services.AddSingleton<ICreateServices, CreateServices>();

        var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        ctx.Database.EnsureCreated();
        //var a = new CreateServices(IRepository repo);

        app.Run();
    }
}