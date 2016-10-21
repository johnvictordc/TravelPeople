using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using Newtonsoft.Json;
using PagedList;
using RestSharp;
using TravelPeople.Commons.Objects;
using TravelPeople.Commons.Utils;
using TravelPeople.Web.Factories;
using TravelPeople.Web.Services;

namespace TravelPeople.Web.Controllers
{
	/// <summary>
	/// Description of BlockController.
	/// </summary>
	public class BlockController : BaseController
	{
		private APIService service;

		//
		// GET: /OBT/Company/
		public ActionResult Index(string search = "", int page = 1)
		{
			if (search == null)
			{
				search = "";
				page = 1;
			}

			service = ServiceFactory.API();
			service.SetRequest(APIURL.BLOCK_SEARCH, Method.GET);
			service.request.AddParameter("search", search);
			var response = service.Execute();

			if (response.StatusCode == HttpStatusCode.OK)
			{
				ViewBag.CurrentFilter = search;
				List<Block> result = service.DeserializeResult<List<Block>>(response);
				return View(result.ToPagedList<Block>(page, 10));
			}
			else
			{
				return CustomMessage(response.Content);
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Block model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					service = ServiceFactory.API();
					service.SetRequest(APIURL.BLOCK_CREATE, Method.POST);
					service.request.AddBody(model);
					var response = service.Execute();

					if (response.StatusCode == HttpStatusCode.OK)
					{
						long _id = service.DeserializeResult<long>(response);
						return RedirectToAction("Details", new { id = _id });
					}
					else
					{
						ModelState.AddModelError("", JsonConvert.DeserializeObject<Exception>(response.Content).Message);
					}
				}
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
			}

			return View(model);
		}

		public ActionResult Details(long? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}

			service = ServiceFactory.API();
			service.SetRequest(APIURL.BLOCK_SINGLE, Method.GET);
			service.request.AddParameter("id", id);
			var response = service.Execute();

			if (response.StatusCode == HttpStatusCode.OK)
			{
				return View(service.DeserializeResult<Block>(response));
			}
			else
			{
				return HttpNotFound();
			}
		}

		public ActionResult Edit(long? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}

			service = ServiceFactory.API();
			service.SetRequest(APIURL.BLOCK_SINGLE, Method.GET);
			service.request.AddParameter("id", id);
			var response = service.Execute();

			if (response.StatusCode == HttpStatusCode.OK)
			{
				return View(service.DeserializeResult<Block>(response));
			}
			else
			{
				return HttpNotFound();
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Block model)
		{

			try
			{
				if (ModelState.IsValid)
				{
					service = ServiceFactory.API();
					service.SetRequest(APIURL.BLOCK_UPDATE, Method.POST);
					service.request.AddBody(model);
					var response = service.Execute();

					if (response.StatusCode == HttpStatusCode.OK)
					{
						bool success = service.DeserializeResult<bool>(response);
						if (success == true)
						{
							return RedirectToAction("Details", new { id = model.id });
						}
						else
						{
							ModelState.AddModelError("", "Don't know");
						}
					}
					else
					{
						ModelState.AddModelError("", JsonConvert.DeserializeObject<Exception>(response.Content).Message);
					}
				}
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
			}
			
			return View();
		}

		public ActionResult Delete(long? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}

			service = ServiceFactory.API();
			service.SetRequest(APIURL.BLOCK_SINGLE, Method.GET);
			service.request.AddParameter("id", id);
			var response = service.Execute();

			if (response.StatusCode == HttpStatusCode.OK)
			{
				return View(service.DeserializeResult<Block>(response));
			}
			else
			{
				return HttpNotFound();
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(Block model)
		{

			try
			{
				if (model.id != 0)
				{
					service = ServiceFactory.API();
					service.SetRequest(APIURL.BLOCK_DELETE, Method.POST);
					service.request.AddBody(model.id);
					var response = service.Execute();

					if (response.StatusCode == HttpStatusCode.OK)
					{
						bool result = service.DeserializeResult<bool>(response);
						if (result == true)
						{
							return RedirectToAction("Index");
						}
						else
						{
							return RedirectToAction("Index");
						}
					}
					else
					{
						ModelState.AddModelError("", JsonConvert.DeserializeObject<Exception>(response.Content).Message);
					}
				}
				else
				{
					ModelState.AddModelError("", "ID is required.");
				}
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
			}

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult BatchDelete(IEnumerable<long> id)
		{
			service = ServiceFactory.API();
			service.SetRequest(APIURL.BLOCK_LIST_BY_ID, Method.POST);
			service.request.AddBody(id);
			var response = service.Execute();

			if (response.StatusCode == HttpStatusCode.OK)
			{
				var model = service.DeserializeResult<List<Block>>(response);
				return View(model);
			}
			else
			{
				return RedirectToAction("Index");
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult BatchDeleteConfirm(IEnumerable<long> id)
		{
			service = ServiceFactory.API();
			service.SetRequest(APIURL.BLOCK_BATCH_DELETE, Method.POST);
			service.request.AddBody(id);
			var response = service.Execute();

			if (response.StatusCode == HttpStatusCode.OK)
			{
				return RedirectToAction("Index");
			}
			else
			{
				return RedirectToAction("Index");
			}
		}
	}
}