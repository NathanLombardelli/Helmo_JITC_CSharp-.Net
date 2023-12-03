﻿// <auto-generated />
using System;
using JITC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JITC.Migrations
{
    [DbContext(typeof(JITCDbContext))]
    [Migration("20220807193327_volNONRecurent")]
    partial class volNONRecurent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JITC.Models.Aeroport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Aeroports", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Latitude = "50.64318",
                            Longitude = "5.46083",
                            Name = "Liège"
                        },
                        new
                        {
                            Id = 2,
                            Latitude = "50.46434",
                            Longitude = "4.45966",
                            Name = "Charleroi"
                        },
                        new
                        {
                            Id = 3,
                            Latitude = "50.90114",
                            Longitude = "4.48539",
                            Name = "Bruxelles"
                        },
                        new
                        {
                            Id = 4,
                            Latitude = "51.20467",
                            Longitude = "2.86983",
                            Name = "Oostende"
                        });
                });

            modelBuilder.Entity("JITC.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MessageAccueil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("JITC.Models.Helicopter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Motor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NbrVol")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<string>("Statut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Helicopter", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 5,
                            Motor = "deux turbines du modèle de Rolls Royce 250-C20F",
                            Name = "Eurocopter AS 355 F1/F2 Ecureuil III",
                            NbrVol = 1,
                            Speed = 220,
                            Statut = "ok"
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 4,
                            Motor = "une turbine du type Rolls Royce 250-C20B",
                            Name = "Bell 206 JetRanger",
                            NbrVol = 1,
                            Speed = 190,
                            Statut = "ok"
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 3,
                            Motor = "un piston du type Lycoming modèle IO-540",
                            Name = "Robinson R44 Raven II",
                            NbrVol = 0,
                            Speed = 190,
                            Statut = "ok"
                        });
                });

            modelBuilder.Entity("JITC.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Modification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VolId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("JITC.Models.Pilote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Pilote", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "D.Balav@jitc.com",
                            Name = "Balav",
                            Surname = "Danièle"
                        },
                        new
                        {
                            Id = 2,
                            Email = "T.Sabine@jitc.com",
                            Name = "Sabine",
                            Surname = "Thierry"
                        },
                        new
                        {
                            Id = 3,
                            Email = "E.Coptère@jitc.com",
                            Name = "Coptère",
                            Surname = "Eli"
                        });
                });

            modelBuilder.Entity("JITC.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("NbrPlaces")
                        .HasColumnType("int");

                    b.Property<int>("VolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VolId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("JITC.Models.Vol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AeroportArriverId")
                        .HasColumnType("int");

                    b.Property<int>("AeroportDepartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArriverFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ArriverPrevu")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartPrevu")
                        .HasColumnType("datetime2");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<int>("HelicopterId")
                        .HasColumnType("int");

                    b.Property<int>("PiloteId")
                        .HasColumnType("int");

                    b.Property<string>("RaisonRetard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HelicopterId");

                    b.HasIndex("PiloteId");

                    b.ToTable("Vols", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AeroportArriverId = 1,
                            AeroportDepartId = 2,
                            ArriverFinal = new DateTime(2022, 5, 9, 11, 30, 0, 0, DateTimeKind.Unspecified),
                            ArriverPrevu = new DateTime(2022, 5, 9, 11, 30, 0, 0, DateTimeKind.Unspecified),
                            DepartFinal = new DateTime(2022, 5, 9, 10, 30, 0, 0, DateTimeKind.Unspecified),
                            DepartPrevu = new DateTime(2022, 5, 9, 10, 30, 0, 0, DateTimeKind.Unspecified),
                            Distance = 0.0,
                            HelicopterId = 1,
                            PiloteId = 1,
                            RaisonRetard = ""
                        },
                        new
                        {
                            Id = 2,
                            AeroportArriverId = 3,
                            AeroportDepartId = 4,
                            ArriverFinal = new DateTime(2022, 8, 1, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            ArriverPrevu = new DateTime(2022, 8, 1, 16, 30, 0, 0, DateTimeKind.Unspecified),
                            DepartFinal = new DateTime(2022, 8, 1, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            DepartPrevu = new DateTime(2022, 8, 1, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            Distance = 0.0,
                            HelicopterId = 2,
                            PiloteId = 2,
                            RaisonRetard = "détour car tempête"
                        },
                        new
                        {
                            Id = 3,
                            AeroportArriverId = 1,
                            AeroportDepartId = 3,
                            ArriverFinal = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ArriverPrevu = new DateTime(2022, 9, 7, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            DepartFinal = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartPrevu = new DateTime(2022, 9, 7, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Distance = 0.0,
                            HelicopterId = 3,
                            PiloteId = 3,
                            RaisonRetard = ""
                        },
                        new
                        {
                            Id = 4,
                            AeroportArriverId = 2,
                            AeroportDepartId = 4,
                            ArriverFinal = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ArriverPrevu = new DateTime(2022, 9, 21, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            DepartFinal = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartPrevu = new DateTime(2022, 9, 21, 9, 30, 0, 0, DateTimeKind.Unspecified),
                            Distance = 0.0,
                            HelicopterId = 1,
                            PiloteId = 2,
                            RaisonRetard = ""
                        },
                        new
                        {
                            Id = 5,
                            AeroportArriverId = 1,
                            AeroportDepartId = 2,
                            ArriverFinal = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ArriverPrevu = new DateTime(2022, 10, 5, 16, 30, 0, 0, DateTimeKind.Unspecified),
                            DepartFinal = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartPrevu = new DateTime(2022, 10, 5, 12, 30, 0, 0, DateTimeKind.Unspecified),
                            Distance = 0.0,
                            HelicopterId = 2,
                            PiloteId = 1,
                            RaisonRetard = ""
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "23d6e9d7-8036-43f0-9cc6-19385cb02866",
                            ConcurrencyStamp = "928a82f0-99ce-4b12-8d1f-0fb01701dbd8",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "83ccc92a-72ba-45e8-af2f-03400704e6d2",
                            ConcurrencyStamp = "e6138e1d-dcbf-433b-94d9-d4ec5e89d171",
                            Name = "Pilote",
                            NormalizedName = "PILOTE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "727df886-7a0c-4054-b16f-5ab4cb8ee996",
                            RoleId = "23d6e9d7-8036-43f0-9cc6-19385cb02866"
                        },
                        new
                        {
                            UserId = "455d681b-784e-4f5f-9183-92cf2b177ba1",
                            RoleId = "83ccc92a-72ba-45e8-af2f-03400704e6d2"
                        },
                        new
                        {
                            UserId = "8b0fd074-380b-42ca-8d93-fe8667880e82",
                            RoleId = "83ccc92a-72ba-45e8-af2f-03400704e6d2"
                        },
                        new
                        {
                            UserId = "b2346ce4-0260-488e-87ab-80596abfcc53",
                            RoleId = "83ccc92a-72ba-45e8-af2f-03400704e6d2"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("JITC.Models.Log", b =>
                {
                    b.HasOne("JITC.Models.Vol", "Vol")
                        .WithMany()
                        .HasForeignKey("VolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vol");
                });

            modelBuilder.Entity("JITC.Models.Reservation", b =>
                {
                    b.HasOne("JITC.Models.Vol", "Vol")
                        .WithMany()
                        .HasForeignKey("VolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vol");
                });

            modelBuilder.Entity("JITC.Models.Vol", b =>
                {
                    b.HasOne("JITC.Models.Helicopter", "Helicopter")
                        .WithMany()
                        .HasForeignKey("HelicopterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JITC.Models.Pilote", "Pilote")
                        .WithMany()
                        .HasForeignKey("PiloteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Helicopter");

                    b.Navigation("Pilote");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("JITC.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("JITC.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JITC.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("JITC.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
