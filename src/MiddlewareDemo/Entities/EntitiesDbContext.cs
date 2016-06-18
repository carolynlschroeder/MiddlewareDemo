using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiddlewareDemo.Entities;

namespace MiddlewareDemo.Entities
{
    public class EntitiesDbContext : DbContext
    {
        public DbSet<Image> Image { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.\SQLSERVEREXPRESS;Database=SignalRDemo;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

    }
}
