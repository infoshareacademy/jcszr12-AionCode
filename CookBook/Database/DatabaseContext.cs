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
        public DbSet<IngredientDetails> IngredientDetails { get; set; } = null!;
        public DbSet<IngridientUsed> IngridientUsed { get; set; } = null!;
        public DbSet<RecipeDetails> RecipeDetails { get; set; } = null!;
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<IngredientDetails>().HasKey(ingredient=>ingredient.Id);
            modelBuilder.Entity<IngredientDetails>().Property(ingredient => ingredient.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<IngredientDetails>().Property(ingredient => ingredient.AddDate).HasColumnType("date");



            //---------
            modelBuilder.Entity<RecipeDetails>().HasKey(recipeDetails => recipeDetails.Id);
            modelBuilder.Entity<RecipeDetails>().Property(recipeDetails => recipeDetails.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<RecipeDetails>().Property(recipeDetails => recipeDetails.AddDate).HasColumnType("date");


            //---------
            modelBuilder.Entity<IngridientUsed>().HasKey(ingridientUsed => ingridientUsed.Id);
            modelBuilder.Entity<IngridientUsed>().Property(ingridientUsed => ingridientUsed.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<IngridientUsed>().Property(ingridientUsed => ingridientUsed.AddDate).HasColumnType("date");

        }
    }
}
