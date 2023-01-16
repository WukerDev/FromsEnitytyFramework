using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp14
{
    internal class obsluga : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Miasta> Miasta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = kotlarz.db");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
