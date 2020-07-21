﻿// <auto-generated />
using Clinica.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clinica.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    partial class HospitalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Clinica.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DoctorId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasColumnName("Especialidad")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Hospital")
                        .IsRequired()
                        .HasColumnName("Hospital")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnName("NombreCompleto")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int>("NumeroCredencial")
                        .HasColumnName("NumeroCredencial")
                        .HasColumnType("int");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("Clinica.Models.Paciente", b =>
                {
                    b.Property<int>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PacienteId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoPostal")
                        .HasColumnName("CodigoPostal")
                        .HasColumnType("int");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnName("NombreCompleto")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int>("NumeroSeguroSocial")
                        .HasColumnName("NumeroSeguroSocial")
                        .HasColumnType("int");

                    b.Property<int>("TelefonoContacto")
                        .HasColumnName("TelefonoContacto")
                        .HasColumnType("int");

                    b.HasKey("PacienteId");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("Clinica.Models.PacienteDoctor", b =>
                {
                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.HasKey("PacienteId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("PacienteDoctors");
                });

            modelBuilder.Entity("Clinica.Models.PacienteDoctor", b =>
                {
                    b.HasOne("Clinica.Models.Doctor", "Doctor")
                        .WithMany("PacienteDoctors")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinica.Models.Paciente", "Paciente")
                        .WithMany("PacienteDoctors")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}