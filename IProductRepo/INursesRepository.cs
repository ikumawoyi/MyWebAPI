using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyHospitalManagement.Models;
using MyWebAPI.Models;

namespace MyWebAPI.Repositories
{
    public interface INursesRepository
    {

        IEnumerable<Nurse> GetNurses();

        Nurse GetNurse(int id);

        Nurse AddNurse(Nurse nurse);

        void UpdateNurse(int id, Nurse nurse);

        void DeleteNurse(int id);

    }
}
