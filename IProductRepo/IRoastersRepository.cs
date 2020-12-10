using MyHospitalManagement.Models;
using MyWebAPI.Model;
using MyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.IProductRepo
{
	public interface IRoastersRepository
	{
		IEnumerable<Roaster> GetRoasters();

		IEnumerable<Doctor> GetDoctors(int id);

		Roaster GetRoaster (int id);

		Roaster AddRoaster(Roaster roaster);

		Roaster UpdateRoaster(int id, Roaster roaster);

		Roaster DeleteRoaster(int id);
	}
}
