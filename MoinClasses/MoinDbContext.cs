using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Entity;
using MySql.Data.Entity;

namespace MoinClasses
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MoinDbContext : DbContext
    {
        
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Users> Users { get; set; }

        public MoinDbContext() : base()
        {
        }

        // Constructor to use on a DbConnection that is already opened
        public MoinDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customers>().Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("Customers");
                });

            modelBuilder.Entity<Users>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Users");
            });
        }
    }
}
