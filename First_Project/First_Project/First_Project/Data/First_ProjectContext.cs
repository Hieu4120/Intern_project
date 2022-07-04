using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using graduate_project.Models;
using First_Project.Models;

namespace First_Project.Data
{
    public class First_ProjectContext : DbContext
    {
        public First_ProjectContext (DbContextOptions<First_ProjectContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder
                optionBuilder)
        {
            optionBuilder.UseOracle(@"User Id=hieu;Password=hieu;Data Source=localhost:1521/Project");
        }

        public DbSet<graduate_project.Models.ES_YDENPYO1>? ES_YDENPYO { get; set; }

        public DbSet<First_Project.Models.BUMON>? BUMON { get; set; }

        public DbSet<First_Project.Models.ES_YDENPYOD>? ES_YDENPYOD { get; set; }

       
    }
}
