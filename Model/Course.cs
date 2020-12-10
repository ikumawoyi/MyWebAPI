using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Model
{
	public class Course
	{
		public int CourseId { get; set; }
		public string Title { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public Levels? Level { get; set; }
		public List<Facilitator> Facilitators { get; set; }

	}
}
