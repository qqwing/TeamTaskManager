using Microsoft.EntityFrameworkCore;
using TeamWork.Models;  //пространство имен для модели и контекста

namespace TeamWork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //служба для работы с базой данных PostgreSQL
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); //настройка контекста с строкой подключения

            //службы MVC, контроллеры и представления для обработки HTTP запросов и возвращение ответов в виде HTML
            builder.Services.AddControllersWithViews();

            var app = builder.Build(); //строит приложение после того, как все службы были добавлены

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error"); //обработка ошибок в продакшн-режиме
                app.UseHsts(); //активация HSTS для повышения безопасности
            }

            app.UseHttpsRedirection(); //перенаправление на https
            app.UseStaticFiles(); //разрешение серверу обслуживать статик.файлы (изображения,css,js)

            app.UseRouting(); //настройка маршрутизации для обработки запросов (например, к контроллерам и действиям)

            app.UseAuthorization(); //настройка авторизации

            //настройка маршрутов для MVC, определение базового маршрута для контроллеров
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Tasks}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
