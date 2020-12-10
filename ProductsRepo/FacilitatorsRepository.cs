using MyWebAPI.IProductRepo;
using MyWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.ProductsRepo
{
	public class FacilitatorsRepository : IFacilitatorRepository

	{
		private readonly AppDbContext context;

		public FacilitatorsRepository(AppDbContext context)
		{
			this.context = context;
		}

		public Facilitator Add(Facilitator facilitator)
		{
			context.Facilitators.Add(facilitator);
			context.SaveChanges();
			return facilitator;
		}

		public Facilitator Delete(int id)
		{
			Facilitator facilitator = context.Facilitators.Find(id);
			if (facilitator != null)
			{
				context.Facilitators.Remove(facilitator);
				context.SaveChanges();
			}
			return facilitator;
		}

		public IEnumerable<Facilitator> GetAllFacilitators()
		{
			return context.Facilitators;
		}

		public Facilitator GetFacilitator(int Id)
		{
			return context.Facilitators.Find(Id);
		}

		public Facilitator Update(Facilitator facilitatorChanges)
		{
			var facilitator = context.Facilitators.Attach(facilitatorChanges);
			facilitator.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			context.SaveChanges();
			return facilitatorChanges;
		}
	}
}
