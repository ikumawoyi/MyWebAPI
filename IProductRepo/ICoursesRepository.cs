using MyWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.IProductRepo
{
	public interface ICoursesRepository
	{
		Course GetCourse(int Id);
		IEnumerable<Course> GetAllCourses();
		Course Add(Course course);
		Course Update(Course courseChanges);
		Course Delete(int id);
	}
}
