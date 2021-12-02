﻿// <auto-generated />
using System;
using AirRestService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirRestService.Migrations
{
    [DbContext(typeof(AirRestServiceContext))]
    [Migration("20211202114718_3")]
    partial class _3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AirLibrary.Air", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CO2")
                        .HasColumnType("float");

                    b.Property<double>("Humidity")
                        .HasColumnType("float");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Air");
                });
#pragma warning restore 612, 618
        }
    }
}