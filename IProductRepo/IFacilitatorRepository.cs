using MyWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.IProductRepo
{
	public interface IFacilitatorRepository
	{
		Facilitator GetFacilitator(int Id);
		IEnumerable<Facilitator> GetAllFacilitators();
		Facilitator Add(Facilitator facilitator);
		Facilitator Update(Facilitator facilitatorChanges);
		Facilitator Delete(int id);
	}
}
