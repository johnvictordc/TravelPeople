using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TravelPeople.Commons.Objects;
using TravelPeople.DAL.Repositories;

namespace TravelPeople.Service.Controllers
{
    public class VisaController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
               (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private VisaRepository repo = new VisaRepository();

        [AcceptVerbs("POST")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Visa model)
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
        public IHttpActionResult Update([FromBody] Visa model)
        {
            try
            {
                repo.Update(model);
                return Ok(model.visaID);
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
    }
}