﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HospitalManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using MyHospitalManagement.Models;
using MyWebAPI.Models;
using MyWebAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NursesController : Controller
    {
        private readonly INursesRepository nurses;

        public NursesController(INursesRepository nursesRepository)
        {
            this.nurses = nursesRepository;
        }

		// GET: api/<controller>
		[HttpGet("/api/nurses")]
		public IEnumerable<Nurse> Get()
        {
            return this.nurses.GetNurses();
        }

		// GET api/<controller>/5
		[HttpGet("/api/nurse/{id}")]
		public IActionResult Get(int id)
        {
            var nurse = nurses.GetNurse(id);

            if (nurse == null)
                return NotFound();

            return Ok(nurse);
        }

		// POST api/<controller>
		[HttpPost("/api/nurse")]
		public IActionResult Post([FromBody]Nurse nurse)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var createdNurse = nurses.AddNurse(nurse);

            return CreatedAtAction(nameof(Get), new { id = createdNurse.Id }, createdNurse);
        }

		// PUT api/<controller>/5
		[HttpPut("/api/nurse/{id}")]
		public IActionResult Put(int id, [FromBody]Nurse nurse)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            try
            {
                nurses.UpdateNurse(id, nurse);
                return Ok();
            }
            catch (EntityNotFoundException<Doctor>)
            {
                return NotFound();
            }
        }

		// DELETE api/<controller>/5
		[HttpDelete("/api/nurse/{id}")]
		public IActionResult Delete(int id)
        {
            nurses.DeleteNurse(id);
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
