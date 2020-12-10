using MyHospitalManagement.Models;
using MyWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.IProductRepo
{
	public interface IAppointmentsRepository
	{
		IEnumerable<Appointment> GetAppointments();

		IEnumerable<Doctor> GetUnAssignedDoctors(int id);
		IEnumerable<Doctor> GetOndutyDoctors(int id);

		Appointment GetAppointment(int id);

		Appointment AddAppointment(Appointment appointment);

		Appointment UpdateAppointment(int id, Appointment appointment);

		Appointment DeleteAppointment(int id);
	}
}
