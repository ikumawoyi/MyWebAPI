using MyHospitalManagement.Models;
using MyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Model
{
	public class Appointment
	{
		
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public string Description { get; set; }

		public ICollection<Doctor> Doctors { get; set; }
	}
}
