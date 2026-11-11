using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace demoOlimpiada_12_11_26.Models
{
    public partial class TarifDB : DbContext
    {
        public TarifDB()
            : base("name=TarifDB1")
        {
        }

        public virtual DbSet<contracts> contracts { get; set; }
        public virtual DbSet<gb_services> gb_services { get; set; }
        public virtual DbSet<min_services> min_services { get; set; }
        public virtual DbSet<sms_services> sms_services { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tarif> tarif { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<contracts>()
                .Property(e => e.total_cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<gb_services>()
                .Property(e => e.add_gb_cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<gb_services>()
                .HasMany(e => e.tarif)
                .WithRequired(e => e.gb_services)
                .HasForeignKey(e => e.gb_service_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<min_services>()
                .Property(e => e.add_min_cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<min_services>()
                .HasMany(e => e.tarif)
                .WithRequired(e => e.min_services)
                .HasForeignKey(e => e.min_service_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sms_services>()
                .Property(e => e.add_sms_cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<sms_services>()
                .HasMany(e => e.tarif)
                .WithRequired(e => e.sms_services)
                .HasForeignKey(e => e.sms_service_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tarif>()
                .Property(e => e.cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tarif>()
                .HasMany(e => e.contracts)
                .WithRequired(e => e.tarif)
                .HasForeignKey(e => e.tarif_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<users>()
                .HasMany(e => e.contracts)
                .WithRequired(e => e.users)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);
        }
    }
}
