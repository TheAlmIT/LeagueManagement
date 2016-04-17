using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMEntities.Models;

namespace LeagueManagement.Controllers
{
    public class EventsController : Controller
    {
        private SportsSiteContext db = new SportsSiteContext();

        // GET: Events
        public ActionResult Index()
        {
            var events = db.Events.Include(a => a.EventType).Include(a => a.Organization).Include(a => a.Team).Include(a => a.Team1).Include(a => a.User).Include(a => a.User1).Include(a => a.User2);
            return View(events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.TypeId = new SelectList(db.EventTypes, "Id", "Name");
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            ViewBag.HomeTeamId = new SelectList(db.Teams, "Id", "Name");
            ViewBag.VisitorTeamId = new SelectList(db.Teams, "Id", "Name");
            ViewBag.CreatedBy = new SelectList(db.Users, "Id", "EmailId");
            ViewBag.HostId = new SelectList(db.Users, "Id", "EmailId");
            ViewBag.ModifiedBy = new SelectList(db.Users, "Id", "EmailId");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,OrganizationId,HostId,TypeId,StartTime,EndTime,HomeTeamId,VisitorTeamId,ContactPhoneNumber1,ContactPhoneNumber2,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TypeId = new SelectList(db.EventTypes, "Id", "Name", @event.TypeId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", @event.OrganizationId);
            ViewBag.HomeTeamId = new SelectList(db.Teams, "Id", "Name", @event.HomeTeamId);
            ViewBag.VisitorTeamId = new SelectList(db.Teams, "Id", "Name", @event.VisitorTeamId);
            ViewBag.CreatedBy = new SelectList(db.Users, "Id", "EmailId", @event.CreatedBy);
            ViewBag.HostId = new SelectList(db.Users, "Id", "EmailId", @event.HostId);
            ViewBag.ModifiedBy = new SelectList(db.Users, "Id", "EmailId", @event.ModifiedBy);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeId = new SelectList(db.EventTypes, "Id", "Name", @event.TypeId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", @event.OrganizationId);
            ViewBag.HomeTeamId = new SelectList(db.Teams, "Id", "Name", @event.HomeTeamId);
            ViewBag.VisitorTeamId = new SelectList(db.Teams, "Id", "Name", @event.VisitorTeamId);
            ViewBag.CreatedBy = new SelectList(db.Users, "Id", "EmailId", @event.CreatedBy);
            ViewBag.HostId = new SelectList(db.Users, "Id", "EmailId", @event.HostId);
            ViewBag.ModifiedBy = new SelectList(db.Users, "Id", "EmailId", @event.ModifiedBy);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,OrganizationId,HostId,TypeId,StartTime,EndTime,HomeTeamId,VisitorTeamId,ContactPhoneNumber1,ContactPhoneNumber2,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeId = new SelectList(db.EventTypes, "Id", "Name", @event.TypeId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", @event.OrganizationId);
            ViewBag.HomeTeamId = new SelectList(db.Teams, "Id", "Name", @event.HomeTeamId);
            ViewBag.VisitorTeamId = new SelectList(db.Teams, "Id", "Name", @event.VisitorTeamId);
            ViewBag.CreatedBy = new SelectList(db.Users, "Id", "EmailId", @event.CreatedBy);
            ViewBag.HostId = new SelectList(db.Users, "Id", "EmailId", @event.HostId);
            ViewBag.ModifiedBy = new SelectList(db.Users, "Id", "EmailId", @event.ModifiedBy);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
