using Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class DatabaseContext : IdentityDbContext<UserCookBook>
    {
        public DbSet<IngredientDetails> IngredientDetails { get; set; } = null!;
        public DbSet<IngredientUsed> IngredientUsed { get; set; } = null!;
        public DbSet<RecipeDetails> RecipeDetails { get; set; } = null!;
        public DbSet<MealDay> MealDay { get; set; }
        public DbSet<RecipeUsed> RecipeUsed { get; set; }
        public DbSet<Database.Entities.UserCookBook> UserCookBook { get; set; }

        public DbSet<MyFridge> MyFridge { get; set; }
        public DbSet<MyFridgeIngredient> MyFridgeIngredient { get; set; }

        public DbSet<IngredientComment> IngredientComment { get; set; }

        public DbSet<RecipeComment> RecipeComments { get; set; }
        public DbSet<RecipeRating> RecipeRatings { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //IngridientDetails
            modelBuilder.Entity<IngredientDetails>().HasKey(ingridient => ingridient.Id);
            modelBuilder.Entity<IngredientDetails>().Property(ingridient => ingridient.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<IngredientDetails>().Property(ingridient => ingridient.Type).HasConversion<string>();
            //modelBuilder.Entity<IngredientDetails>().Property(ingridient => ingridient.AddDate).HasColumnType("smalldatetime");


            //RecipeDetails
            modelBuilder.Entity<RecipeDetails>().HasKey(recipeDetails => recipeDetails.Id);
            modelBuilder.Entity<RecipeDetails>().Property(recipeDetails => recipeDetails.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<RecipeDetails>().Property(recipeDetails => recipeDetails.Name).ValueGeneratedOnAdd();
            modelBuilder.Entity<RecipeDetails>().Property(recipeDetails => recipeDetails.Category).ValueGeneratedOnAdd();
            modelBuilder.Entity<RecipeDetails>().Property(recipeDetails => recipeDetails.Description).ValueGeneratedOnAdd();
            modelBuilder.Entity<RecipeDetails>().Property(recipeDetails => recipeDetails.ImagePath).ValueGeneratedOnAdd();
            //modelBuilder.Entity<RecipeDetails>().Property(recipeDetails => recipeDetails.AddDate).HasColumnType("smalldatetime");


            //IngridientUsed
            modelBuilder.Entity<IngredientUsed>().HasKey(ingridientUsed => ingridientUsed.Id);
            modelBuilder.Entity<IngredientUsed>().Property(ingridientUsed => ingridientUsed.Id).ValueGeneratedOnAdd();
            //modelBuilder.Entity<IngredientUsed>().Property(ingridientUsed => ingridientUsed.AddDate).HasColumnType("smalldatetime");

            //MealDay
            modelBuilder.Entity<MealDay>().HasKey(mealDay => mealDay.Id);
            modelBuilder.Entity<MealDay>().Property(mealDay => mealDay.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<MealDay>().Property(mealDay => mealDay.Day).HasColumnType("smalldatetime");
            modelBuilder.Entity<MealDay>().Property(mealDay => mealDay.AddDate).HasColumnType("smalldatetime");

            //RecipeUsed
            modelBuilder.Entity<RecipeUsed>().HasKey(recipeUsed => recipeUsed.Id);
            modelBuilder.Entity<RecipeUsed>().Property(recipeUsed => recipeUsed.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<RecipeUsed>().Property(recipeUsed => recipeUsed.AddDate);

            //UserCookBook
            //modelBuilder.Entity<UserCookBook>().Property(userCookBook => userCookBook.AddDate).HasColumnType("smalldatetime");

            modelBuilder.Entity<UserCookBook>().ToTable("UserCookBook");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins")
                                                         .HasKey(ul => ul.UserId); // Define primary key
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

        }
    }
}
