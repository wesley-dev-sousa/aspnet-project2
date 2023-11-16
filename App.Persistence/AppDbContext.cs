using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }


        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Pessoa> pessoas { get; set; }
        public DbSet<Pokemon> pokemons { get; set; } 

    }
}
