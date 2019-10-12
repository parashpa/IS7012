using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Models
{
    public class FinalProjectContext : DbContext
    {
        public FinalProjectContext (DbContextOptions<FinalProjectContext> options)
            : base(options)
        {
        }

        public DbSet<FinalProject.Models.Membership> Membership { get; set; }

        public DbSet<FinalProject.Models.Plan> Plan { get; set; }

        public DbSet<FinalProject.Models.Trainer> Trainer { get; set; }

        public DbSet<FinalProject.Models.TuckShop> TuckShop { get; set; }
        public object ChangePlanForm { get; internal set; }
    }
}
