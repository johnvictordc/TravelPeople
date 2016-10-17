using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelPeople.Commons.Objects;
using TravelPeople.DAL.Repositories;

namespace TravelPeople.Service.Controllers
{
    public class CompanyController : GenericController<Company>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
               (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private CompanyRepository repo = new CompanyRepository();

        //[AcceptVerbs("POST")]
        //[HttpPost]
        //public IHttpActionResult Create([FromBody] Company model)
        //{
        //    try
        //    {
        //        return Ok(repo.Insert(model));
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error", ex);
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[AcceptVerbs("POST")]
        //[HttpPost]
        //public IHttpActionResult Update([FromBody] Company model)
        //{
        //    try
        //    {
        //        repo.Update(model);
        //        return Ok(model.companyID);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error", ex);
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[AcceptVerbs("POST")]
        //[HttpPost]
        //public IHttpActionResult Delete([FromBody] long id)
        //{
        //    try
        //    {
        //        return Ok(repo.Delete(id));
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error", ex);
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[AcceptVerbs("GET")]
        //[HttpGet]
        //public IHttpActionResult GetAll()
        //{
        //    try
        //    {
        //        return Ok(repo.GetAll());
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error", ex);
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[AcceptVerbs("GET")]
        //[HttpGet]
        //public IHttpActionResult GetSingle(long id)
        //{
        //    try
        //    {
        //        return Ok(repo.GetByID(id));
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error", ex);
        //        return BadRequest(ex.Message);
        //    }
        //}

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