using Microsoft.EntityFrameworkCore;
using TeamWork.Models;  //������������ ���� ��� ������ � ���������

namespace TeamWork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //������ ��� ������ � ����� ������ PostgreSQL
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); //��������� ��������� � ������� �����������

            //������ MVC, ����������� � ������������� ��� ��������� HTTP �������� � ����������� ������� � ���� HTML
            builder.Services.AddControllersWithViews();

            var app = builder.Build(); //������ ���������� ����� ����, ��� ��� ������ ���� ���������

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error"); //��������� ������ � ��������-������
                app.UseHsts(); //��������� HSTS ��� ��������� ������������
            }

            app.UseHttpsRedirection(); //��������������� �� https
            app.UseStaticFiles(); //���������� ������� ����������� ������.����� (�����������,css,js)

            app.UseRouting(); //��������� ������������� ��� ��������� �������� (��������, � ������������ � ���������)

            app.UseAuthorization(); //��������� �����������

            //��������� ��������� ��� MVC, ����������� �������� �������� ��� ������������
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Tasks}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
