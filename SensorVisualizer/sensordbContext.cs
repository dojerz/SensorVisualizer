using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SensorVisualizer
{
    public partial class sensordbContext : DbContext
    {
        public sensordbContext()
        {
        }

        public sensordbContext(DbContextOptions<sensordbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Humidity> Humidity { get; set; }
        public virtual DbSet<Sensordata> Sensordata { get; set; }
        public virtual DbSet<Temperature> Temperature { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseNpgsql("Host=192.168.1.74;Database=sensordb;Username=pi;Password=raspberry");
                optionsBuilder.UseNpgsql("Host=192.168.0.15;Database=sensordb;Username=pi;Password=raspberry");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Humidity>(entity =>
            {
                entity.ToTable("humidity");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ResultTime).HasColumnName("result_time");

                entity.Property(e => e.Sensorid).HasColumnName("sensorid");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Sensordata>(entity =>
            {
                entity.ToTable("sensordata");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Humidityvalue).HasColumnName("humidityvalue");

                entity.Property(e => e.ResultTime).HasColumnName("result_time");

                entity.Property(e => e.Sensorid).HasColumnName("sensorid");

                entity.Property(e => e.Temperaturevalue).HasColumnName("temperaturevalue");
            });

            modelBuilder.Entity<Temperature>(entity =>
            {
                entity.ToTable("temperature");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ResultTime).HasColumnName("result_time");

                entity.Property(e => e.Sensorid).HasColumnName("sensorid");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.HasSequence("sensordata_id_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
