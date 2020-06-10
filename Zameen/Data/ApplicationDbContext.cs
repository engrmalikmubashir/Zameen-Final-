using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zameen.Models;

namespace Zameen.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Floor> Floors { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Client> Clients { get; set; }

    }
}
