﻿// <auto-generated />
using System;
using CodeFirst;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodeFirst.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240317180947_image_for_animal")]
    partial class image_for_animal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Repository.Entities.Animal", b =>
                {
                    b.Property<int>("animalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("animalId"), 1L, 1);

                    b.Property<int>("CageID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("animalId");

                    b.HasIndex("CageID");

                    b.ToTable("animals");
                });

            modelBuilder.Entity("Repository.Entities.Cage", b =>
                {
                    b.Property<int>("CageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CageID"), 1L, 1);

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.Property<int>("ZooId")
                        .HasColumnType("int");

                    b.HasKey("CageID");

                    b.HasIndex("ZooId");

                    b.ToTable("Cages");
                });

            modelBuilder.Entity("Repository.Entities.FeedingSchedule", b =>
                {
                    b.Property<int>("ScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleID"), 1L, 1);

                    b.Property<int?>("AnimalanimalId")
                        .HasColumnType("int");

                    b.Property<int>("CageID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FeedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ScheduleID");

                    b.HasIndex("AnimalanimalId");

                    b.HasIndex("CageID");

                    b.ToTable("FeedingSchedules");
                });

            modelBuilder.Entity("Repository.Entities.Kiosk", b =>
                {
                    b.Property<int>("KioskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KioskID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZooID")
                        .HasColumnType("int");

                    b.HasKey("KioskID");

                    b.HasIndex("ZooID");

                    b.ToTable("kiosks");
                });

            modelBuilder.Entity("Repository.Entities.Ticket", b =>
                {
                    b.Property<int>("TicketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketID"), 1L, 1);

                    b.Property<int>("ZooID")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.HasKey("TicketID");

                    b.HasIndex("ZooID");

                    b.ToTable("tickets");
                });

            modelBuilder.Entity("Repository.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Repository.Entities.Zoo", b =>
                {
                    b.Property<int>("ZooID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ZooID"), 1L, 1);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZooID");

                    b.ToTable("zoos");
                });

            modelBuilder.Entity("Repository.Entities.Animal", b =>
                {
                    b.HasOne("Repository.Entities.Cage", "Cage")
                        .WithMany()
                        .HasForeignKey("CageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cage");
                });

            modelBuilder.Entity("Repository.Entities.Cage", b =>
                {
                    b.HasOne("Repository.Entities.Zoo", null)
                        .WithMany("Cages")
                        .HasForeignKey("ZooId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Repository.Entities.FeedingSchedule", b =>
                {
                    b.HasOne("Repository.Entities.Animal", null)
                        .WithMany("FeedingSchedules")
                        .HasForeignKey("AnimalanimalId");

                    b.HasOne("Repository.Entities.Cage", "Cage")
                        .WithMany()
                        .HasForeignKey("CageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cage");
                });

            modelBuilder.Entity("Repository.Entities.Kiosk", b =>
                {
                    b.HasOne("Repository.Entities.Zoo", "Zoo")
                        .WithMany()
                        .HasForeignKey("ZooID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zoo");
                });

            modelBuilder.Entity("Repository.Entities.Ticket", b =>
                {
                    b.HasOne("Repository.Entities.Zoo", "Zoo")
                        .WithMany()
                        .HasForeignKey("ZooID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zoo");
                });

            modelBuilder.Entity("Repository.Entities.Animal", b =>
                {
                    b.Navigation("FeedingSchedules");
                });

            modelBuilder.Entity("Repository.Entities.Zoo", b =>
                {
                    b.Navigation("Cages");
                });
#pragma warning restore 612, 618
        }
    }
}
