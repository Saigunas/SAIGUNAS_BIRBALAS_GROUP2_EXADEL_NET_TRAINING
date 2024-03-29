﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagementSystem.Infrastructure;

#nullable disable

namespace Task9._1.Migrations
{
    [DbContext(typeof(TaskManagementContext))]
    partial class TaskManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Task9._1.DataAccessLayer.Core.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Task9._1.DataAccessLayer.Core.Model.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("PerformerId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("PerformerId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Task9._1.DataAccessLayer.Core.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                });

            modelBuilder.Entity("Task9._1.DataAccessLayer.Core.Model.Task", b =>
                {
                    b.HasOne("Task9._1.DataAccessLayer.Core.Model.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task9._1.DataAccessLayer.Core.Model.User", "Performer")
                        .WithMany()
                        .HasForeignKey("PerformerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Performer");
                });

            modelBuilder.Entity("Task9._1.DataAccessLayer.Core.Model.User", b =>
                {
                    b.HasOne("Task9._1.DataAccessLayer.Core.Model.Role", "Role")
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
