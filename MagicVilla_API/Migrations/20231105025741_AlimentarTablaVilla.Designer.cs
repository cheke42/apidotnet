﻿// <auto-generated />
using System;
using MagicVilla_API.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231105025741_AlimentarTablaVilla")]
    partial class AlimentarTablaVilla
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicVilla_API.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Fee")
                        .HasColumnType("float");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ocuppants")
                        .HasColumnType("int");

                    b.Property<int>("SquareMeter")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "",
                            CrationDate = new DateTime(2023, 11, 4, 23, 57, 41, 915, DateTimeKind.Local).AddTicks(4600),
                            Detail = "Detalle de la Villa...",
                            Fee = 200.0,
                            ImageUrl = "",
                            Name = "Villa Real",
                            Ocuppants = 5,
                            SquareMeter = 50,
                            UpdateDate = new DateTime(2023, 11, 4, 23, 57, 41, 915, DateTimeKind.Local).AddTicks(4609)
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "",
                            CrationDate = new DateTime(2023, 11, 4, 23, 57, 41, 915, DateTimeKind.Local).AddTicks(4611),
                            Detail = "Detalle de la Villa...",
                            Fee = 150.0,
                            ImageUrl = "",
                            Name = "Premium Vista a la Piscina",
                            Ocuppants = 4,
                            SquareMeter = 40,
                            UpdateDate = new DateTime(2023, 11, 4, 23, 57, 41, 915, DateTimeKind.Local).AddTicks(4611)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
