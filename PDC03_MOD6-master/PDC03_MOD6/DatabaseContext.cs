using PDC03_MOD6.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
 
namespace PDC03_MOD6
{
    public class DatabaseContext : DbContext
    {
        public DbSet<EmployeeModel> Employees { get; set; }
        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }
        // overrides the OnConfigure Method 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Employee.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}