using Assignment_Databasteknik.Contexts;
using Assignment_Databasteknik.Menus;
using Assignment_Databasteknik.Repositories;
using Assignment_Databasteknik.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment_Databasteknik
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\cms23\databasteknik\Assignment_Databasteknik\Contexts\Assignment_db.mdf;Integrated Security=True;Connect Timeout=30"));

            services.AddScoped<AddressRepo>();
            services.AddScoped<CustomerRepo>();
            services.AddScoped<ProductRepo>();
            services.AddScoped<ProductTypeRepo>();
            services.AddScoped<CustomerCategoryRepo>();

            services.AddScoped<CustomerService>();
            services.AddScoped<ProductService>();

            services.AddScoped<CustomerMenu>();
            services.AddScoped<MainMenu>();
            services.AddScoped<ProductMenu>();

            var sp = services.BuildServiceProvider();
            var mainMenu = sp.GetRequiredService<MainMenu>();
            await mainMenu.RunAsync();

        }
    }
}