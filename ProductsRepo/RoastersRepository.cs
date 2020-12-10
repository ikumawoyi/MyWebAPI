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
	public class RoastersRepository : IRoastersRepository
	{
		private readonly AppDbContext db;

		public RoastersRepository(AppDbContext db)
		{
			this.db = db;
		}
		public Roaster AddRoaster(Roaster roaster)
		{
			roaster.Id = db.Roasters.Count();

			db.Roasters.Add(roaster);

			db.SaveChanges();

			return roaster;
		}

		public Roaster DeleteRoaster(int id)
		{
			var roaster = GetRoaster(id);
			db.Remove(roaster);
			db.SaveChanges();
			return roaster;
		}

		public IEnumerable<Doctor> GetDoctors(int id)
		{
			var roaster = GetRoaster(id);

			if (roaster == null)
				throw new EntityNotFoundException<Roaster>(id);

			return db.Doctors.Where(p => p.RoasterId == id);
		}

		public Roaster GetRoaster(int id)
		{
			return db.Roasters.Find(id);
		}

		public IEnumerable<Roaster> GetRoasters()
		{
			return db.Roasters.AsNoTracking().ToList();
		}

		public Roaster UpdateRoaster(int id, Roaster updatedRoaster)
		{
			var roaster = GetRoaster(id);

			if (roaster == null)
				throw new EntityNotFoundException<Roaster>(id);

			roaster.Date = updatedRoaster.Date;
			roaster.Doctors = updatedRoaster.Doctors;
			roaster.Nurses = updatedRoaster.Nurses;

			db.SaveChanges();
			return updatedRoaster;
		}
	}
}
