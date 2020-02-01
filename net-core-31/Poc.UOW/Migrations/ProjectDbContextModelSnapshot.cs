﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Poc.UOW.Contexts;

namespace Poc.UOW.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    partial class ProjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Poc.UOW.Models.ProductModel", b =>
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
                            Id = new Guid("8ba9ba47-b00a-4afd-bf47-16a78bdc0caf"),
                            Code = "GDN-0011",
                            CreatedDate = new DateTime(2019, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Leaf rake with 48-inch wooden handle.",
                            Image = "assets/images/leaf_rake.png",
                            Name = "Leaf Rake",
                            Price = 19.95m,
                            StarRatingId = new Guid("1e8cc7c1-28c9-48f6-953e-6355e3434657")
                        },
                        new
                        {
                            Id = new Guid("e4609429-21fa-4251-b312-8ded86141ac0"),
                            Code = "GDN-0023",
                            CreatedDate = new DateTime(2019, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "15 gallon capacity rolling garden cart",
                            Image = "assets/images/garden_cart.png",
                            Name = "Garden Cart",
                            Price = 32.99m,
                            StarRatingId = new Guid("03b84894-3c8e-4201-b866-70565ba0df9c")
                        },
                        new
                        {
                            Id = new Guid("f7027a6f-a056-4818-b7ad-41636be28454"),
                            Code = "TBX-0048",
                            CreatedDate = new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Curved claw steel hammer",
                            Image = "assets/images/hammer.png",
                            Name = "Hammer",
                            Price = 8.9m,
                            StarRatingId = new Guid("4a9bb30b-3f65-44b6-8e54-c13aae68fa08")
                        },
                        new
                        {
                            Id = new Guid("4e15bd2e-4772-4695-afb4-874a8168dfaa"),
                            Code = "TBX-0022",
                            CreatedDate = new DateTime(2019, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "15-inch steel blade hand saw",
                            Image = "assets/images/saw.png",
                            Name = "Saw",
                            Price = 11.55m,
                            StarRatingId = new Guid("c4e7d07f-ff1d-41d5-8498-a2858bc69063")
                        },
                        new
                        {
                            Id = new Guid("18e7a708-1d46-4d19-964d-42b5ce4e7deb"),
                            Code = "GMG-0042",
                            CreatedDate = new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Standard two-button video game controller",
                            Image = "assets/images/xbox-controller.png",
                            Name = "Video Game Controller",
                            Price = 35.95m,
                            StarRatingId = new Guid("f0524334-8d11-4b5e-86fb-a2a0104eea3b")
                        });
                });

            modelBuilder.Entity("Poc.UOW.Models.StarRatingModel", b =>
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
                            Id = new Guid("1e8cc7c1-28c9-48f6-953e-6355e3434657"),
                            Star = 0.1f
                        },
                        new
                        {
                            Id = new Guid("03b84894-3c8e-4201-b866-70565ba0df9c"),
                            Star = 0.2f
                        },
                        new
                        {
                            Id = new Guid("4a9bb30b-3f65-44b6-8e54-c13aae68fa08"),
                            Star = 0.3f
                        },
                        new
                        {
                            Id = new Guid("c4e7d07f-ff1d-41d5-8498-a2858bc69063"),
                            Star = 0.4f
                        },
                        new
                        {
                            Id = new Guid("f0524334-8d11-4b5e-86fb-a2a0104eea3b"),
                            Star = 0.5f
                        });
                });

            modelBuilder.Entity("Poc.UOW.Models.ProductModel", b =>
                {
                    b.HasOne("Poc.UOW.Models.StarRatingModel", "StarRating")
                        .WithMany("Products")
                        .HasForeignKey("StarRatingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}