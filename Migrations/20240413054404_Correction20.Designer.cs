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
    [Migration("20240413054404_Correction20")]
    partial class Correction20
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("TaplistBlib.Models.Authent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Identifiant")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StandId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Authents");
                });

            modelBuilder.Entity("TaplistBlib.Models.Beer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

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

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Style")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("TaplistBlib.Models.Stand", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("BrasserieStand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Stands");
                });

            modelBuilder.Entity("TaplistBlib.Models.Stand", b =>
                {
                    b.HasOne("TaplistBlib.Models.Authent", "Authent")
                        .WithOne("Stand")
                        .HasForeignKey("TaplistBlib.Models.Stand", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Authent");
                });

            modelBuilder.Entity("TaplistBlib.Models.Authent", b =>
                {
                    b.Navigation("Stand")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
