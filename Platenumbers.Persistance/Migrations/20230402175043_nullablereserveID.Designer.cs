﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlateNumbers.Persistence.DatabaseContext;

#nullable disable

namespace Platenumbers.Persistance.Migrations
{
    [DbContext(typeof(PlateNumberContext))]
    [Migration("20230402175043_nullablereserveID")]
    partial class nullablereserveID
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Platenumbers.Domain.PlateNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nchar")
                        .IsFixedLength();

                    b.Property<int?>("ReserveNumberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReserveNumberId");

                    b.ToTable("plateNumbers");
                });

            modelBuilder.Entity("ReserveNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("reserveNumbers");
                });

            modelBuilder.Entity("Platenumbers.Domain.PlateNumber", b =>
                {
                    b.HasOne("ReserveNumber", "ReserveNumber")
                        .WithMany("PlateNumbers")
                        .HasForeignKey("ReserveNumberId");

                    b.Navigation("ReserveNumber");
                });

            modelBuilder.Entity("ReserveNumber", b =>
                {
                    b.Navigation("PlateNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
