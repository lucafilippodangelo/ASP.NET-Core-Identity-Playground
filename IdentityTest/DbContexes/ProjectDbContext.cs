using IdentityTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTest.DbContexes
{
    //LD STEP001 
    public class ProjectDbContext: DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
    }
}
