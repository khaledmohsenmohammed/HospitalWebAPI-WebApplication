﻿// <auto-generated />
using System;
using HospitalWebAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalWebAPI.Migrations
{
    [DbContext(typeof(HospitalContext))]
    [Migration("20201217162945_updatemodeluser")]
    partial class updatemodeluser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("HospitalWebAPI.Models.Entities.AdminApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("TypeOfJop")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("AdminApplicationUser");
                });

            modelBuilder.Entity("HospitalWebAPI.Models.Entities.Hospital", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HospitalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("icuID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("icuID")
                        .IsUnique();

                    b.ToTable("Hospital");
                });

            modelBuilder.Entity("HospitalWebAPI.Models.Entities.ICU", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("numberOfBed")
                        .HasColumnType("int");

                    b.Property<int>("numnerOfDevaises")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("iCU");
                });

            modelBuilder.Entity("HospitalWebAPI.Models.Entities.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AgeOfPatient")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTimeOfCheckout")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeOfEntering")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HospitalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("JobOfPatient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicalReport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NationalId")
                        .HasColumnType("bigint");

                    b.Property<bool>("RespiratorDeviceStateb")
                        .HasColumnType("bit");

                    b.Property<int>("TicketNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("HospitalWebAPI.Models.Entities.Hospital", b =>
                {
                    b.HasOne("HospitalWebAPI.Models.Entities.ICU", "icu")
                        .WithOne("hospitalId")
                        .HasForeignKey("HospitalWebAPI.Models.Entities.Hospital", "icuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("icu");
                });

            modelBuilder.Entity("HospitalWebAPI.Models.Entities.Patient", b =>
                {
                    b.HasOne("HospitalWebAPI.Models.Entities.Hospital", null)
                        .WithMany("patients")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalWebAPI.Models.Entities.Hospital", b =>
                {
                    b.Navigation("patients");
                });

            modelBuilder.Entity("HospitalWebAPI.Models.Entities.ICU", b =>
                {
                    b.Navigation("hospitalId");
                });
#pragma warning restore 612, 618
        }
    }
}
