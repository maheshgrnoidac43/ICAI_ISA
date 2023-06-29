using ICAI_ISA.Core;
using ICAI_ISA.Repository;
using ICAI_ISA.Repository.Interfaces;
using ICAI_ISA.Services;
using ICAI_ISA.Services.Interfaces;

namespace ICAI_ISA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<SqlDbContext>();

            builder.Services.AddScoped<IExamCenterRepository, ExamCenterRepository>();
            builder.Services.AddScoped<IExamSessionRepository, ExamSessionRepository>();
            builder.Services.AddScoped<IInfoService, InfoService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Info}/{action=Welcome}/{id?}");

            app.Run();
        }
    }
}