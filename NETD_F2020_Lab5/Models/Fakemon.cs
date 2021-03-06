﻿// Name     : Raje Singh
// Course   : NETD3202
// School   : Durham College
// Date     : December 7, 2020
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public Guid DexNumber { get; set; }

        // The Name of the Fake Monster
        public string Name { get; set; }

        // The Primary Type of the Fake Monster
        [Column(TypeName = "nvarchar(40)")]
        public Type TypeOne { get; set; }

        // The Secondary Type of the Fake Monster
        [Column(TypeName = "nvarchar(40)")]
        public Type? TypeTwo { get; set; }

        // The Nature of the Fake Monster
        [Column(TypeName = "nvarchar(40)")]
        public Nature Nature { get; set; }

        // Navigation Property
        public virtual Stats? Statistics { get; set; }

    }
}
