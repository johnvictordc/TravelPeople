using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelPeople.Web.Models.Nodes;
using TravelPeople.Web.Models;

namespace TravelPeople.Web.Areas.CMS.Controllers
{
    public class SampleContentController : Controller
    {
        private TravelPeopleWebContext db = new TravelPeopleWebContext();

        // GET: /CMS/SampleContent/
        public ActionResult Index()
        {
            return View(db.ContentViewModels.ToList());
        }

        // GET: /CMS/SampleContent/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentViewModel contentviewmodel = db.ContentViewModels.Find(id);
            if (contentviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(contentviewmodel);
        }

        // GET: /CMS/SampleContent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CMS/SampleContent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,enabled,content,type,alias,meta_description,meta_tags,date_created,date_updated,created_by,updated_by")] ContentViewModel contentviewmodel)
        {
            if (ModelState.IsValid)
            {
                db.ContentViewModels.Add(contentviewmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contentviewmodel);
        }

        // GET: /CMS/SampleContent/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentViewModel contentviewmodel = db.ContentViewModels.Find(id);
            if (contentviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(contentviewmodel);
        }

        // POST: /CMS/SampleContent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,enabled,content,type,alias,meta_description,meta_tags,date_created,date_updated,created_by,updated_by")] ContentViewModel contentviewmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contentviewmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contentviewmodel);
        }

        // GET: /CMS/SampleContent/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentViewModel contentviewmodel = db.ContentViewModels.Find(id);
            if (contentviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(contentviewmodel);
        }

        // POST: /CMS/SampleContent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ContentViewModel contentviewmodel = db.ContentViewModels.Find(id);
            db.ContentViewModels.Remove(contentviewmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
