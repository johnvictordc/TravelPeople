using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelPeople.Commons.Objects;
using TravelPeople.DAL.Repositories;
using TravelPeople.Service.Controllers;

namespace TravelPeople.Service.Controllers
{
	/// <summary>
	/// Description of SliderController.
	/// </summary>
	public class SliderController : GenericController<Block>
	{
		public SliderRepository repo = new SliderRepository();
		
		[AcceptVerbs("POST")]
		[HttpPost]
		public IHttpActionResult GetListByIDs(IEnumerable<long> id)
		{
			try
			{
				return Ok(repo.GetByIDs(id));
			}
			catch (Exception ex)
			{
				log.Error("Error", ex);
				return BadRequest(ex.Message);
			}
		}
		
		[AcceptVerbs("POST")]
        [HttpPost]
        public IHttpActionResult BatchDelete([FromBody] IEnumerable<long> id)
        {
            try
            {
                repo.BatchDelete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }

		[AcceptVerbs("GET")]
		[HttpGet]
		public IHttpActionResult Search(string search)
		{
			try
			{
				return Ok(repo.Search(search));
			}
			catch (Exception ex)
			{
				log.Error("Error", ex);
				return BadRequest(ex.Message);
			}
		}
	}
}