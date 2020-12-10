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
    public class RoomsController : Controller
    {
        private readonly IRoomsRepository rooms;

        public RoomsController(IRoomsRepository roomsRepository)
        {
            this.rooms = roomsRepository;
        }

        // GET: api/<controller>
        [HttpGet("/api/rooms")]
        public IEnumerable<Room> Get()
        {
            return this.rooms.GetRooms();
        }

        // GET api/<controller>/5
        [HttpGet("/api/room/{id}")]
        public IActionResult Get(int id)
        {
            var room = rooms.GetRoom(id);

            if (room == null)
                return NotFound();

            return Ok(room);
        }

        // POST api/<controller>
        [HttpPost("/api/room")]
        public IActionResult Post([FromBody]Room room)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var createdRoom = rooms.AddRoom(room);

            return CreatedAtAction(nameof(Get), new { id = createdRoom.Id }, createdRoom);
        }

        // PUT api/<controller>/5
        [HttpPut("/api/room/{id}")]
        public IActionResult Put(int id, [FromBody]Room room)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            try
            {
                rooms.UpdateRoom(id, room);
                return Ok();
            }
            catch (EntityNotFoundException<Doctor>)
            {
                return NotFound();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("/api/room/{id}")]
        public IActionResult Delete(int id)
        {
            rooms.DeleteRoom(id);
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
