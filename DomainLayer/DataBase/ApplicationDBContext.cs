using Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.DataBase
{
    public partial class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options)
        {
            
        }

        //..mens team ranking....
        public virtual DbSet<TeamStatus> MensTestRank { get; set; }
        public virtual DbSet<TeamStatus> MensOdiRank { get; set; }
        public virtual DbSet<TeamStatus> MensT20Rank { get; set; }

        //..womens team ranking......
        public virtual DbSet<TeamStatus> WomensOdiRank { get; set; }
        public DbSet<TeamStatus> WomensT20Rank { get; set; }

        //..mens test players....
        public virtual DbSet<player> MenTestBatters { get; set; }
        public virtual DbSet<player> MenTestBowlers { get; set; }
        public virtual DbSet<player> MenTestAllrounder { get; set; }

        //..mens odi players...
        public virtual DbSet<player> MenOdiBatters { get; set; }
        public virtual DbSet<player> MenOdiBowlers { get; set; }
        public virtual DbSet<player> MenOdiAllrounder { get; set; }
       
        //..mens t20 players....
        public virtual DbSet<player> MenT20Batters { get; set; }
        public virtual DbSet<player> Ment20Bowlers { get; set; }
        public virtual DbSet<player> Ment20Allrounder { get; set; }

        //..womens odi players...
        public virtual DbSet<player> WomenOdiBatters { get; set; }
        public virtual DbSet<player> WomenOdiBowlers { get; set; }
        public virtual DbSet<player> WomenOdiAllrounder { get; set; }

        //..womens t20 players....
        public virtual DbSet<player> WomenT20Batters { get; set; }
        public virtual DbSet<player> Woment20Bowlers { get; set; }
        public virtual DbSet<player> Woment20Allrounder { get; set; }

   
    } 
}
