using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Ficticia_Bitsion.Models
{
    public partial class FicticiaSAContext : DbContext
    {
        public FicticiaSAContext()
        {
        }

        public FicticiaSAContext(DbContextOptions<FicticiaSAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-K65QDHU\\SQLEXPRESS;Database=Ficticia S.A.;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.CliId);

                entity.Property(e => e.CliId).HasColumnName("cli_Id");

                entity.Property(e => e.CliActive).HasColumnName("cli_Active");

                entity.Property(e => e.CliDiabetic).HasColumnName("cli_Diabetic");

                entity.Property(e => e.CliDiseases).HasColumnName("cli_Diseases");

                entity.Property(e => e.CliDni).HasColumnName("cli_Dni");

                entity.Property(e => e.CliDocDocumentType).HasColumnName("cli_doc_DocumentType");

                entity.Property(e => e.CliDrive).HasColumnName("cli_Drive");

                entity.Property(e => e.CliGenGender).HasColumnName("cli_gen_Gender");

                entity.Property(e => e.CliName).HasColumnName("cli_Name");

                entity.Property(e => e.CliOtherDiseases).HasColumnName("cli_OtherDiseases");

                entity.Property(e => e.CliUseGlasses).HasColumnName("cli_UseGlasses");

                entity.HasOne(d => d.CliDocDocumentTypeNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.CliDocDocumentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clients_DocumentTypes");

                entity.HasOne(d => d.CliGenGenderNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.CliGenGender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clients_Genders");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.Property(e => e.DocId).HasColumnName("doc_Id");

                entity.Property(e => e.DocDocument).HasColumnName("doc_Document");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.GenId);

                entity.Property(e => e.GenId).HasColumnName("gen_Id");

                entity.Property(e => e.GenGender).HasColumnName("gen_Gender");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsrId);

                entity.ToTable("User");

                entity.Property(e => e.UsrId).HasColumnName("usr_Id");

                entity.Property(e => e.UsrEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usr_Email");

                entity.Property(e => e.UsrNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usr_Nombre");

                entity.Property(e => e.UsrPassword)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("usr_Password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
