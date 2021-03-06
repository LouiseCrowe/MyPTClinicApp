﻿using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Server.Models
{
    public interface ITreatmentRepository
    {
        Task<IEnumerable<Treatment>> GetTreatments();
        Task<Treatment> GetTreatmentById(int treatmentId);
        Task<Treatment> AddTreatment(Treatment treatment);
        Task<Treatment> UpdateTreatment(Treatment treatment);
        void DeleteTreatment(int treatmentId);

    }
}