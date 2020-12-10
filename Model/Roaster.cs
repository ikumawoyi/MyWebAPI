using MyHospitalManagement.Models;
using MyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Model
{
	public partial class Roaster
	{
		public Roaster()
		{
			Doctors = new HashSet<Doctor>();
			Nurses = new HashSet<Nurse>();
		}

		public int Id { get; set; }
		public DateTime Date { get; set; }

		public ICollection<Doctor> Doctors { get; set; }
		public ICollection<Nurse> Nurses { get; set; }
	}
}
