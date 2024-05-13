using CobblerWorkshop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CobblerWorkshop.DbProviders
{
    public class SqliteDbContext : DbContext
    {
        private static string _connectionString => "data source=C:\\Users\\lukko\\Documents\\Projekty\\CobblerWorkshop\\Database\\SQLiteDB.db";

        public DbSet<RepairTask> RepairTasks { get; set; }
        public DbSet<RepairTaskPosition> RepairTaskPositions { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
