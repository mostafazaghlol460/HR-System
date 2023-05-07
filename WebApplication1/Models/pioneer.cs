using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication1.Models
{
    public partial class pioneer : DbContext
    {
        public pioneer()
            : base("name=pioneer")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<employee> employee { get; set; }
        public virtual DbSet<general_setting> general_setting { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<HR> HR { get; set; }
        public virtual DbSet<page> pages { get; set; }
        public virtual DbSet<report_employee> report_employee { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<vacation> vacation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.full_name)
                .IsFixedLength();

            modelBuilder.Entity<Admin>()
                .Property(e => e.user_name)
                .IsFixedLength();

            modelBuilder.Entity<Admin>()
                .Property(e => e.email)
                .IsFixedLength();

            modelBuilder.Entity<Admin>()
                .Property(e => e.password)
                .IsFixedLength();

            modelBuilder.Entity<employee>()
                .HasMany(e => e.report_employee)
                .WithRequired(e => e.employee)
                .HasForeignKey(e => e.id_emp)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<general_setting>()
                .HasMany(e => e.report_employee)
                .WithRequired(e => e.general_setting)
                .HasForeignKey(e => e.id_general)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .Property(e => e.name_group)
                .IsFixedLength();

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Admins)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HR>()
                .Property(e => e.user_name)
                .IsFixedLength();

            modelBuilder.Entity<HR>()
                .Property(e => e.password)
                .IsFixedLength();

            modelBuilder.Entity<HR>()
                .HasMany(e => e.Group)
                .WithRequired(e => e.HR)
                .WillCascadeOnDelete(false);
        }
    }
}
