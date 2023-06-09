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
    [Migration("20230403215045_gsdkg")]
    partial class gsdkg
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrderNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("orderNumbers");
                });

            modelBuilder.Entity("Platenumbers.Domain.PlateNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderNumberId")
                        .HasColumnType("int");

                    b.Property<int?>("ReserveNumberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderNumberId");

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

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("reserveNumbers");
                });

            modelBuilder.Entity("Platenumbers.Domain.PlateNumber", b =>
                {
                    b.HasOne("OrderNumber", "OrderNumber")
                        .WithMany("PlateNumbers")
                        .HasForeignKey("OrderNumberId");

                    b.HasOne("ReserveNumber", "ReserveNumber")
                        .WithMany("PlateNumbers")
                        .HasForeignKey("ReserveNumberId");

                    b.Navigation("OrderNumber");

                    b.Navigation("ReserveNumber");
                });

            modelBuilder.Entity("OrderNumber", b =>
                {
                    b.Navigation("PlateNumbers");
                });

            modelBuilder.Entity("ReserveNumber", b =>
                {
                    b.Navigation("PlateNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
