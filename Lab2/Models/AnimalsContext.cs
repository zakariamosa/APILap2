using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lab2.Models
{
    public partial class AnimalsContext : DbContext
    {
        public AnimalsContext()
        {
        }

        public AnimalsContext(DbContextOptions<AnimalsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; } = null!;
        public virtual DbSet<AnimalType> AnimalTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-31D93O8\\SQLEXPRESS;Database=Animals;user=sa;pwd=123;integrated security=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AnimalTypeId).HasColumnName("AnimalTypeID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.HasOne(d => d.AnimalType)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.AnimalTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animals_AnimalTypes");
            });

            modelBuilder.Entity<AnimalType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

           

            OnModelCreatingPartial(modelBuilder);
           
            modelBuilder.Entity<AnimalType>().HasData(
               new AnimalType { Id = 1, Name = "dog", NumberOfLegs = 4 },
               new AnimalType { Id = 2, Name = "bird", NumberOfLegs = 2 }
               );
            modelBuilder.Entity<Animal>().HasData(
                new Animal { AnimalTypeId = 1, DateOfBirth = DateTime.Now, Id = 1, Name = "Animal1" },
                new Animal { AnimalTypeId = 1, DateOfBirth = DateTime.Now, Id = 2, Name = "Animal2" },
                new Animal { AnimalTypeId = 1, DateOfBirth = DateTime.Now, Id = 3, Name = "Animal3" },
                new Animal { AnimalTypeId = 2, DateOfBirth = DateTime.Now, Id = 4, Name = "Animal4" },
                new Animal { AnimalTypeId = 2, DateOfBirth = DateTime.Now, Id = 5, Name = "Animal5" },
                new Animal { AnimalTypeId = 2, DateOfBirth = DateTime.Now, Id = 6, Name = "Animal6" }

                );
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
