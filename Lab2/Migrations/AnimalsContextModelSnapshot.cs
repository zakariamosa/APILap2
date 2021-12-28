﻿// <auto-generated />
using System;
using Lab2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab2.Migrations
{
    [DbContext(typeof(AnimalsContext))]
    partial class AnimalsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Lab2.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnimalTypeId")
                        .HasColumnType("int")
                        .HasColumnName("AnimalTypeID");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnimalTypeId");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnimalTypeId = 1,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(2021, 12, 28, 20, 33, 52, 499, DateTimeKind.Local).AddTicks(9381),
                            Name = "Animal1"
                        },
                        new
                        {
                            Id = 2,
                            AnimalTypeId = 1,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(2021, 12, 28, 20, 33, 52, 499, DateTimeKind.Local).AddTicks(9430),
                            Name = "Animal2"
                        },
                        new
                        {
                            Id = 3,
                            AnimalTypeId = 1,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(2021, 12, 28, 20, 33, 52, 499, DateTimeKind.Local).AddTicks(9433),
                            Name = "Animal3"
                        },
                        new
                        {
                            Id = 4,
                            AnimalTypeId = 2,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(2021, 12, 28, 20, 33, 52, 499, DateTimeKind.Local).AddTicks(9435),
                            Name = "Animal4"
                        },
                        new
                        {
                            Id = 5,
                            AnimalTypeId = 2,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(2021, 12, 28, 20, 33, 52, 499, DateTimeKind.Local).AddTicks(9437),
                            Name = "Animal5"
                        },
                        new
                        {
                            Id = 6,
                            AnimalTypeId = 2,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(2021, 12, 28, 20, 33, 52, 499, DateTimeKind.Local).AddTicks(9439),
                            Name = "Animal6"
                        });
                });

            modelBuilder.Entity("Lab2.Models.AnimalType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfLegs")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AnimalTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "dog",
                            NumberOfLegs = 4
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "bird",
                            NumberOfLegs = 2
                        });
                });

            modelBuilder.Entity("Lab2.Models.Animal", b =>
                {
                    b.HasOne("Lab2.Models.AnimalType", "AnimalType")
                        .WithMany("Animals")
                        .HasForeignKey("AnimalTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_Animals_AnimalTypes");

                    b.Navigation("AnimalType");
                });

            modelBuilder.Entity("Lab2.Models.AnimalType", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}
