﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagementSystem.Infrastructure;

#nullable disable

namespace TaskManagementSystem.Infrastructure.Migrations
{
    [DbContext(typeof(TaskManagementContext))]
    partial class TaskManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TaskManagementSystem.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Name = "TeamLead"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Senior"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Middle"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Junior"
                        });
                });

            modelBuilder.Entity("TaskManagementSystem.Domain.Task", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int?>("PerformerId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("PerformerId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskManagementSystem.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Email = "ss@s.com",
                            FullName = "Morgana Paw",
                            Password = "asd123",
                            RoleID = 0
                        },
                        new
                        {
                            Id = 1,
                            Email = "s@sdd.com",
                            FullName = "Joker",
                            Password = "asd1asadsad23",
                            RoleID = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "ssggg@s.com",
                            FullName = "Panther Rose",
                            Password = "asad1asdsad23",
                            RoleID = 2
                        },
                        new
                        {
                            Id = 3,
                            Email = "sdfs@s.com",
                            FullName = "Skull",
                            Password = "asdasdasdasd123",
                            RoleID = 3
                        },
                        new
                        {
                            Id = 4,
                            Email = "ssss@s.com",
                            FullName = "Knight Zero",
                            Password = "asdsdf12asd3",
                            RoleID = 3
                        });
                });

            modelBuilder.Entity("TaskManagementSystem.Domain.Task", b =>
                {
                    b.HasOne("TaskManagementSystem.Domain.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagementSystem.Domain.User", "Performer")
                        .WithMany()
                        .HasForeignKey("PerformerId");

                    b.Navigation("Creator");

                    b.Navigation("Performer");
                });

            modelBuilder.Entity("TaskManagementSystem.Domain.User", b =>
                {
                    b.HasOne("TaskManagementSystem.Domain.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
