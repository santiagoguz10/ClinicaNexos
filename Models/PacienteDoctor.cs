﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class PacienteDoctor
    {
        public int DoctorId { get; set; }
        public int PacienteId { get; set; }
        public Doctor Doctor { get; set; }
        public Paciente Paciente { get; set; }

    }
}
