﻿using Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Database
{
    public class DatabaseContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<IngredientDetails> IngredientDetails { get; set; } = null!;
        public DbSet<IngredientUsed> IngredientUsed { get; set; } = null!;
        public DbSet<RecipeDetails> RecipeDetails { get; set; } = null!;
        public DbSet<MealDay> MealDay { get; set; }
        public DbSet<RecipeUsed> RecipeUsed { get; set; }
        public DbSet<UserCookBook> UserCookBook { get; set; }



        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //IngridientDetails
            modelBuilder.Entity<IngredientDetails>().HasKey(ingridient=>ingridient.Id);
            modelBuilder.Entity<IngredientDetails>().Property(ingridient => ingridient.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<IngredientDetails>().Property(ingridient => ingridient.Type).HasConversion<string>();
            modelBuilder.Entity<IngredientDetails>().Property(ingridient => ingridient.AddDate).HasColumnType("smalldatetime");


            //RecipeDetails
            modelBuilder.Entity<RecipeDetails>().HasKey(recipeDetails => recipeDetails.Id);
            modelBuilder.Entity<RecipeDetails>().Property(recipeDetails => recipeDetails.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<RecipeDetails>().Property(recipeDetails => recipeDetails.Name).ValueGeneratedOnAdd();
            modelBuilder.Entity<RecipeDetails>().Property(recipeDetails => recipeDetails.Category).ValueGeneratedOnAdd();
            modelBuilder.Entity<RecipeDetails>().Property(recipeDetails => recipeDetails.Description).ValueGeneratedOnAdd();
            modelBuilder.Entity<RecipeDetails>().Property(recipeDetails => recipeDetails.ImagePath).ValueGeneratedOnAdd();
            modelBuilder.Entity<RecipeDetails>().Property(recipeDetails => recipeDetails.AddDate).HasColumnType("smalldatetime");


            //IngridientUsed
            modelBuilder.Entity<IngredientUsed>().HasKey(ingridientUsed => ingridientUsed.Id);
            modelBuilder.Entity<IngredientUsed>().Property(ingridientUsed => ingridientUsed.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<IngredientUsed>().Property(ingridientUsed => ingridientUsed.AddDate).HasColumnType("smalldatetime");

            //MealDay
            modelBuilder.Entity<MealDay>().HasKey(mealDay=>mealDay.Id);
            modelBuilder.Entity<MealDay>().Property(mealDay=>mealDay.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<MealDay>().Property(mealDay => mealDay.AddDate).HasColumnType("smalldatetime");
            modelBuilder.Entity<MealDay>().Property(mealDay => mealDay.Day).HasColumnType("smalldatetime");

            //RecipeUsed
            modelBuilder.Entity<RecipeUsed>().HasKey(recipeUsed => recipeUsed.Id);
            modelBuilder.Entity<RecipeUsed>().Property(recipeUsed => recipeUsed.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<RecipeUsed>().Property(recipeUsed => recipeUsed.AddDate).HasColumnType("smalldatetime");
            //UserCookBook
            modelBuilder.Entity<UserCookBook>().HasKey(userCookBook => userCookBook.Id);
            modelBuilder.Entity<UserCookBook>().Property(userCookBook => userCookBook.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<UserCookBook>().Property(userCookBook => userCookBook.Password).HasColumnType("binary").HasMaxLength(64);
            modelBuilder.Entity<UserCookBook>().Property(userCookBook => userCookBook.AddDate).HasColumnType("smalldatetime");

            modelBuilder.Entity<UserCookBook>().HasData(SampleData.SampleData.GetUserCookBookSampleDataFromJson());
            modelBuilder.Entity<IngredientDetails>().HasData(SampleData.SampleData.GetIngredientDetailsSampleDataFromJson());
            modelBuilder.Entity<RecipeDetails>().HasData(SampleData.SampleData.GetRecipeDetailsSampleDataFromJson());

            modelBuilder.Entity<IdentityUser>().ToTable("Users");
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
