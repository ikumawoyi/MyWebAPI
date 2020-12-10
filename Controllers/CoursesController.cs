using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.IProductRepo;
using MyWebAPI.Model;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
		private ICoursesRepository _service;


		public CoursesController(ICoursesRepository service)
		{
			_service = service;

		}

		[HttpGet("/api/course/{id}")]
		public Course GetCourse(int id)
		{
			return _service.GetCourse(id);
		}

		[HttpGet("/api/courses")]
		public IEnumerable<Course> GetAllCourses()
		{
			return _service.GetAllCourses();
		}

		[HttpPost("/api/course")]
		public ActionResult<Course> Add(Course course)
		{
			_service.Add(course);
			return course;
		}

		[HttpPut("/api/course/{id}")]
		public ActionResult<Course> Update(Course course)
		{
			_service.Update(course);
			return course;
		}

		[HttpDelete("/api/course/{id}")]
		public ActionResult<int> Delete(int id)
		{
			_service.Delete(id);
			//_logger.LogInformation("products", _products);
			return id;
		}
	}
}