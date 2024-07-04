using AionCodeMVC.Repositories;
using CookBook.BuisnesLogic.Interfaces.AzureInterfaces;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using CookBook.BuisnesLogic.Interfaces.MealDayServiceInterfaces;
using CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces;
using CookBook.BuisnesLogic.Interfaces.RecipeInterfacces;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using CookBook.BuisnesLogic.Repositories;
using CookBook.BuisnesLogic.Services.AzureStorage;
using CookBook.BuisnesLogic.Services.IngredientCommentServices;
using CookBook.BuisnesLogic.Services.IngredientServices;
using CookBook.BuisnesLogic.Services.MealDayServices;
using CookBook.BuisnesLogic.Services.MyFridgeServices;
using CookBook.BuisnesLogic.Services.RecipeServices;
using CookBook.BuisnesLogic.Services.UserServices;
using Database;
using Database.SampleData;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Azure.Storage.Blobs;
using CookBook.BuisnesLogic.Interfaces.AzureInterfaces;
using CookBook.BuisnesLogic.Services.AzureStorage;
using CookBook.BuisnesLogic.Interfaces.RecipeInterfacces;
using CookBook.BuisnesLogic.Services.RecipeServices;
using Microsoft.AspNetCore.Identity;
using CookBook.BuisnesLogic.Models;
using Database.SampleData;
using Microsoft.Extensions.DependencyInjection;
using CookBook.BuisnesLogic.Services.IngredientCommentServices;
using NuGet.Common;
using CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces;
using CookBook.BuisnesLogic.Services.MyFridgeServices;

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
            builder.Services.AddIdentity<Database.Entities.UserCookBook, IdentityRole>(options =>
            {
                options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
            })
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Users/Login";
                options.AccessDeniedPath = "/Users/AccessDenied";
            });

            builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection(nameof(SmtpSettings)));

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = true;
                options.SignIn.RequireConfirmedAccount = true;
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
            builder.Services.AddScoped<IEditIngredientService, EditIngredientService>();
            builder.Services.AddScoped<IUploadIngredientPhotoService, UploadIngredientPhotoService>();
            builder.Services.AddScoped<IAddCommentService, AddCommentService>();
            builder.Services.AddScoped<IDeleteCommentService, DeleteCommentService>();

            builder.Services.AddScoped<IGetMyFridgeService, GetMyFridgeService>();
            builder.Services.AddScoped<ICreateFridgeService, CreateFridgeService>();
            builder.Services.AddScoped<IDeleteMyFridgeService, DeleteMyFridgeService>();
            builder.Services.AddScoped<IAddFridgeIngredientService, AddFridgeIngredientService>();


            builder.Services.AddScoped<IUsersRepository, UsersRepository>();
            builder.Services.AddScoped<IGetUserService, GetUserService>();
            builder.Services.AddScoped<IDeleteUserService, DeleteUserService>();
            builder.Services.AddScoped<IEditUserService, EditUserService>();
            builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
            builder.Services.AddScoped<IEmailService, EmailService>();

            builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
            builder.Services.AddScoped<ICreateRecipeService, CreateRecipeService>();
            builder.Services.AddScoped<IGetRecipeService, GetRecipeService>();
            builder.Services.AddScoped<IDeleteRecipeService, DeleteRecipeService>();
            builder.Services.AddScoped<IEditRecipeService, EditRecipeService>();
            builder.Services.AddScoped<IUploadRecipePhotoService, UploadRecipePhotoService>();

            builder.Services.AddScoped<IMealDaysServicesInterface, MealDaysServices>();

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

            InitializeDatabaseAndRoles(app.Services).Wait();

            app.Run();


            async Task InitializeDatabaseAndRoles(IServiceProvider serviceProvider)
            {
                // Scoped services inside method to avoid directly injecting them into Configure
                using (var scope = serviceProvider.CreateScope())
                {
                    //Used services
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Database.Entities.UserCookBook>>();
                    var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                    // Ensure the database is created
                    var wasDbCreated = dbContext.Database.EnsureCreated();

                    // Define role names
                    string[] roleNames = { "Admin", "StdUser", "Guest" };

                    // Create roles if they don't exist
                    foreach (var roleName in roleNames)
                    {
                        var roleExist = await roleManager.RoleExistsAsync(roleName);
                        if (!roleExist)
                        {
                            await roleManager.CreateAsync(new IdentityRole(roleName));
                        }
                    }

                    // Create Admin user if not exists and assign Admin role
                    var adminUser = await userManager.FindByNameAsync("admin");
                    if (adminUser == null)
                    {
                        var admin = new Database.Entities.UserCookBook
                        {
                            UserName = "admin",
                            Email = "admin@admin.asd",
                            AddDate = DateTime.Now
                        };

                        var result = await userManager.CreateAsync(admin, "Qwerty123!");

                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(admin, "Admin");
                            var token = await userManager.GenerateEmailConfirmationTokenAsync(admin);
                            await userManager.ConfirmEmailAsync(admin, token);
                        }
                        else
                        {
                            throw new Exception("Nie można utworzyć użytkownika admin.");
                        }
                    }

                    // Create Admin user if not exists and assign Admin role
                    var stdUser = await userManager.FindByNameAsync("standardowyUser");
                    if (stdUser == null)
                    {
                        var stdUsr = new Database.Entities.UserCookBook
                        {
                            UserName = "standardowyUser",
                            Email = "standardowyUser@admin.asd",
                            AddDate = DateTime.Now
                        };

                        var result = await userManager.CreateAsync(stdUsr, "Qwerty123!");

                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(stdUsr, "StdUser");
                            var token = await userManager.GenerateEmailConfirmationTokenAsync(stdUsr);
                            await userManager.ConfirmEmailAsync(stdUsr, token);
                        }
                        else
                        {
                            throw new Exception("Nie można utworzyć użytkownika stdusera.");
                        }
                    }

                    //if database didnt exist before, seed it with data
                    if (wasDbCreated)
                    {
                        await SampleData.SeedDatabaseWithIngredients(dbContext, userManager.Users);
                        await SampleData.SeedDatabaseWithRecipes(dbContext, userManager.Users);
                    }

                }
            }



        }
    }
}
