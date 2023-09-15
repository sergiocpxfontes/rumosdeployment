using static Data.AppDBContext;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Lib;

namespace Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext>
            options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=CBRAIN-VII//SQLEXPRESS;Database=Rumos;Trusted_Connection=True;");
            }
        }
        public DbSet<Individuo> Individuos { get; set; }
    }
}