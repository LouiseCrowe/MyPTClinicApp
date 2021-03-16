﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPTClinicApp.Shared
{
    public class TreatmentDTO
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public string TherapistFirstName { get; set; }
        public string TherapistLastName { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
      
    }
}