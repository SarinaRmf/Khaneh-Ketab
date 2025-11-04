using HW17.Domain.Contracts.Repositories;
using HW17.Domain.Contracts.Services;
using HW17.Infrastructure.EfCore.Persistence;
using HW17.Infrastructure.EfCore.Repositories;
using HW17.Services;
using Microsoft.EntityFrameworkCore;

namespace HW17.Presentation.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HW17;User ID=sa;Password=Az@r4180;Trust Server Certificate=True "));
            builder.Services.AddScoped<ICategoryServices, CategoryServices>();
            builder.Services.AddScoped<IBookServices, BookServices>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IUserServices, UserServices>();


            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
