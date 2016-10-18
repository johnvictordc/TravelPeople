using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelPeople.DAL.Repositories;

namespace TravelPeople.Service.Controllers
{
    public class GenericController<T> : ApiController where T : class
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger
               (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private GenericRepository<T> repo = new GenericRepository<T>();

        [AcceptVerbs("POST")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] T model)
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
        public IHttpActionResult Update([FromBody] T model)
        {
            try
            {
                return Ok(repo.Update(model));
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
