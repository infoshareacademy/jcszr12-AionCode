using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using CookBook.BuisnesLogic.Services.IngredientServices;
using CookBook.BuisnesLogic.Repositories;
using AionCodeMVC.Repositories;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using CookBook.BuisnesLogic.Services.UserServices;
using Database;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using CookBook.BuisnesLogic.AzureStorage;

namespace AionCodeMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add database
            builder.Services.AddDbContext<DatabaseContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("AionCodeDatabase")));
            //Add AzureStorage configuration -> appsettings.Development.json
            builder.Services.Configure<AzureStorage>(options=>builder.Configuration.GetSection("AzureStorage").Bind(options));

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
            builder.Services.AddScoped<IGetIngredientService, GetIngredientService>();
            builder.Services.AddScoped<ICreateIngredientService, CreateIngredientService>();
            builder.Services.AddScoped<IDeleteIngredientService, DeleteIngredientService>();
            builder.Services.AddScoped<IEditIngredientService,  EditIngredientService>();
            builder.Services.AddScoped<IUploadIngredientPhotoService, UploadIngredientPhotoService>();
            


            builder.Services.AddScoped<IUsersRepository, UsersRepository>();
            builder.Services.AddScoped<IGetUserService, GetUserService>();
            builder.Services.AddScoped<IDeleteUserService, DeleteUserService>();
            builder.Services.AddScoped<IEditUserService, EditUserService>();
            builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
            

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
