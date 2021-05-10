using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HRoads_WebApi.Domains;

#nullable disable

namespace HRoads_WebApi.Contexts
{
    public partial class HRoadsContext : DbContext
    {
        public HRoadsContext()
        {
        }

        public HRoadsContext(DbContextOptions<HRoadsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassesHabilidade> ClassesHabilidades { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Personagem> Personagens { get; set; }
        public virtual DbSet<TiposHabilidade> TiposHabilidades { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public object TipoUsuarios { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-II7UP0KL; Initial Catalog=Senai_Hroads_Tarde; user Id=sa; pwd=Senai@132;");
#pragma warning restore CS1030 // diretiva de #aviso
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.IdClasses)
                    .HasName("PK__Classes__57010672DB5D569E");

                entity.Property(e => e.IdClasses).HasColumnName("idClasses");

                entity.Property(e => e.NomeClasse)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClassesHabilidade>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IdClasses).HasColumnName("idClasses");

                entity.Property(e => e.IdHabilidades).HasColumnName("idHabilidades");

                entity.HasOne(d => d.IdClassesNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdClasses)
                    .HasConstraintName("FK__ClassesHa__idCla__41EDCAC5");

                entity.HasOne(d => d.IdHabilidadesNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdHabilidades)
                    .HasConstraintName("FK__ClassesHa__idHab__42E1EEFE");
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PK__Habilida__655F7528F7EBD1E9");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.Property(e => e.IdTiposHabilidades).HasColumnName("idTiposHabilidades");

                entity.Property(e => e.NomeHabilidade)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTiposHabilidadesNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdTiposHabilidades)
                    .HasConstraintName("FK__Habilidad__idTip__40058253");
            });

            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.HasKey(e => e.IdPersonagem)
                    .HasName("PK__Personag__E175C72E7FB1CE78");

                entity.Property(e => e.IdPersonagem).HasColumnName("idPersonagem");

                entity.Property(e => e.DataAt)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DataCr)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.Personagens)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__Personage__idCla__45BE5BA9");
            });

            modelBuilder.Entity<TiposHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdTiposHabilidades)
                    .HasName("PK__TiposHab__B078A3720B729BB0");

                entity.Property(e => e.IdTiposHabilidades).HasColumnName("idTiposHabilidades");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTiposusuarios)
                    .HasName("PK__TiposUsu__100CED030333E961");

                entity.Property(e => e.IdTiposusuarios).HasColumnName("idTiposusuarios");

                entity.Property(e => e.Titulo)
                    .HasColumnType("text")
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__645723A603E8A56E");

                entity.HasIndex(e => e.Email, "UQ__Usuarios__AB6E6164E72E824F")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTiposUsuarios).HasColumnName("idTiposUsuarios");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTiposUsuariosNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTiposUsuarios)
                    .HasConstraintName("FK__Usuarios__idTipo__6EC0713C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
