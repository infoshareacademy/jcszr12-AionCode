using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Database.Entities;

    public class AionCodeDatabase : DbContext
    {
        public AionCodeDatabase (DbContextOptions<AionCodeDatabase> options)
            : base(options)
        {
        }

        public DbSet<Database.Entities.MealDay> MealDay { get; set; } = default!;
    }
