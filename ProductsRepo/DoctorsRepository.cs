//using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagementSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using MyHospitalManagement.Models;
using MyWebAPI.Model;
using MyWebAPI.Models;

namespace MyWebAPI.Repositories
{
    public class DoctorsRepository : IDoctorsRepository
    {

		private readonly AppDbContext db;

		public DoctorsRepository(AppDbContext db)
		{
			this.db = db;
		}

        public Doctor AddDoctor(Doctor doctor)
        {
           // doctor.Id = db.Doctors.Count();
			doctor.IsActive = true;
			doctor.IsAssigned = false;
			doctor.IsOnDuty = false;

            db.Doctors.Add(doctor);

            db.SaveChanges();

            return doctor;
        }


        public Doctor DeleteDoctor(int id)
        {
            var doctor = GetDoctor(id);
			doctor.IsActive = false;
			if (doctor != null)
            {
                foreach (var patient in db.Patients.Where(p => p.DoctorId == id))
                {
                    patient.DoctorId = null;
                    patient.Doctor = null;
                }
                db.SaveChanges();
            }
			return doctor;
        }

        public Doctor GetDoctor(int id)
        {
            return db.Doctors.Find(id);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return db.Doctors.AsNoTracking().ToList();
        }

        public IEnumerable<Patient> GetPatients(int id)
        {
            var doctor = GetDoctor(id);

            if (doctor == null)
                throw new EntityNotFoundException<Doctor>(id);

            return db.Patients.Where(p => p.DoctorId == id);
        }

        public Doctor UpdateDoctor(int id, Doctor updatedDoctor)
        {
            var doctor = GetDoctor(id);

            if (doctor == null)
                throw new EntityNotFoundException<Doctor>(id);

            doctor.Name = updatedDoctor.Name;
           
            db.SaveChanges();
			return updatedDoctor;

		}
        
    }
}