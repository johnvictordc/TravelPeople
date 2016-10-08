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
    public class MenuController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
               (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private MenuRepository repo = new MenuRepository();

        #region MENU
        [AcceptVerbs("POST")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Menu model)
        {
            try
            {
                return Ok(repo.Add(model));
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        public IHttpActionResult Update([FromBody] Menu model)
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
        public IHttpActionResult Delete(long id)
        {
            try
            {
                repo.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        public IHttpActionResult Delete(long[] id)
        {
            try
            {
                repo.Delete(id);
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
        public IHttpActionResult GetAll(bool withItems)
        {
            try
            {
                return Ok(repo.GetAll(withItems));
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        public IHttpActionResult GetByPosition(long id)
        {
            try
            {
                return Ok(repo.GetByPosition(id));
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        public IHttpActionResult GetByPosition(long id, bool withItems)
        {
            try
            {
                return Ok(repo.GetByPosition(id, withItems));
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        public IHttpActionResult GetById(long id)
        {
            try
            {
                return Ok(repo.GetById(id));
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        public IHttpActionResult GetById(long id, bool withItems)
        {
            try
            {
                return Ok(repo.GetById(id, withItems));
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        public IHttpActionResult GetByAlias(string alias)
        {
            try
            {
                return Ok(repo.GetByAlias(alias));
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        public IHttpActionResult GetByAlias(string alias, bool withItems)
        {
            try
            {
                return Ok(repo.GetByAlias(alias, withItems));
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region MENU ITEMS
        [AcceptVerbs("POST")]
        [HttpPost]
        public IHttpActionResult CreateItem([FromBody] MenuItem model)
        {
            try
            {
                return Ok(repo.AddItem(model));
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        public IHttpActionResult UpdateItem([FromBody] MenuItem model)
        {
            try
            {
                return Ok(repo.UpdateItem(model));
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        public IHttpActionResult DeleteItem(long id)
        {
            try
            {
                repo.DeleteItem(id);
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        public IHttpActionResult DeleteItem(long[] id)
        {
            try
            {
                repo.DeleteItems(id);
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
        public IHttpActionResult GetItems(long menu)
        {
            try
            {
                return Ok(repo.GetItems(menu));
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                return BadRequest(ex.Message);
            }
        }
        #endregion

    }
}
