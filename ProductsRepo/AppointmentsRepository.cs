using HospitalManagementSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using MyHospitalManagement.Models;
using MyWebAPI.IProductRepo;
using MyWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.ProductsRepo
{
	public class AppointmentsRepository : IAppointmentsRepository
	{
		private readonly AppDbContext db;

		public AppointmentsRepository(AppDbContext db)
		{
			this.db = db;
		}
		public Appointment AddAppointment(Appointment appointment)
		{
			appointment.Id = db.Appointments.Count();

			db.Appointments.Add(appointment);

			db.SaveChanges();

			return appointment;
		}

		public Appointment DeleteAppointment(int id)
		{
			var appointment = GetAppointment(id);
			db.Remove(appointment);
			db.SaveChanges();
			return appointment;
		}

		public Appointment GetAppointment(int id)
		{
			return db.Appointments.Find(id);
		}

		public IEnumerable<Appointment> GetAppointments()
		{
			return db.Appointments.AsNoTracking().ToList();
		}

		public IEnumerable<Doctor> GetUnAssignedDoctors(int id)
		{
			var unAssigned = db.Doctors.Where(d => d.IsAssigned == false).ToList();
			return unAssigned;
		}
		public IEnumerable<Doctor> GetOndutyDoctors(int id)
		{
			var NotOnduty = db.Doctors.Where(d => d.IsOnDuty == false).ToList();
			return NotOnduty;
		}

		public Appointment UpdateAppointment(int id, Appointment updatedAppointment)
		{
			var appointment = GetAppointment(id);

			if (appointment == null)
				throw new EntityNotFoundException<Appointment>(id);

			appointment.Date = updatedAppointment.Date;
			appointment.Doctors = updatedAppointment.Doctors;
			appointment.Description = updatedAppointment.Description;

			db.SaveChanges();
			return updatedAppointment;
		}
	}
}
