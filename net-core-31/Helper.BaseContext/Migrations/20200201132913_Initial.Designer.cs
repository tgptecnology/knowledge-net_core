﻿// <auto-generated />
using System;
using Helper.BaseContext.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Helper.BaseContext.Migrations
{
    [DbContext(typeof(ProjectDbBaseContext))]
    [Migration("20200201132913_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Helper.BaseContext.Models.ProductModel", b =>
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
                            Id = new Guid("975190e4-cdad-44f5-b2bd-557e7c05fb85"),
                            Code = "GDN-0011",
                            CreatedDate = new DateTime(2019, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Leaf rake with 48-inch wooden handle.",
                            Image = "assets/images/leaf_rake.png",
                            Name = "Leaf Rake",
                            Price = 19.95m,
                            StarRatingId = new Guid("f74c8b08-e89c-4954-8041-7633f6a1b9a7")
                        },
                        new
                        {
                            Id = new Guid("4674bb08-0c16-4a8d-b68d-fd3376004fb2"),
                            Code = "GDN-0023",
                            CreatedDate = new DateTime(2019, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "15 gallon capacity rolling garden cart",
                            Image = "assets/images/garden_cart.png",
                            Name = "Garden Cart",
                            Price = 32.99m,
                            StarRatingId = new Guid("e82be0a5-f511-4718-9a0b-0622a5ad25df")
                        },
                        new
                        {
                            Id = new Guid("80a533a5-ab59-4a6f-8583-77b26c6914c1"),
                            Code = "TBX-0048",
                            CreatedDate = new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Curved claw steel hammer",
                            Image = "assets/images/hammer.png",
                            Name = "Hammer",
                            Price = 8.9m,
                            StarRatingId = new Guid("f23e73e5-aace-446b-bca2-8aa403af1f13")
                        },
                        new
                        {
                            Id = new Guid("0279f6c3-369b-4c2d-a752-86f87771e7a3"),
                            Code = "TBX-0022",
                            CreatedDate = new DateTime(2019, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "15-inch steel blade hand saw",
                            Image = "assets/images/saw.png",
                            Name = "Saw",
                            Price = 11.55m,
                            StarRatingId = new Guid("d67b7936-c372-49a2-867e-e662777d1ecf")
                        },
                        new
                        {
                            Id = new Guid("55921f0a-b4e7-4268-a705-4ef5a0e74f24"),
                            Code = "GMG-0042",
                            CreatedDate = new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Standard two-button video game controller",
                            Image = "assets/images/xbox-controller.png",
                            Name = "Video Game Controller",
                            Price = 35.95m,
                            StarRatingId = new Guid("eceefb85-e135-4f23-8e3c-6d67dd74ac32")
                        });
                });

            modelBuilder.Entity("Helper.BaseContext.Models.StarRatingModel", b =>
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
                            Id = new Guid("f74c8b08-e89c-4954-8041-7633f6a1b9a7"),
                            Star = 0.1f
                        },
                        new
                        {
                            Id = new Guid("e82be0a5-f511-4718-9a0b-0622a5ad25df"),
                            Star = 0.2f
                        },
                        new
                        {
                            Id = new Guid("f23e73e5-aace-446b-bca2-8aa403af1f13"),
                            Star = 0.3f
                        },
                        new
                        {
                            Id = new Guid("d67b7936-c372-49a2-867e-e662777d1ecf"),
                            Star = 0.4f
                        },
                        new
                        {
                            Id = new Guid("eceefb85-e135-4f23-8e3c-6d67dd74ac32"),
                            Star = 0.5f
                        });
                });

            modelBuilder.Entity("Helper.BaseContext.Models.ProductModel", b =>
                {
                    b.HasOne("Helper.BaseContext.Models.StarRatingModel", "StarRating")
                        .WithMany("Products")
                        .HasForeignKey("StarRatingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
