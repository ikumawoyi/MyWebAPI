using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Model
{
	public class Facilitator
	{
		public int FacilitatorId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public string UserName { get; set; }
		public string PhoneNumber { get; set; }

		public int CourseId { get; set; }
		public Course Course { get; set; }
	}
}
