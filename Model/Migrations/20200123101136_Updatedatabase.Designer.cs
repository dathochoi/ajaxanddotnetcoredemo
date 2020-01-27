﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model;

namespace Model.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20200123101136_Updatedatabase")]
    partial class Updatedatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Model.EmployeeDB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<float>("Salary");

                    b.Property<bool>("Status");

                    b.HasKey("ID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreatedDate = new DateTime(2020, 1, 23, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "Nguyen Van A",
                            Salary = 20000f,
                            Status = true
                        },
                        new
                        {
                            ID = 2,
                            CreatedDate = new DateTime(2020, 1, 23, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "Nguyen Van B",
                            Salary = 3000f,
                            Status = true
                        },
                        new
                        {
                            ID = 3,
                            CreatedDate = new DateTime(2020, 1, 23, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "Nguyen Van F",
                            Salary = 80000f,
                            Status = true
                        },
                        new
                        {
                            ID = 4,
                            CreatedDate = new DateTime(2020, 1, 23, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "Nguyen Van A",
                            Salary = 20000f,
                            Status = true
                        },
                        new
                        {
                            ID = 5,
                            CreatedDate = new DateTime(2020, 1, 23, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "Van D",
                            Salary = 5000f,
                            Status = true
                        },
                        new
                        {
                            ID = 6,
                            CreatedDate = new DateTime(2020, 1, 23, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = " Van A",
                            Salary = 13000f,
                            Status = true
                        },
                        new
                        {
                            ID = 7,
                            CreatedDate = new DateTime(2020, 1, 23, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "Nguyen C",
                            Salary = 90000f,
                            Status = true
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
