using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<IngridientDetails> IngridientDetails { get; set; } = null!;
        public DbSet<IngridientUsed> IngridientUsed { get; set; } = null!;
        public DbSet<RecipeDetails> RecipeDetails { get; set; } = null!;
        public DbSet<MealDay> MealDay { get; set; }
        public DbSet<RecipeUsed> RecipeUsed { get; set; }
        public DbSet<UserCookBook> userCookBook { get; set; }



        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //IngridientDetails
            modelBuilder.Entity<IngridientDetails>().HasKey(ingridient=>ingridient.Id);
            modelBuilder.Entity<IngridientDetails>().Property(ingridient => ingridient.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<IngridientDetails>().Property(ingridient => ingridient.AddDate).HasColumnType("date");



            //RecipeDetails
            modelBuilder.Entity<RecipeDetails>().HasKey(recipeDetails => recipeDetails.Id);
            modelBuilder.Entity<RecipeDetails>().Property(recipeDetails => recipeDetails.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<RecipeDetails>().Property(recipeDetails => recipeDetails.AddDate).HasColumnType("date");


            //IngridientUsed
            modelBuilder.Entity<IngridientUsed>().HasKey(ingridientUsed => ingridientUsed.Id);
            modelBuilder.Entity<IngridientUsed>().Property(ingridientUsed => ingridientUsed.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<IngridientUsed>().Property(ingridientUsed => ingridientUsed.AddDate).HasColumnType("date");


            //MealDay
            modelBuilder.Entity<MealDay>().HasKey(mealDay=>mealDay.Id);
            modelBuilder.Entity<MealDay>().Property(mealDay=>mealDay.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<MealDay>().Property(mealDay => mealDay.AddDate).HasColumnType("date");
            modelBuilder.Entity<MealDay>().Property(mealDay => mealDay.Day).HasColumnType("date");

            //RecipeUsed
            modelBuilder.Entity<RecipeUsed>().HasKey(recipeUsed => recipeUsed.Id);
            modelBuilder.Entity<RecipeUsed>().Property(recipeUsed => recipeUsed.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<RecipeUsed>().Property(recipeUsed => recipeUsed.AddDate).HasColumnType("date");

            //UserCookBook
            modelBuilder.Entity<UserCookBook>().HasKey(userCookBook => userCookBook.Id);
            modelBuilder.Entity<UserCookBook>().Property(userCookBook => userCookBook.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<UserCookBook>().Property(userCookBook => userCookBook.AddDate).HasColumnType("date");
            modelBuilder.Entity<UserCookBook>().Property(userCookBook => userCookBook.Password).HasColumnType("binary").HasMaxLength(64);



        }
    }
}
