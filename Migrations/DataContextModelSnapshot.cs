﻿// <auto-generated />
using System;
using CoffeeReviewApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoffeeReviewApp.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CoffeeReviewApp.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CoffeeReviewApp.Models.Coffee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Coffees");
                });

            modelBuilder.Entity("CoffeeReviewApp.Models.CoffeeCategory", b =>
                {
                    b.Property<int>("CoffeeId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("CoffeeId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CoffeeCategories");
                });

            modelBuilder.Entity("CoffeeReviewApp.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CoffeeReviewApp.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CoffeeId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("ReviewerId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CoffeeId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("CoffeeReviewApp.Models.Reviewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reviewers");
                });

            modelBuilder.Entity("CoffeeReviewApp.Models.Coffee", b =>
                {
                    b.HasOne("CoffeeReviewApp.Models.Country", "Country")
                        .WithMany("Coffees")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("CoffeeReviewApp.Models.CoffeeCategory", b =>
                {
                    b.HasOne("CoffeeReviewApp.Models.Category", "Category")
                        .WithMany("CoffeeCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoffeeReviewApp.Models.Coffee", "Coffee")
                        .WithMany("CoffeeCategories")
                        .HasForeignKey("CoffeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Coffee");
                });

            modelBuilder.Entity("CoffeeReviewApp.Models.Review", b =>
                {
                    b.HasOne("CoffeeReviewApp.Models.Coffee", "Coffee")
                        .WithMany("Reviews")
                        .HasForeignKey("CoffeeId");

                    b.HasOne("CoffeeReviewApp.Models.Reviewer", "Reviewer")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewerId");

                    b.Navigation("Coffee");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("CoffeeReviewApp.Models.Category", b =>
                {
                    b.Navigation("CoffeeCategories");
                });

            modelBuilder.Entity("CoffeeReviewApp.Models.Coffee", b =>
                {
                    b.Navigation("CoffeeCategories");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("CoffeeReviewApp.Models.Country", b =>
                {
                    b.Navigation("Coffees");
                });

            modelBuilder.Entity("CoffeeReviewApp.Models.Reviewer", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
