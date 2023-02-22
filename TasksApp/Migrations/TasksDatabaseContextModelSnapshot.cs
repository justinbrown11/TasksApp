﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TasksApp.Models;

namespace TasksApp.Migrations
{
    [DbContext(typeof(TasksDatabaseContext))]
    partial class TasksDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("TasksApp.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Home"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "School"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Work"
                        },
                        new
                        {
                            CategoryID = 4,
                            CategoryName = "Church"
                        });
                });

            modelBuilder.Entity("TasksApp.Models.Tasks", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quadrant")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TaskID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Responses");

                    b.HasData(
                        new
                        {
                            TaskID = 1,
                            CategoryID = 1,
                            Completed = false,
                            DueDate = new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quadrant = 2,
                            TaskName = "Do the Dishes"
                        },
                        new
                        {
                            TaskID = 2,
                            CategoryID = 2,
                            Completed = false,
                            DueDate = new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quadrant = 1,
                            TaskName = "Study for Security Test"
                        });
                });

            modelBuilder.Entity("TasksApp.Models.Tasks", b =>
                {
                    b.HasOne("TasksApp.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
