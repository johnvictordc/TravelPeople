using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TravelPeople.Commons.Objects;
using TravelPeople.DAL.Repositories;

namespace TravelPeople.Service.Controllers
{
    public class TravelerController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
               (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private TravelerRepository repo = new TravelerRepository();

        [AcceptVerbs("POST")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Traveler model)
        {
            try
            {
                return Ok(repo.Insert(model));
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        public IHttpActionResult Update([FromBody] Traveler model)
        {
            try
            {
                repo.Update(model);
                return Ok(model.travelID);
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        public IHttpActionResult Delete([FromBody] long id)
        {
            try
            {
                return Ok(repo.Delete(id));
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(repo.GetAll());
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        public IHttpActionResult GetSingle(long id)
        {
            try
            {
                return Ok(repo.GetByID(id));
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        public IHttpActionResult GetSingleWithPassportVisa(int id)
        {
            try
            {
                return Ok(repo.GetWithPassportVisa(id));
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