// Name     : Raje Singh
// Course   : NETD3202
// School   : Durham College
// Date     : December 7, 2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Import Entity Framework
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NETD_F2020_Lab5.Models;

namespace NETD_F2020_Lab5.Models
{
    public class FakedexContext : IdentityDbContext<User>
    {

        // Constructor for Fakemon Context
        public FakedexContext(DbContextOptions<FakedexContext> options) : base(options)
        {
        }

        public DbSet<Fakemon> Fakemons { get; set; }

        public DbSet<Stats> Stats { get; set; }

        // To add database:
        // Add-Migration InitialCreate -- In Tools->Nuget Packet Manager->Packet Manager Console
        // Once the folder exists
        // In Packet Manager Console do: Update-Database
    }
}
