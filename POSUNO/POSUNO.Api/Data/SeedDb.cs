using Microsoft.EntityFrameworkCore;
using POSUNO.Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSUNO.Api.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            //Corre las migraciones (update-database)
            await _context.Database.EnsureCreatedAsync();
            await CheckUserAsync();
            await CheckCostumerAsync();
            await CheckProductsAsync();
        }

        private async Task CheckUserAsync()
        {
            if (!_context.Users.Any())
            {
                _context.Users.Add(new User {Email = "jurgen@yopmail.com", FirstName ="Jurgen", LastName = "Perez", Password = "123456"});
                _context.Users.Add(new User {Email = "natalia@yopmail.com", FirstName ="Natalia", LastName = "Vargas", Password = "123456"});

                //Guardamos los cambios en la DB
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCostumerAsync()
        {
            if (!_context.Products.Any())
            {
                Random random = new Random();
                User user = await _context.Users.FirstOrDefaultAsync();
                for (int i = 1; i <= 50; i++)
                {
                    _context.Customers.Add(new Customer
                    {
                        FirstName = $"Cliente {i}",
                        LastName = $"Apellido {i}",
                        Phonenumber = "318 557 0824",
                        Address = "Calle Elm Streeth",
                        Email = $"cliente{i}@yopmail.com",
                        IsActive = true,
                        User = user
                    });
                }

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckProductsAsync()
        {
            if (!_context.Products.Any())
            {
                Random random = new Random();
                User user = await _context.Users.FirstOrDefaultAsync();
                for (int i = 1; i <= 200 ; i++)
                {
                    _context.Products.Add(new Product 
                    { 
                        Name = $"Producto {i}", 
                        Description = $"Producto {i}", 
                        Price = random.Next(5, 1000), 
                        Stock = random.Next(0,500),
                        IsActive = true, 
                        User = user});
                }

                await _context.SaveChangesAsync();
            }
        }

        
        
    }
}
