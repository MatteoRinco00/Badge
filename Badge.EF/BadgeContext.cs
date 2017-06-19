using Badge.EF.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Badge.EF
{
    public class BadgeContext: DbContext
    {
        private string _connectionString;
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Swipe> Swipe { get; set; }
        public DbSet<Entity.Badge> Badges { get; set; }

        public BadgeContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}


