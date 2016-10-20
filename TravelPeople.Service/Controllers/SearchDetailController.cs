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
    public class SearchDetailController : GenericController<SearchDetail>
    {
        [AcceptVerbs("POST")]
        [HttpPost]
        public override IHttpActionResult Create([FromBody] SearchDetail model)
        {
            try
            {
                SearchDetailsRepository _repo = new SearchDetailsRepository();
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
