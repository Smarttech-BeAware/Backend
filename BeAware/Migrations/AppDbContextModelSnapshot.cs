﻿// <auto-generated />
using System.Collections.Generic;
using BeAware.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BeAware.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BeAware.Models.FiledReport", b =>
                {
                    b.Property<string>("Crime")
                        .HasColumnType("text");

                    b.Property<string>("CrimeDetails")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("Occured")
                        .HasColumnType("boolean");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("BeAware.Models.Location", b =>
                {
                    b.Property<string>("Latitude")
                        .HasColumnType("text");

                    b.Property<string>("Longitude")
                        .HasColumnType("text");

                    b.Property<string>("Time")
                        .HasColumnType("text");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("BeAware.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<List<Device>>("Devices")
                        .HasColumnType("jsonb");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BeAware.Models.ValidationRequest", b =>
                {
                    b.Property<bool>("Completed")
                        .HasColumnType("boolean");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PlatformCategory")
                        .HasColumnType("text");

                    b.Property<string>("PlatformDetails")
                        .HasColumnType("text");

                    b.Property<string>("PlatformName")
                        .HasColumnType("text");

                    b.ToTable("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
