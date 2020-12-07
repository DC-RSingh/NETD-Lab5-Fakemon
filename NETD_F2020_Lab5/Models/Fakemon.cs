using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

#nullable enable

namespace NETD_F2020_Lab5.Models
{
    public class Fakemon
    {
        // The ID of the Fake Monster
        [Key]
        public int DexNumber { get; set; }

        // The Name of the Fake Monster
        public string Name { get; set; }

        // The Primary Type of the Fake Monster
        public Type TypeOne { get; set; }

        // The Secondary Type of the Fake Monster
        public Type? TypeTwo { get; set; } 

        // Statistical Data of the Fake Monster
        public Stats Statistics { get; set; }

    }
}
