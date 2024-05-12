﻿// <auto-generated />
using System;
using CobblerWorkshop.DbProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CobblerWorkshop.Migrations
{
    [DbContext(typeof(SqliteDbContext))]
    partial class SqliteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("CobblerWorkshop.Models.Client", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("CobblerWorkshop.Models.RepairTask", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("RepairTasks");
                });

            modelBuilder.Entity("CobblerWorkshop.Models.RepairTaskPosition", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("No")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NumberOfShoes")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RepairTaskId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TaskPositionTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RepairTaskId");

                    b.HasIndex("TaskPositionTypeId");

                    b.ToTable("RepairTaskPositions");
                });

            modelBuilder.Entity("CobblerWorkshop.Models.TaskPositionType", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("SuggestPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("TaskPositionTypes");
                });

            modelBuilder.Entity("CobblerWorkshop.Models.RepairTask", b =>
                {
                    b.HasOne("CobblerWorkshop.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("CobblerWorkshop.Models.RepairTaskPosition", b =>
                {
                    b.HasOne("CobblerWorkshop.Models.RepairTask", null)
                        .WithMany("Positions")
                        .HasForeignKey("RepairTaskId");

                    b.HasOne("CobblerWorkshop.Models.TaskPositionType", "TaskPositionType")
                        .WithMany()
                        .HasForeignKey("TaskPositionTypeId");

                    b.Navigation("TaskPositionType");
                });

            modelBuilder.Entity("CobblerWorkshop.Models.RepairTask", b =>
                {
                    b.Navigation("Positions");
                });
#pragma warning restore 612, 618
        }
    }
}
