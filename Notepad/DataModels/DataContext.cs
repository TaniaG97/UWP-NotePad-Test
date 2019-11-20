using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.DataModels
{
    class DataContext : DbContext
    {
        public DbSet<CategoryDataModel> Categories { get; set; }
        public DbSet<ContentItemDataModel> Items { get; set; }

        public DataContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Notepad.db");
        }
    }
}
