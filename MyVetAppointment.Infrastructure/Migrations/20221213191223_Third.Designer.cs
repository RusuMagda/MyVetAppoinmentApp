﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyVetAppointment.Infrastructure;

#nullable disable

namespace MyVetAppointment.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221213191223_Third")]
    partial class Third
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("MyVetAppoinment.Domain.Entities.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CabinetId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PetId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("MyVetAppoinment.Domain.Entities.Cabinet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cabinets");
                });

            modelBuilder.Entity("MyVetAppoinment.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CabinetId")
                        .HasColumnType("TEXT");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CabinetId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("MyVetAppoinment.Domain.Entities.Drug", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("DrugDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DrugName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuantityMeasure")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SaleForm")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ShopId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("Drugs");
                });

            modelBuilder.Entity("MyVetAppoinment.Domain.Entities.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("MyVetAppoinment.Domain.Entities.Shop", b =>
                {
                    b.Property<Guid>("ShopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CabinetId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShopName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ShopId");

                    b.HasIndex("CabinetId")
                        .IsUnique();

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("MyVetAppoinment.Domain.Entities.Appointment", b =>
                {
                    b.HasOne("MyVetAppoinment.Domain.Entities.Pet", null)
                        .WithMany("Appointments")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyVetAppoinment.Domain.Entities.Client", b =>
                {
                    b.HasOne("MyVetAppoinment.Domain.Entities.Cabinet", null)
                        .WithMany("Clients")
                        .HasForeignKey("CabinetId");
                });

            modelBuilder.Entity("MyVetAppoinment.Domain.Entities.Drug", b =>
                {
                    b.HasOne("MyVetAppoinment.Domain.Entities.Shop", null)
                        .WithMany("Drugs")
                        .HasForeignKey("ShopId");
                });

            modelBuilder.Entity("MyVetAppoinment.Domain.Entities.Pet", b =>
                {
                    b.HasOne("MyVetAppoinment.Domain.Entities.Client", null)
                        .WithMany("Pets")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("MyVetAppoinment.Domain.Entities.Shop", b =>
                {
                    b.HasOne("MyVetAppoinment.Domain.Entities.Cabinet", null)
                        .WithOne("Shop")
                        .HasForeignKey("MyVetAppoinment.Domain.Entities.Shop", "CabinetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyVetAppoinment.Domain.Entities.Cabinet", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Shop")
                        .IsRequired();
                });

            modelBuilder.Entity("MyVetAppoinment.Domain.Entities.Client", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("MyVetAppoinment.Domain.Entities.Pet", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("MyVetAppoinment.Domain.Entities.Shop", b =>
                {
                    b.Navigation("Drugs");
                });
#pragma warning restore 612, 618
        }
    }
}
