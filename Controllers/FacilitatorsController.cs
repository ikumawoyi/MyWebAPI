using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebAPI.IProductRepo;
using MyWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FacilitatorsController : ControllerBase
	{
		private IFacilitatorRepository _service;


		public FacilitatorsController(IFacilitatorRepository service)
		{
			_service = service;

		}

		[HttpGet("/api/facilitator/{id}")]
		public Facilitator GetFacilitator(int id)
		{
			return _service.GetFacilitator(id);
		}

		[HttpGet("/api/facilitators")]
		public IEnumerable<Facilitator> GetAllFacilitators()
		{
			return _service.GetAllFacilitators();
		}

		[HttpPost("/api/facilitator")]
		public ActionResult<Facilitator> Add(Facilitator facilitator)
		{
			_service.Add(facilitator);
			return facilitator;
		}

		[HttpPut("/api/facilitator/{id}")]
		public ActionResult<Facilitator> Update(Facilitator facilitator)
		{
			_service.Update(facilitator);
			return facilitator;
		}

		[HttpDelete("/api/facilitator/{id}")]
		public ActionResult<int> Delete(int id)
		{
			_service.Delete(id);
			//_logger.LogInformation("products", _products);
			return id;
		}
	}
}
