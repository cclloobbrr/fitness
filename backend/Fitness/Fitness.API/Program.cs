using Fitness.Application.Services;
using Fitness.Core.Abstractions;
using Fitness.DataAccess;
using Fitness.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Добавляем контроллеры
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS - разрешаем всё для разработки (и для контейнера)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Подключение к PostgreSQL
builder.Services.AddDbContext<FitnessDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(FitnessDbContext)));
});

// Регистрация сервисов
builder.Services.AddScoped<IMembershipsService, MembershipsService>();
builder.Services.AddScoped<IMembershipsRepository, MembershipsRepository>();

var app = builder.Build();

// ? АВТОМАТИЧЕСКИЕ МИГРАЦИИ (без dotnet-ef) ?
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<FitnessDbContext>();
    try
    {
        Console.WriteLine("?? Применяем миграции...");
        await dbContext.Database.MigrateAsync();
        Console.WriteLine("? Миграции применены успешно!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"?? Ошибка миграции: {ex.Message}");
    }
}

// Swagger всегда включен (для простоты)
app.UseSwagger();
app.UseSwaggerUI();

// CORS должен быть ДО UseAuthorization
app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

//using Fitness.Application.Services;
//using Fitness.Core.Abstractions;
//using Fitness.DataAccess;
//using Fitness.DataAccess.Repositories;
//using Microsoft.EntityFrameworkCore;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//// Хз снести ес чо
//// ДОБАВЬТЕ ЭТО
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll",
//        policy =>
//        {
//            policy.AllowAnyOrigin()      // Разрешить запросы с любых доменов
//                  .AllowAnyMethod()      // Разрешить любые HTTP методы (GET, POST, PUT, DELETE)
//                  .AllowAnyHeader();     // Разрешить любые заголовки
//        });
//});
//// Хз снести ес чо

//builder.Services.AddDbContext<FitnessDbContext>(options =>
//    {
//        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(FitnessDbContext)));
//    });


//builder.Services.AddScoped<IMembershipsService, MembershipsService>();
//builder.Services.AddScoped<IMembershipsRepository, MembershipsRepository>();




//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//// ? ДОБАВЬТЕ ЭТО ПЕРЕД UseAuthorization ?
//app.UseCors("AllowAll");
//// ? ДОБАВЬТЕ ЭТО ПЕРЕД UseAuthorization ?

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();


// Миграции
// D:\Вова Важное\GitHub\fitness\backend\Fitness>dotnet ef database update --project ./Fitness.DataAccess --startup-project ./Fitness.API

//version: "3.9"

//services:
//postgres:
//container_name: postgres
//image: postgres: 17 - alpine
//        environment:
//POSTGRES_DB: "db"
//            POSTGRES_USER: "postgres"
//            POSTGRES_PASSWORD: "123"
//        volumes:
//-postgres - data:/ var / lib / postgresql / data
//        ports:
//-"5432:5432"

//volumes:
//postgres - data:


