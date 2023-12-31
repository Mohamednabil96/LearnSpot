﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskDay2.Models;

#nullable disable

namespace TaskDay2.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskDay2.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("TaskDay2.Models.Course", b =>
                {
                    b.Property<int>("CrsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CrsId"));

                    b.Property<int>("CrsDegree")
                        .HasColumnType("int");

                    b.Property<int>("CrsMinDegree")
                        .HasColumnType("int");

                    b.Property<string>("CrsName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("CrsId");

                    b.HasIndex("DeptId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("TaskDay2.Models.CrsResult", b =>
                {
                    b.Property<int>("CrsResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CrsResultId"));

                    b.Property<int?>("CrsId")
                        .HasColumnType("int");

                    b.Property<int?>("CrsResultDegree")
                        .HasColumnType("int");

                    b.Property<int?>("TraId")
                        .HasColumnType("int");

                    b.HasKey("CrsResultId");

                    b.HasIndex("CrsId");

                    b.HasIndex("TraId");

                    b.ToTable("CrsResult");
                });

            modelBuilder.Entity("TaskDay2.Models.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeptId"));

                    b.Property<string>("DeptName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ManagerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeptId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("TaskDay2.Models.Instructor", b =>
                {
                    b.Property<int>("InsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InsId"));

                    b.Property<int>("CrsId")
                        .HasColumnType("int");

                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<string>("InsAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InsSalary")
                        .HasColumnType("int");

                    b.HasKey("InsId");

                    b.HasIndex("CrsId");

                    b.HasIndex("DeptId");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("TaskDay2.Models.Trainee", b =>
                {
                    b.Property<int>("TraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TraId"));

                    b.Property<int?>("DepartmentDeptId")
                        .HasColumnType("int");

                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<string>("TraAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TraGrade")
                        .HasColumnType("int");

                    b.Property<string>("TraImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TraName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TraId");

                    b.HasIndex("DepartmentDeptId");

                    b.ToTable("Trainee");
                });

            modelBuilder.Entity("TaskDay2.Models.Course", b =>
                {
                    b.HasOne("TaskDay2.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("TaskDay2.Models.CrsResult", b =>
                {
                    b.HasOne("TaskDay2.Models.Course", "Course")
                        .WithMany("CrsResults")
                        .HasForeignKey("CrsId");

                    b.HasOne("TaskDay2.Models.Trainee", "Trainee")
                        .WithMany("CrsResults")
                        .HasForeignKey("TraId");

                    b.Navigation("Course");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("TaskDay2.Models.Instructor", b =>
                {
                    b.HasOne("TaskDay2.Models.Course", "Course")
                        .WithMany("Instructors")
                        .HasForeignKey("CrsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskDay2.Models.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("TaskDay2.Models.Trainee", b =>
                {
                    b.HasOne("TaskDay2.Models.Department", null)
                        .WithMany("Trainees")
                        .HasForeignKey("DepartmentDeptId");
                });

            modelBuilder.Entity("TaskDay2.Models.Course", b =>
                {
                    b.Navigation("CrsResults");

                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("TaskDay2.Models.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Instructors");

                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("TaskDay2.Models.Trainee", b =>
                {
                    b.Navigation("CrsResults");
                });
#pragma warning restore 612, 618
        }
    }
}
