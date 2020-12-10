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
	public class RoastersController : Controller
	{
		private readonly IRoastersRepository roasters;

		public RoastersController(IRoastersRepository roasterRepository)
		{
			this.roasters = roasterRepository;
		}

		// GET: api/<controller>
		[HttpGet("/api/roasters")]
		public IEnumerable<Roaster> Get()
		{
			return this.roasters.GetRoasters();
		}

		// GET api/<controller>/5
		[HttpGet("/api/roaster/{id}")]
		public Roaster Get(int id)
		{
			return roasters.GetRoaster(id);

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
		[HttpPost("/api/roaster")]
		public IActionResult Post([FromBody]Roaster roaster)
		{
			if (ModelState.IsValid == false)
				return BadRequest(ModelState);

			var createdRoaster = roasters.AddRoaster(roaster);

			return CreatedAtAction(nameof(Get), new { id = createdRoaster.Id }, createdRoaster);
		}

		// PUT api/<controller>/5
		[HttpPut("/api/roaster/{id}")]
		public IActionResult Put(int id, [FromBody]Roaster roaster)
		{
			if (ModelState.IsValid == false)
				return BadRequest(ModelState);

			try
			{
				roasters.UpdateRoaster(id, roaster);
				return Ok();
			}
			catch (EntityNotFoundException<Appointment>)
			{
				return NotFound();
			}
		}

		// DELETE api/<controller>/5
		[HttpDelete("/api/roaster/{id}")]
		public IActionResult Delete(int id)
		{
			roasters.DeleteRoaster(id);
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
