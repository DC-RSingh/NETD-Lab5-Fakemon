using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace NETD_F2020_Lab5.Models
{
    public class FakemonContext : DbContext
    {

        // Constructor for Fakemon Context
        public FakemonContext(DbContextOptions<FakemonContext> options) : base(options)
        {

        }

        public DbSet<Fakemon> Fakemons { get; set; }
    }
}
