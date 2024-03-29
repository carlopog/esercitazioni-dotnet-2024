﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SICBO.Migrations
{
    [DbContext(typeof(Database))]
    partial class DatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Giocatore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Bottino")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Eta")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Lastbet")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Prestito")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Giocatori");
                });

            modelBuilder.Entity("Scommessa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Prezzo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Vincita")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Scommesse");
                });
#pragma warning restore 612, 618
        }
    }
}
