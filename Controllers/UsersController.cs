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
    public class UsersController : Controller
    {
        private readonly IUsersRepository users;

        public UsersController(IUsersRepository usersRepository)
        {
            this.users = usersRepository;
        }

        // GET: api/<controller>
        [HttpGet("/api/users")]
        public IEnumerable<User> Get()
        {
            return users.GetUsers();
        }

        // GET api/<controller>/5
        [HttpGet("/api/user/{id}")]
        public IActionResult Get(int id)
        {
            var user = users.GetUser(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST api/<controller>
        [HttpPost("/api/user")]
        public IActionResult Post([FromBody]User user)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var createdUser = users.AddUser(user);

            return CreatedAtAction(nameof(Get), new { id = createdUser.UserId }, createdUser);
        }

        // PUT api/<controller>/5
        [HttpPut("/api/user/{id}")]
        public IActionResult Put(int id, [FromBody]User user)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            try
            {
                users.UpdateUser(id, user);
                return Ok();
            }
            catch (EntityNotFoundException<Doctor>)
            {
                return NotFound();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("/api/user/{id}")]
        public IActionResult Delete(int id)
        {
            users.DeleteUser(id);
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
