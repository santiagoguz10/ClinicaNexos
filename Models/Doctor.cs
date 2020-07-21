using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Doctor
    {
        [Column("DoctorId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int DoctorId { get; set; }

        [Column("NombreCompleto")]
        [Required]
        [StringLength(150)]
        public string NombreCompleto { get; set; }

        [Column("Especialidad")]
        [Required]
        [StringLength(50)]
        public string Especialidad { get; set; }

        [Column("NumeroCredencial")]
        [Required]
        public int NumeroCredencial { get; set; }

        [Column("Hospital")]
        [Required]
        [StringLength(50)]
        public string Hospital { get; set; }

        public ICollection<PacienteDoctor> PacienteDoctors { get; set; }
    }
}
