
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharpProjects\LocalDatabaseProject\Infrastructure\Data\Local_db.mdf;Integrated Security=True;Connect Timeout=30"));
    services.AddDbContext<ProductContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharpProjects\LocalDatabaseProject\Infrastructure\Data\Product_db.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddScoped<ContactAddressRepository>();
    services.AddScoped<ContactRepository>();
    services.AddScoped<ContactInformationRepository>();
    services.AddScoped<EducationRepository>();
    services.AddScoped<WorkPlaceRepository>();
    services.AddScoped<CategoryRepository>();
    services.AddScoped<ManufactureRepository>();
    services.AddScoped<PriceRepository>();
    services.AddScoped<ProductPictureRepository>();
    services.AddScoped<ProductRepository>();
    services.AddScoped<ContactService>();
    services.AddScoped<ProductService>();
    services.AddSingleton<MenuService>();
    services.AddSingleton<ProductMenuService>();

}).Build();

builder.Start();

var menuService = builder.Services.GetRequiredService<MenuService>();

await menuService.ShowMeny();




