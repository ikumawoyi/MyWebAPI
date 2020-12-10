using MyWebAPI.Model;
using MyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHospitalManagement.Models
{
	public partial class Doctor
	{
		public Doctor()
		{
			Patients = new HashSet<Patient>();
		}

		public int Id { get; set; }
		public bool IsOnDuty { get; set; }
		public bool IsActive { get; set; }
		public bool IsAssigned { get; set; }
		public string Name { get; set; }
		public int? RoasterId { get; set; }
		public int? AppointmentId { get; set; }

		public Roaster Roaster { get; set; }
		public Appointment Appointment { get; set; }

		public ICollection<Patient> Patients { get; set; }
	}
}
