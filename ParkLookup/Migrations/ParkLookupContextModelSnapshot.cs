﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkLookup.Models;

namespace ParkLookup.Migrations
{
    [DbContext(typeof(ParkLookupContext))]
    partial class ParkLookupContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ParkLookup.Models.Park", b =>
                {
                    b.Property<int>("ParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Activities")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4");

                    b.Property<string>("ParkName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4");

                    b.HasKey("ParkId");

                    b.ToTable("Parks");

                    b.HasData(
                        new
                        {
                            ParkId = 1,
                            Activities = "Camping, Hiking, Fishing, Biking, Museum",
                            City = "St. Paul",
                            ParkName = "Champoeg",
                            Rating = 4,
                            State = "Oregon",
                            User = "Bob"
                        },
                        new
                        {
                            ParkId = 2,
                            Activities = "Camping, Hiking, Rafting, Biking, Wildlife",
                            City = "Bozeman",
                            ParkName = "Yellowstone",
                            Rating = 5,
                            State = "Montana",
                            User = "Jerry"
                        },
                        new
                        {
                            ParkId = 3,
                            Activities = "Camping, Hiking, Waterfall, Museum, Food",
                            City = "Troutdale",
                            ParkName = "Multnomah Falls",
                            Rating = 5,
                            State = "Oregon",
                            User = "Elizabeth"
                        },
                        new
                        {
                            ParkId = 4,
                            Activities = "Camping, Mining, Hunting",
                            City = "Plush",
                            ParkName = "Oregon Sunstone Mine",
                            Rating = 4,
                            State = "Oregon",
                            User = "Elizabeth"
                        },
                        new
                        {
                            ParkId = 5,
                            Activities = "Camping, Museum",
                            City = "Astoria",
                            ParkName = "Fort Clatsop",
                            Rating = 3,
                            State = "Oregon",
                            User = "Joe"
                        },
                        new
                        {
                            ParkId = 6,
                            Activities = "Camping, Hiking, Waterfall, River",
                            City = "Estes Park",
                            ParkName = "Rocky Mountain National Park",
                            Rating = 3,
                            State = "Colorado",
                            User = "Joe"
                        },
                        new
                        {
                            ParkId = 7,
                            Activities = "Camping, Hiking, Waterfall, River, Fishing, Hunting",
                            City = "Tillamook",
                            ParkName = "Tillamook State Forest",
                            Rating = 3,
                            State = "Oregon",
                            User = "Henrietta"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
