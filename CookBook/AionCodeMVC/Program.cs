using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using CookBook.BuisnesLogic.Services.IngredientServices;
using CookBook.BuisnesLogic.Repositories;
using AionCodeMVC.Repositories;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using CookBook.BuisnesLogic.Services.UserServices;
using Database;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Azure;
using Azure.Storage.Blobs;
using CookBook.BuisnesLogic.Interfaces.AzureInterfaces;
using CookBook.BuisnesLogic.Services.AzureStorage;
using CookBook.BuisnesLogic.Interfaces.RecipeInterfacces;
using CookBook.BuisnesLogic.Services.RecipeServices;
using Microsoft.AspNetCore.Identity;

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

            //Azurite storage
            builder.Services.AddAzureClients(clientBuilder => clientBuilder.AddBlobServiceClient(builder.Configuration["AzureStorage:BlolbConnectionString"]));
            builder.Services.AddScoped<IAzureStorage, AzureStorageService>();


            //Add automapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Add Identity
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<DatabaseContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Users/Login";
                options.AccessDeniedPath = "/Users/AccessDenied";
            });

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = true;
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                    policy.RequireRole("Admin"));
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("StdUser", policy =>
                    policy.RequireRole("StdUser", "Admin"));
            });

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

            builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
            builder.Services.AddScoped<ICreateRecipeService, CreateRecipeService>();
            builder.Services.AddScoped<IGetRecipeService, GetRecipeService>();
            builder.Services.AddScoped<IDeleteRecipeService, DeleteRecipeService>();
            builder.Services.AddScoped<IEditRecipeService, EditRecipeService>();
            builder.Services.AddScoped<IUploadRecipePhotoService, UploadRecipePhotoService>();

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

            CreateRoles(app.Services).Wait();

            app.Run();

            async Task CreateRoles(IServiceProvider serviceProvider)
            {
                // Scoped services inside method to avoid directly injecting them into Configure
                using (var scope = serviceProvider.CreateScope())
                {
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                    string[] roleNames = { "Admin", "StdUser", "Guest" };

                    foreach (var roleName in roleNames)
                    {
                        var roleExist = await roleManager.RoleExistsAsync(roleName);
                        if (!roleExist)
                        {
                            await roleManager.CreateAsync(new IdentityRole(roleName));
                        }
                    }

                    if (!await roleManager.RoleExistsAsync("Admin"))
                    {
                        await roleManager.CreateAsync(new IdentityRole("Admin"));
                    }

                    var adminUser = await userManager.FindByNameAsync("admin");
                    if (adminUser == null)
                    {
                        var admin = new IdentityUser
                        {
                            UserName = "admin",
                            Email = "admin@admin.asd"
                        };

                        var result = await userManager.CreateAsync(admin, "Qwerty123!");

                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(admin, "Admin");
                        }
                        else
                        {
                            throw new Exception("Nie mo¿na utworzyæ u¿ytkownika admin.");
                        }
                    }
                }
            }
        }
    }
}
