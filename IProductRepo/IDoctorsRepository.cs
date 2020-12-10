using MyHospitalManagement.Models;
using MyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyWebAPI.Repositories
{
    public interface IDoctorsRepository
    {

        IEnumerable<Doctor> GetDoctors();

        IEnumerable<Patient> GetPatients(int id);

        Doctor GetDoctor(int id);

        Doctor AddDoctor(Doctor doctor);

        Doctor UpdateDoctor(int id, Doctor doctor);

        Doctor DeleteDoctor(int id);

    }
}
