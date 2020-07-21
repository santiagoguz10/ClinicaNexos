using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Paciente
    {
        [Column("PacienteId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int PacienteId { get; set; }

        [Column("NombreCompleto")]
        [Required]
        [StringLength(150)]
        public string NombreCompleto { get; set; }

        [Column("NumeroSeguroSocial")]
        [Required]
        public int NumeroSeguroSocial { get; set; }

        [Column("CodigoPostal")]
        [Required]
        public int CodigoPostal { get; set; }

        [Column("TelefonoContacto")]
        [Required]
        public int TelefonoContacto { get; set; }

        public ICollection<PacienteDoctor> PacienteDoctors { get; set; }
    }
}
