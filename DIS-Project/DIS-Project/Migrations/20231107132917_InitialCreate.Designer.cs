﻿// <auto-generated />
using System;
using DIS_Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DIS_Project.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231107132917_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DIS_Project.DataModels.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("DIS_Project.DataModels.CrashRecord", b =>
                {
                    b.Property<int>("CrashRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AdditionalInformation")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("CrashDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CrashLocation")
                        .HasColumnType("longtext");

                    b.Property<int?>("CrashYear")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Injuries")
                        .HasColumnType("longtext");

                    b.Property<int?>("RoadCharacterId")
                        .HasColumnType("int");

                    b.Property<int?>("RoadConditionId")
                        .HasColumnType("int");

                    b.Property<int?>("RoadConfigurationId")
                        .HasColumnType("int");

                    b.Property<int?>("TamainId")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("WeatherConditionId")
                        .HasColumnType("int");

                    b.HasKey("CrashRecordId");

                    b.HasIndex("RoadCharacterId");

                    b.HasIndex("RoadConditionId");

                    b.HasIndex("RoadConfigurationId");

                    b.HasIndex("VehicleTypeId");

                    b.HasIndex("WeatherConditionId");

                    b.ToTable("CrashRecord");
                });

            modelBuilder.Entity("DIS_Project.DataModels.RoadCharacter", b =>
                {
                    b.Property<int>("RoadCharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RoadCharacterId");

                    b.ToTable("RoadCharacter");

                    b.HasData(
                        new
                        {
                            RoadCharacterId = 1,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8145),
                            Description = "Straight",
                            Name = "Straight"
                        },
                        new
                        {
                            RoadCharacterId = 2,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8182),
                            Description = "Level",
                            Name = "Level"
                        },
                        new
                        {
                            RoadCharacterId = 3,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8184),
                            Description = "Curve",
                            Name = "Curve"
                        },
                        new
                        {
                            RoadCharacterId = 4,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8186),
                            Description = "HillCrest",
                            Name = "HillCrest"
                        },
                        new
                        {
                            RoadCharacterId = 5,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8188),
                            Description = "Other",
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("DIS_Project.DataModels.RoadCondition", b =>
                {
                    b.Property<int>("RoadConditionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RoadConditionId");

                    b.ToTable("RoadCondition");

                    b.HasData(
                        new
                        {
                            RoadConditionId = 1,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8229),
                            Description = "Dry",
                            Name = "Dry"
                        },
                        new
                        {
                            RoadConditionId = 2,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8234),
                            Description = "Wet",
                            Name = "Wet"
                        },
                        new
                        {
                            RoadConditionId = 3,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8236),
                            Description = "Ice",
                            Name = "Ice"
                        },
                        new
                        {
                            RoadConditionId = 4,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8238),
                            Description = "Snow",
                            Name = "Snow"
                        },
                        new
                        {
                            RoadConditionId = 5,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8240),
                            Description = "UnKnown",
                            Name = "UnKnown"
                        });
                });

            modelBuilder.Entity("DIS_Project.DataModels.RoadConfiguration", b =>
                {
                    b.Property<int>("RoadConfigurationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RoadConfigurationId");

                    b.ToTable("RoadConfiguration");

                    b.HasData(
                        new
                        {
                            RoadConfigurationId = 1,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8265),
                            Description = "Two-Way",
                            Name = "Two-Way"
                        },
                        new
                        {
                            RoadConfigurationId = 2,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8270),
                            Description = "Not Divided",
                            Name = "Not Divided"
                        },
                        new
                        {
                            RoadConfigurationId = 3,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8273),
                            Description = "Divided",
                            Name = "Divided"
                        },
                        new
                        {
                            RoadConfigurationId = 4,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8275),
                            Description = "Other",
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("DIS_Project.DataModels.VehicleType", b =>
                {
                    b.Property<int>("VehicleTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("VehicleTypeId");

                    b.ToTable("VehicleType");

                    b.HasData(
                        new
                        {
                            VehicleTypeId = 1,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8296),
                            Description = "Passenger",
                            Name = "Passenger"
                        },
                        new
                        {
                            VehicleTypeId = 2,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8300),
                            Description = "Sport",
                            Name = "Sport"
                        },
                        new
                        {
                            VehicleTypeId = 3,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8301),
                            Description = "PickUp",
                            Name = "PickUp"
                        },
                        new
                        {
                            VehicleTypeId = 4,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8304),
                            Description = "Van",
                            Name = "Van"
                        },
                        new
                        {
                            VehicleTypeId = 5,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8306),
                            Description = "Unknown",
                            Name = "Unknown"
                        });
                });

            modelBuilder.Entity("DIS_Project.DataModels.WeatherCondition", b =>
                {
                    b.Property<int>("WeatherConditionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("WeatherConditionId");

                    b.ToTable("WeatherCondition");

                    b.HasData(
                        new
                        {
                            WeatherConditionId = 1,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8325),
                            Description = "Clear",
                            Name = "Clear"
                        },
                        new
                        {
                            WeatherConditionId = 2,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8330),
                            Description = "Cloudy",
                            Name = "Cloudy"
                        },
                        new
                        {
                            WeatherConditionId = 3,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8332),
                            Description = "Rain",
                            Name = "Rain"
                        },
                        new
                        {
                            WeatherConditionId = 4,
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8335),
                            Description = "Other",
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("DIS_Project.DataModels.CrashRecord", b =>
                {
                    b.HasOne("DIS_Project.DataModels.RoadCharacter", "RoadCharacter")
                        .WithMany()
                        .HasForeignKey("RoadCharacterId");

                    b.HasOne("DIS_Project.DataModels.RoadCondition", "RoadCondition")
                        .WithMany()
                        .HasForeignKey("RoadConditionId");

                    b.HasOne("DIS_Project.DataModels.RoadConfiguration", "RoadConfiguration")
                        .WithMany()
                        .HasForeignKey("RoadConfigurationId");

                    b.HasOne("DIS_Project.DataModels.VehicleType", "VehicleType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeId");

                    b.HasOne("DIS_Project.DataModels.WeatherCondition", "WeatherCondition")
                        .WithMany()
                        .HasForeignKey("WeatherConditionId");

                    b.Navigation("RoadCharacter");

                    b.Navigation("RoadCondition");

                    b.Navigation("RoadConfiguration");

                    b.Navigation("VehicleType");

                    b.Navigation("WeatherCondition");
                });
#pragma warning restore 612, 618
        }
    }
}
