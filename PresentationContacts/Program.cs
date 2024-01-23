
using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharpProjects\LocalDatabaseProject\Infrastructure\Data\Local_db.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddScoped<ContactAddressRepository>();
    services.AddScoped<ContactRepository>();
    services.AddScoped<ContactInformationRepository>();
    services.AddScoped<EducationRepository>();
    services.AddScoped<WorkPlaceRepository>();
    services.AddScoped<ContactService>();
    services.AddSingleton<MenuService>();

}).Build();

builder.Start();

var menuService = builder.Services.GetRequiredService<MenuService>();

await menuService.ShowMeny();




