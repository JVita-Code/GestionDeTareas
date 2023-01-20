﻿// <auto-generated />
using System;
using GestionDeTareas.API.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionDeTareas.API.Migrations
{
    [DbContext(typeof(GestorContext))]
    [Migration("20230119211639_inicial")]
    partial class inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionDeTareas.API.Entities.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CompletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Activities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 7,
                            Description = "Descripcion de la actividad Número 1",
                            IsCompleted = false,
                            IsDeleted = false,
                            ModifiedAt = new DateTime(2023, 1, 19, 18, 16, 39, 394, DateTimeKind.Local).AddTicks(5000),
                            Title = "Actividad  1"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "Descripcion de la actividad Número 2",
                            IsCompleted = false,
                            IsDeleted = false,
                            ModifiedAt = new DateTime(2023, 1, 19, 18, 16, 39, 394, DateTimeKind.Local).AddTicks(5009),
                            Title = "Actividad  2"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 5,
                            Description = "Descripcion de la actividad Número 3",
                            IsCompleted = false,
                            IsDeleted = false,
                            ModifiedAt = new DateTime(2023, 1, 19, 18, 16, 39, 394, DateTimeKind.Local).AddTicks(5011),
                            Title = "Actividad  3"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 9,
                            Description = "Descripcion de la actividad Número 4",
                            IsCompleted = false,
                            IsDeleted = false,
                            ModifiedAt = new DateTime(2023, 1, 19, 18, 16, 39, 394, DateTimeKind.Local).AddTicks(5014),
                            Title = "Actividad  4"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 8,
                            Description = "Descripcion de la actividad Número 5",
                            IsCompleted = false,
                            IsDeleted = false,
                            ModifiedAt = new DateTime(2023, 1, 19, 18, 16, 39, 394, DateTimeKind.Local).AddTicks(5016),
                            Title = "Actividad  5"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 8,
                            Description = "Descripcion de la actividad Número 6",
                            IsCompleted = false,
                            IsDeleted = false,
                            ModifiedAt = new DateTime(2023, 1, 19, 18, 16, 39, 394, DateTimeKind.Local).AddTicks(5063),
                            Title = "Actividad  6"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            Description = "Descripcion de la actividad Número 7",
                            IsCompleted = false,
                            IsDeleted = false,
                            ModifiedAt = new DateTime(2023, 1, 19, 18, 16, 39, 394, DateTimeKind.Local).AddTicks(5066),
                            Title = "Actividad  7"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 6,
                            Description = "Descripcion de la actividad Número 8",
                            IsCompleted = false,
                            IsDeleted = false,
                            ModifiedAt = new DateTime(2023, 1, 19, 18, 16, 39, 394, DateTimeKind.Local).AddTicks(5069),
                            Title = "Actividad  8"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 10,
                            Description = "Descripcion de la actividad Número 9",
                            IsCompleted = false,
                            IsDeleted = false,
                            ModifiedAt = new DateTime(2023, 1, 19, 18, 16, 39, 394, DateTimeKind.Local).AddTicks(5071),
                            Title = "Actividad  9"
                        });
                });

            modelBuilder.Entity("GestionDeTareas.API.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "description of category 1",
                            IsDeleted = false,
                            ModifiedAt = new DateTime(2023, 1, 19, 18, 16, 39, 394, DateTimeKind.Local).AddTicks(4863),
                            Name = "Category 1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "description of category 2",
                            IsDeleted = false,
                            ModifiedAt = new DateTime(2023, 1, 19, 18, 16, 39, 394, DateTimeKind.Local).AddTicks(4885),
                            Name = "Category 2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "description of category 3",
                            IsDeleted = false,
                            ModifiedAt = new DateTime(2023, 1, 19, 18, 16, 39, 394, DateTimeKind.Local).AddTicks(4888),
                            Name = "Category 3"
                        },
                        new
                        {
                            Id = 4,
                            Description = "description of category 4",
                            IsDeleted = false,
                            ModifiedAt = new DateTime(2023, 1, 19, 18, 16, 39, 394, DateTimeKind.Local).AddTicks(4889),
                            Name = "Category 4"
                        },
                        new
                        {
                            Id = 5,
                            Description = "description of category 5",
                            IsDeleted = false,
                            ModifiedAt = new DateTime(2023, 1, 19, 18, 16, 39, 394, DateTimeKind.Local).AddTicks(4891),
                            Name = "Category 5"
                        },
                        new
                        {
                            Id = 6,
                            Description = "description of category 6",
                            IsDeleted = false,
                            ModifiedAt = new DateTime(2023, 1, 19, 18, 16, 39, 394, DateTimeKind.Local).AddTicks(4895),
                            Name = "Category 6"
                        },
                        new
                        {
                            Id = 7,
                            Description = "description of category 7",
                            IsDeleted = false,
                            ModifiedAt = new DateTime(2023, 1, 19, 18, 16, 39, 394, DateTimeKind.Local).AddTicks(4897),
                            Name = "Category 7"
                        },
                        new
                        {
                            Id = 8,
                            Description = "description of category 8",
                            IsDeleted = false,
                            ModifiedAt = new DateTime(2023, 1, 19, 18, 16, 39, 394, DateTimeKind.Local).AddTicks(4899),
                            Name = "Category 8"
                        },
                        new
                        {
                            Id = 9,
                            Description = "description of category 9",
                            IsDeleted = false,
                            ModifiedAt = new DateTime(2023, 1, 19, 18, 16, 39, 394, DateTimeKind.Local).AddTicks(4901),
                            Name = "Category 9"
                        },
                        new
                        {
                            Id = 10,
                            Description = "description of category 10",
                            IsDeleted = false,
                            ModifiedAt = new DateTime(2023, 1, 19, 18, 16, 39, 394, DateTimeKind.Local).AddTicks(4904),
                            Name = "Category 10"
                        });
                });

            modelBuilder.Entity("GestionDeTareas.API.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .HasMaxLength(65535)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("GestionDeTareas.API.Entities.Activity", b =>
                {
                    b.HasOne("GestionDeTareas.API.Entities.Category", "Category")
                        .WithMany("Activities")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GestionDeTareas.API.Entities.Comment", b =>
                {
                    b.HasOne("GestionDeTareas.API.Entities.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Activity");

                    b.Navigation("User");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionDeTareas.API.Entities.Category", b =>
                {
                    b.Navigation("Activities");
                });
#pragma warning restore 612, 618
        }
    }
}
