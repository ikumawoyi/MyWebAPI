using HospitalManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.IProductRepo;
using MyWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyWebAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AppointmentsController : Controller
	{
		private readonly IAppointmentsRepository appointments;

		public AppointmentsController(IAppointmentsRepository appointmentsRepository)
		{
			this.appointments = appointmentsRepository;
		}

		// GET: api/<controller>
		[HttpGet("/api/appointments")]
		public IEnumerable<Appointment> Get()
		{
			return this.appointments.GetAppointments();
		}

		// GET api/<controller>/5
		[HttpGet("/api/appointment/{id}")]
		public Appointment Get(int id)
		{
			return appointments.GetAppointment(id);

		}


		//// GET api/<controller>/5
		//[HttpGet("/api/patients/{id}")]
		//public IActionResult GetPatients(int id)
		//{
		//	var doctor = doctors.GetDoctor(id);

		//	if (doctor == null)
		//		return NotFound();

		//	var patients = doctors.GetPatients(id);

		//	return Ok(patients);
		//}


		// POST api/<controller>
		[HttpPost("/api/appointment")]
		public IActionResult Post([FromBody]Appointment appointment)
		{
			if (ModelState.IsValid == false)
				return BadRequest(ModelState);

			var createdAppointment = appointments.AddAppointment(appointment);

			return CreatedAtAction(nameof(Get), new { id = createdAppointment.Id }, createdAppointment);
		}

		// PUT api/<controller>/5
		[HttpPut("/api/appointment/{id}")]
		public IActionResult Put(int id, [FromBody]Appointment appointment)
		{
			if (ModelState.IsValid == false)
				return BadRequest(ModelState);

			try
			{
				appointments.UpdateAppointment(id, appointment);
				return Ok();
			}
			catch (EntityNotFoundException<Appointment>)
			{
				return NotFound();
			}
		}

		// DELETE api/<controller>/5
		[HttpDelete("/api/appointment/{id}")]
		public IActionResult Delete(int id)
		{
			appointments.DeleteAppointment(id);
			return Ok();
		}

		[AcceptVerbs("OPTIONS")]
		public HttpResponseMessage Options()
		{
			var resp = new HttpResponseMessage(HttpStatusCode.OK);
			resp.Headers.Add("Access-Control-Allow-Origin", "*");
			resp.Headers.Add("Access-Control-Allow-Methods", "GET,POST,PUT,DELETE");
			return resp;

			//return Ok();
		}
	}
}
