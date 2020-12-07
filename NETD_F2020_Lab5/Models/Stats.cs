using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NETD_F2020_Lab5.Models
{
    public class Stats
    {
        [ForeignKey("Fakemon")]
        public Guid StatsId { get; set; }

        public int HitPoints { get; set; } // The Health Stat

        public int Attack { get; set; }  // The Attack Stat

        public int Defense { get; set; } // The Defense Stat

        public int SpecialAttack { get; set; } // The Special Attack (Magical Attack) Stat

        public int SpecialDefense { get; set; } // The Special Defense (Magical Defense) Stat

        public int Speed { get; set; } // The Speed Stat

        public int Total => HitPoints + Attack + Defense + SpecialAttack + SpecialDefense + Speed; // The Total of Every Stat

        // Navigation Property
        public virtual Fakemon Fakemon { get; set; }
    }
}
