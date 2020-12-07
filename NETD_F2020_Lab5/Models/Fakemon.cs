using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable enable

namespace NETD_F2020_Lab5.Models
{
    public class Fakemon
    {
        // The ID of the Fake Monster
        public int DexNumber { get; set; }

        // The Name of the Fake Monster
        public string Name { get; set; }

        // The Primary Type of the Fake Monster
        public string TypeOne { get; set; }

        // The Secondary Type of the Fake Monster
        public string? TypeTwo { get; set; } 

        // Statistical Data of the Fake Monster
        public Stats Statistics { get; set; }

    }
}
