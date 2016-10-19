using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelPeople.Commons.Objects.Booking;
using TravelPeople.DAL.Repositories;

namespace TravelPeople.Service.Controllers
{
    public class SearchHeaderController : GenericController<SearchHeader>
    {

        [AcceptVerbs("POST")]
        [HttpPost]
        public override IHttpActionResult Create([FromBody] SearchHeader model)
        {
            try
            {
                SearchHeaderRepository _repo = new SearchHeaderRepository();
                return Ok(_repo.Insert(model));
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }

    }
}
