using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace NETD_F2020_Lab5.Models
{
    public class FakedexContext : DbContext
    {

        // Constructor for Fakemon Context
        public FakedexContext(DbContextOptions<FakedexContext> options) : base(options)
        {

        }

        public DbSet<Fakemon> Fakemons { get; set; }

        // To add database:
        // Add-Migration InitialCreate -- In Tools->Nuget Packet Manager->Packet Manager Console
        // Once the folder exists
        // In Packet Manager Console do: Update-Database
    }
}
