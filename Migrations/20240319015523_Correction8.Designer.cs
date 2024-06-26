﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace taplistBLIBofficial.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20240319015523_Correction8")]
    partial class Correction8
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("TaplistBlib.Models.Blog", b =>
                {
                    b.Property<string>("Brasserie")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Couleur")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("Degree")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("Blogs");
                });
#pragma warning restore 612, 618
        }
    }
}
