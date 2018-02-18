using IdentityTest.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// This class needs to know that which type Application user and role are dealing with the Application. 
/// We passed ApplicationUser and IdentityRole as a parameter, while creating the object of ApplicationDbContext 
/// class. 
/// Here, the third parameter represents the primary key data type for both IdentityUser and IdentityRole.
/// </summary>
namespace IdentityTest.DbContexes
{
    public class ImplementIdentityDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ImplementIdentityDbContext(DbContextOptions<ImplementIdentityDbContext> options) : base(options)
        {
              //LD STEP2 after I want that an istance of "ApplicationUser" is part of the context
        }
    }
}