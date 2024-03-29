﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JSON.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20240312142455_new")]
    partial class @new
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Ordinazione", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Disponibile")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id_Tavolo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TavoloId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TavoloId");

                    b.ToTable("Ordinazioni");
                });

            modelBuilder.Entity("OrdinazionePiatto", b =>
                {
                    b.Property<int>("OrdinazioniId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PiattiId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrdinazioniId", "PiattiId");

                    b.HasIndex("PiattiId");

                    b.ToTable("OrdinazionePiatto");
                });

            modelBuilder.Entity("Piatto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Disponibile")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Prezzo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Piatti");
                });

            modelBuilder.Entity("Tavolo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacita")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Disponibile")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tavoli");
                });

            modelBuilder.Entity("Ordinazione", b =>
                {
                    b.HasOne("Tavolo", "Tavolo")
                        .WithMany("Ordinazioni")
                        .HasForeignKey("TavoloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tavolo");
                });

            modelBuilder.Entity("OrdinazionePiatto", b =>
                {
                    b.HasOne("Ordinazione", null)
                        .WithMany()
                        .HasForeignKey("OrdinazioniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Piatto", null)
                        .WithMany()
                        .HasForeignKey("PiattiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tavolo", b =>
                {
                    b.Navigation("Ordinazioni");
                });
#pragma warning restore 612, 618
        }
    }
}
