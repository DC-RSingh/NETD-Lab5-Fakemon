﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Import Identity Framework for user login and register functionality
using Microsoft.AspNetCore.Identity;

namespace NETD_F2020_Lab5.Models
{
    public class User : IdentityUser
    {

        // The Fake Monsters Created by the User
        // public ICollection<Fakemon> Fakemons { get; set; }
    }
}
