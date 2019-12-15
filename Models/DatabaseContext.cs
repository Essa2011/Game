using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }
        public DbSet<Players> Players { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Games> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Players>().HasData(new Players
            {
                Id = 1,
                Name = "Essa",
                Age = 23,
                Height = 184,
                Weight = 80,
                Speed = 26,
                TeamsId = 1
            }, new Players
            {
                Id = 2,
                Name = "Ali",
                Age = 20,
                Height = 180,
                Weight = 75,
                Speed = 30,
                TeamsId = 2
            }, new Players
            {
                Id = 3,
                Name = "Mohammed",
                Age = 25,
                Height = 178,
                Weight = 85,
                Speed = 23,
                TeamsId = 1
            });
            
            modelBuilder.Entity<Teams>().HasData(new Teams
            {
                Id=1,
                Name = "Team 1",
                Location = "Riyadh"
            }, new Teams
            {
                Id = 2,
                Name = "Team 2",
                Location = "Dammam"
                
            });

            modelBuilder.Entity<Games>().HasData(new Games
            {
                Id = 1,
                teamA = 1,
                teamB = 2,
                startTime = DateTime.Now.AddDays(-1),
                endTime = DateTime.Now.AddHours(2),
                score = " 3 - 1",
                
            });
            
        }

       
    }
}
