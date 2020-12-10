using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebAPI.IProductRepo;
using MyWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EmployeesController : ControllerBase
	{

		private ILogger _logger;
		private IEmployeeRepository _service;


		public EmployeesController(ILogger<ProductsController> logger, IEmployeeRepository service)
		{
			_logger = logger;
			_service = service;

		}

		[HttpGet("/api/employee/{id}")]
		public Employee GetEmployee(int id)
		{
			return _service.GetEmployee(id);
		}

		[HttpGet("/api/employees")]
		public IEnumerable<Employee> GetAllEmployees()
		{
			return _service.GetAllEmployees();
		}

		[HttpPost("/api/employee")]
		public ActionResult<Employee> Add(Employee employee)
		{
			_service.Add(employee);
			return employee;
		}

		[HttpPut("/api/employee/{id}")]
		public ActionResult<Employee> Update(Employee employee)
		{
			_service.Update(employee);
			return employee;
		}

		[HttpDelete("/api/employee/{id}")]
		public ActionResult<int> Delete(int id)
		{
			_service.Delete(id);
			//_logger.LogInformation("products", _products);
			return id;
		}
	}
}
