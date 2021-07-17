using Microsoft.EntityFrameworkCore;
using POSUNO.Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSUNO.Api.Data
{
    public class DataContext : DbContext
    { //>Va representar nuestro contexto de datos
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        //Crear un indice para que no haya 2 productos con la misma descripcion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();  //Dentro de la tabla producto el nombre es unico
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique(); //Dentro de la tabla usuario el email es unico
            modelBuilder.Entity<Customer>().HasIndex(c => c.Email).IsUnique(); //Dentro de la tabla usuario el email es unico
        }
    }
}
