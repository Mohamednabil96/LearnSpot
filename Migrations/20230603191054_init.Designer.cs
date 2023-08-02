﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskDay2.Models;

#nullable disable

namespace TaskDay2.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230603191054_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskDay2.Models.Course", b =>
                {
                    b.Property<int>("CrsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CrsId"));

                    b.Property<string>("CrsDegree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CrsMinDegree")
                        .HasColumnType("int");

                    b.Property<string>("CrsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.HasKey("CrsId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("TaskDay2.Models.CrsResult", b =>
                {
                    b.Property<int>("CrsResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CrsResultId"));

                    b.Property<string>("CrsId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CrsResultDegree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TraId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CrsResultId");

                    b.ToTable("CrsResult");
                });

            modelBuilder.Entity("TaskDay2.Models.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeptId"));

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.HasIndex("DeptId");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("TaskDay2.Models.Trainee", b =>
                {
                    b.Property<int>("TraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TraId"));

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

                    b.ToTable("Trainee");
                });

            modelBuilder.Entity("TaskDay2.Models.Instructor", b =>
                {
                    b.HasOne("TaskDay2.Models.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("TaskDay2.Models.Department", b =>
                {
                    b.Navigation("Instructors");
                });
#pragma warning restore 612, 618
        }
    }
}
