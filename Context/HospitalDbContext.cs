using Clinica.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Context
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions
            <HospitalDbContext> options) : base(options)
        {
        }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<PacienteDoctor> PacienteDoctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
            modelBuilder.Entity<PacienteDoctor>()
                .HasKey(pd => new { pd.PacienteId, pd.DoctorId });

            modelBuilder.Entity<PacienteDoctor>()
                .HasOne(pd => pd.Paciente)
                .WithMany(p => p.PacienteDoctors)
                .HasForeignKey(pd => pd.PacienteId);

            modelBuilder.Entity<PacienteDoctor>()
               .HasOne(pd => pd.Doctor)
               .WithMany(p => p.PacienteDoctors)
               .HasForeignKey(pd => pd.DoctorId);
        }

    }
}
