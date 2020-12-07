using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NETD_F2020_Lab5.Models
{
    public class Stats : StatValue
    {

        // The Level of the Fake Monster
        // Used in calculating its Statistics
        public int Level { get; set; }

        // The Effort Values of the Fake Monster
        // Used in calculating its Statistics 
        public EffortValue EffortValues { get; set; }

        // The Individual Values of the Fake Monster
        // Used in Calculating its Statistics
        public IndividualValue IndividualValues { get; set; }

        // The Nature of the Fake Monster
        // Increases and Decreases a stat depending on the nature
        public Nature Nature { get; set; }
    }
}
