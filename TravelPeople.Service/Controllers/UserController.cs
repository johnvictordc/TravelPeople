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
    public class UserController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
               (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private UserRepository repo = new UserRepository();

        [AcceptVerbs("POST")]
        [HttpPost]
        public IHttpActionResult Login([FromBody] User model)
        {
            try
            {
                return Ok(repo.Login(model));
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
    }
}