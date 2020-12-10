using Microsoft.EntityFrameworkCore;
using MyHospitalManagement.Models;
using MyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Model
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Nurse> Nurses { get; set; }
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<Patient> Patients { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Appointment> Appointments { get; set; }
		public DbSet<Roaster> Roasters { get; set; }
		public DbSet<Facilitator> Facilitators { get; set; }
		public DbSet<Course> Courses { get; set; }

	}
}
