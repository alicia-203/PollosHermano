using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PollosHermano.Models
{
    public partial class PollosHermanoContext : DbContext
    {
        public PollosHermanoContext()
        {
        }

        public PollosHermanoContext(DbContextOptions<PollosHermanoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ClientePlantilla> ClientePlantillas { get; set; }
        public virtual DbSet<Plantilla> Plantillas { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<RegionTipoNotificacion> RegionTipoNotificacions { get; set; }
        public virtual DbSet<TipoNotificacion> TipoNotificacions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HUFGIP3\\SQLEXPRESS; Database=PollosHermano; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientePlantilla>(entity =>
            {
                entity.ToTable("ClientePlantilla");

                entity.Property(e => e.ClientePlantillaId).HasColumnName("ClientePlantillaID");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.PlantillaId).HasColumnName("PlantillaID");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.ClientePlantillas)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientePlantilla_Cliente");

                entity.HasOne(d => d.Plantilla)
                    .WithMany(p => p.ClientePlantillas)
                    .HasForeignKey(d => d.PlantillaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientePlantilla_Plantilla");
            });

            modelBuilder.Entity<Plantilla>(entity =>
            {
                entity.ToTable("Plantilla");

                entity.Property(e => e.PlantillaId).HasColumnName("PlantillaID");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region");

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegionTipoNotificacion>(entity =>
            {
                entity.ToTable("RegionTipoNotificacion");

                entity.Property(e => e.RegionTipoNotificacionId)
                    .ValueGeneratedNever()
                    .HasColumnName("RegionTipoNotificacionID");

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.TipoNotificacionId).HasColumnName("TipoNotificacionID");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.RegionTipoNotificacions)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegionTipoNotificacion_Region");

                entity.HasOne(d => d.TipoNotificacion)
                    .WithMany(p => p.RegionTipoNotificacions)
                    .HasForeignKey(d => d.TipoNotificacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegionTipoNotificacion_TipoNotificacion");
            });

            modelBuilder.Entity<TipoNotificacion>(entity =>
            {
                entity.ToTable("TipoNotificacion");

                entity.Property(e => e.TipoNotificacionId).HasColumnName("TipoNotificacionID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
