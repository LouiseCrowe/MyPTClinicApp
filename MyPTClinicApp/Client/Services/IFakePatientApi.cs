using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bUnitTestsWithXUnit
{
    public interface IFakePatientApi
    {
        Task<List<Patient>> GetPatientsAsync();
    }
}
