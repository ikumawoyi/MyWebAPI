using System;
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
    public class PatientsController : Controller
    {
        private readonly IPatientsRepository patientsRepository;

        public PatientsController(IPatientsRepository patientRepository)
        {
            this.patientsRepository = patientRepository;
        }

		// GET: api/<controller>
		[HttpGet("/api/patients")]
		public IEnumerable<Patient> Get()
        {
            return this.patientsRepository.GetPatients();
        }

		// GET api/<controller>/5
		[HttpGet("/api/patient/{id}")]
		public Patient Get(int id)
        {
            return this.patientsRepository.GetPatient(id);
        }

		// POST api/<controller>
		[HttpPost("/api/patient")]
		public Patient Post([FromBody]Patient value)
        {
            return this.patientsRepository.AddPatient(value);
        }


        // PUT api/<controller>/5
        [HttpPut("/api/patient/{id}")]
        public void Put(int id, [FromBody]Patient value)
        {
            this.patientsRepository.UpdatePatient(id, value);
        }

        // DELETE api/<controller>/5
        [HttpDelete("/api/patient/{id}")]
        public void Delete(int id)
        {
            this.patientsRepository.DeletePatient(id);
        }

        [HttpGet("/api/patient/{id}/admit")]
        public void AdmitToHospital(int id)
        {
            this.patientsRepository.AdmitToHospital(id);
        }

        [HttpGet("/api/patient/{id}/discharge")]
        public void DischargeFromHospital(int id)
        {
            this.patientsRepository.DischargeFromHospital(id);
        }

        [AcceptVerbs("OPTIONS")]
        public HttpResponseMessage Options()
        {
            var x = Ok();
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Headers.Add("Access-Control-Allow-Origin", "*");
            resp.Headers.Add("Access-Control-Allow-Methods", "GET,POST,PUT,DELETE");
            return resp;

            //return Ok();
        }
    }
}
