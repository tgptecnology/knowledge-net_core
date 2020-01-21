﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Poc.DapperWithEF.Contexts;

namespace Poc.DapperWithEF.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    [Migration("20200119164053_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Poc.DapperWithEF.Models.ProductModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("Code")
                        .HasColumnType("NVARCHAR(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CreatedDate")
                        .HasColumnType("DATE");

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("NVARCHAR(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Image")
                        .HasColumnName("Image")
                        .HasColumnType("NVARCHAR(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("NVARCHAR(100)")
                        .HasMaxLength(100);

                    b.Property<decimal>("Price")
                        .HasColumnName("Price")
                        .HasColumnType("DECIMAL(19,4)");

                    b.Property<Guid>("StarRatingId")
                        .HasColumnName("StarRatingId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.HasKey("Id");

                    b.HasIndex("StarRatingId");

                    b.ToTable("Products","dbo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e67f3ca8-ca1c-457b-9fe0-e24d0d71c2b8"),
                            Code = "GDN-0011",
                            CreatedDate = new DateTime(2019, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Leaf rake with 48-inch wooden handle.",
                            Image = "assets/images/leaf_rake.png",
                            Name = "Leaf Rake",
                            Price = 19.95m,
                            StarRatingId = new Guid("d69cdd54-4084-4df3-a58d-38c85801e513")
                        },
                        new
                        {
                            Id = new Guid("8bda45e5-bb56-4a1b-b5e4-0ff2fa6eeebe"),
                            Code = "GDN-0023",
                            CreatedDate = new DateTime(2019, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "15 gallon capacity rolling garden cart",
                            Image = "assets/images/garden_cart.png",
                            Name = "Garden Cart",
                            Price = 32.99m,
                            StarRatingId = new Guid("86134972-7a98-409f-8937-c1ce835361c8")
                        },
                        new
                        {
                            Id = new Guid("5215d042-67fb-43a5-b9b0-04e18d4f627e"),
                            Code = "TBX-0048",
                            CreatedDate = new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Curved claw steel hammer",
                            Image = "assets/images/hammer.png",
                            Name = "Hammer",
                            Price = 8.9m,
                            StarRatingId = new Guid("d9496d92-4cb9-494f-9843-55f324585b5b")
                        },
                        new
                        {
                            Id = new Guid("5d674234-5385-41c4-adf9-951ae1e5346a"),
                            Code = "TBX-0022",
                            CreatedDate = new DateTime(2019, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "15-inch steel blade hand saw",
                            Image = "assets/images/saw.png",
                            Name = "Saw",
                            Price = 11.55m,
                            StarRatingId = new Guid("eee2517c-8585-42ac-b910-b13928dd2557")
                        },
                        new
                        {
                            Id = new Guid("d5ddee7c-84cc-4383-9a8a-26eb466056a9"),
                            Code = "GMG-0042",
                            CreatedDate = new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Standard two-button video game controller",
                            Image = "assets/images/xbox-controller.png",
                            Name = "Video Game Controller",
                            Price = 35.95m,
                            StarRatingId = new Guid("de203a87-cdef-4865-a6db-49db78490bfd")
                        });
                });

            modelBuilder.Entity("Poc.DapperWithEF.Models.StarRatingModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("NVARCHAR(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Image")
                        .HasColumnName("Image")
                        .HasColumnType("NVARCHAR(500)")
                        .HasMaxLength(500);

                    b.Property<float>("Star")
                        .HasColumnName("Star")
                        .HasColumnType("FLOAT(24)");

                    b.HasKey("Id");

                    b.HasIndex("Star")
                        .IsUnique()
                        .HasName("UK_StarRating_Star");

                    b.ToTable("StarRating","dbo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d69cdd54-4084-4df3-a58d-38c85801e513"),
                            Star = 3.2f
                        },
                        new
                        {
                            Id = new Guid("86134972-7a98-409f-8937-c1ce835361c8"),
                            Star = 4.2f
                        },
                        new
                        {
                            Id = new Guid("d9496d92-4cb9-494f-9843-55f324585b5b"),
                            Star = 4.8f
                        },
                        new
                        {
                            Id = new Guid("eee2517c-8585-42ac-b910-b13928dd2557"),
                            Star = 3.7f
                        },
                        new
                        {
                            Id = new Guid("de203a87-cdef-4865-a6db-49db78490bfd"),
                            Star = 4.6f
                        });
                });

            modelBuilder.Entity("Poc.DapperWithEF.Models.ProductModel", b =>
                {
                    b.HasOne("Poc.DapperWithEF.Models.StarRatingModel", "StarRating")
                        .WithMany("Products")
                        .HasForeignKey("StarRatingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
