using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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





        }
    }
}
