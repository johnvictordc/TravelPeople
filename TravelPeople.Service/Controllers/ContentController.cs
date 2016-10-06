using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelPeople.Commons.Interfaces;
using TravelPeople.Commons.Objects;
using TravelPeople.DAL.Repositories;

namespace TravelPeople.Service.Controllers
{
    public class ContentController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
               (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private ContentRepository repo = new ContentRepository();

        [AcceptVerbs("POST")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Content model)
        {
            try
            {
                repo.Create(model);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }

	}
}