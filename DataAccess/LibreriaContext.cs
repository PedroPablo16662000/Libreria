using Microsoft.EntityFrameworkCore;
using Models.Entities;

#nullable disable

namespace DataAccess
{
    public partial class LibreriaContext : DbContext
    {
        public LibreriaContext()
        {
        }

        public LibreriaContext(DbContextOptions<LibreriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autore> Autores { get; set; }
        public virtual DbSet<AutoresHasLibro> AutoresHasLibros { get; set; }
        public virtual DbSet<Editoriale> Editoriales { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=Libreria;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Autore>(entity =>
            {
                entity.ToTable("autores");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<AutoresHasLibro>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("autores_has_libros");

                entity.Property(e => e.AutoresId).HasColumnName("autores_id");

                entity.Property(e => e.LibrosIsbn).HasColumnName("libros_ISBN");

                entity.HasOne(d => d.Autores)
                    .WithMany()
                    .HasForeignKey(d => d.AutoresId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__autores_h__autor__2A4B4B5E");

                entity.HasOne(d => d.LibrosIsbnNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.LibrosIsbn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__autores_h__libro__2B3F6F97");
            });

            modelBuilder.Entity<Editoriale>(entity =>
            {
                entity.ToTable("editoriales");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Sede)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("sede");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.Isbn)
                    .HasName("PK__libros__447D36EB99A0B14E");

                entity.ToTable("libros");

                entity.Property(e => e.Isbn).HasColumnName("ISBN");

                entity.Property(e => e.EditorialesId).HasColumnName("editoriales_id");

                entity.Property(e => e.NPaginas)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("n_paginas");

                entity.Property(e => e.Sinopsis)
                    .HasColumnType("text")
                    .HasColumnName("sinopsis");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.Editoriales)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.EditorialesId)
                    .HasConstraintName("FK__libros__editoria__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
