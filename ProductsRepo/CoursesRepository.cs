using MyWebAPI.IProductRepo;
using MyWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.ProductsRepo
{
	public class CoursesRepository : ICoursesRepository
	{
		private readonly AppDbContext context;

		public CoursesRepository(AppDbContext context)
		{
			this.context = context;
		}

		public Course Add(Course course)
		{
			context.Courses.Add(course);
			context.SaveChanges();
			return course;
		}

		public Course Delete(int id)
		{
			Course course = context.Courses.Find(id);
			if (course != null)
			{
				context.Courses.Remove(course);
				context.SaveChanges();
			}
			return course;
		}

		public IEnumerable<Course> GetAllCourses()
		{
			return context.Courses;
		}

		public Course GetCourse(int Id)
		{
			return context.Courses.Find(Id);
		}

		public Course Update(Course courseChanges)
		{
			var course = context.Courses.Attach(courseChanges);
			course.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			context.SaveChanges();
			return courseChanges;
		}
	}

}
