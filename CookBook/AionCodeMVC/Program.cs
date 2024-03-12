using AionCodeMVC.Interfaces;
using AionCodeMVC.Repositories;
using AionCodeMVC.Services;

namespace AionCodeMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
            builder.Services.AddScoped<IGetIngredientService, GetIngredientService>();
            builder.Services.AddScoped<ICreateIngredientService, CreateIngredientService>();
            builder.Services.AddScoped<IDeleteIngredientService, DeleteIngredientService>();
            builder.Services.AddScoped<IEditIngredientService,  EditIngredientService>();

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
