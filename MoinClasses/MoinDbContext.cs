using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Entity;
using MySql.Data.Entity;
using MoinClasses.Tables;

namespace MoinClasses
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MoinDbContext : DbContext, IDisposable
    {

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UsersInRoles> UsersInRoles { get; set; }
        public DbSet<PermissionsInRoles> PermissionsInRoles { get; set; }

        public MoinDbContext()
            : base()
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

            modelBuilder.Entity<Roles>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Roles");
            });

            modelBuilder.Entity<Permissions>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Permissions");
            });

            modelBuilder.Entity<UsersInRoles>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("UsersInRoles");
            });

            modelBuilder.Entity<PermissionsInRoles>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("PermissionsInRoles");
            });

        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
