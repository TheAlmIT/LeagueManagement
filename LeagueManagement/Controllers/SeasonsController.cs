using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMEntities.Models;
using Repository.Pattern.UnitOfWork;
using LMService;

namespace LeagueManagement.Controllers
{
    public class SeasonsController : Controller
    {
        private SportsSiteContext db = new SportsSiteContext();
        private readonly ISeasonService _SeasonService;
        private IUnitOfWork _unitOfWork;
        public SeasonsController(ISeasonService ScheduleService, IUnitOfWork unitOfWork)
        {
            _SeasonService = ScheduleService;
            _unitOfWork = unitOfWork;
        }
        // GET: Seasons
        public async Task<ActionResult> Index()
        {
            return View(await _SeasonService.GetAsync());
        }

        // GET: Seasons/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season = await _SeasonService.FindAsync(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        // GET: Seasons/Create
        public ActionResult Create()
        {
            ViewBag.LeagueId = new SelectList(db.Leagues, "Id", "Name");
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            return View();
        }

        // POST: Seasons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,LeagueId,OrganizationId")] Season season)
        {
            if (ModelState.IsValid)
            {
                _SeasonService.Insert(season);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LeagueId = new SelectList(db.Leagues, "Id", "Name", season.LeagueId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", season.OrganizationId);
            return View(season);
        }

        // GET: Seasons/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season = await _SeasonService.FindAsync(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            ViewBag.LeagueId = new SelectList(db.Leagues, "Id", "Name", season.LeagueId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", season.OrganizationId);
            return View(season);
        }

        // POST: Seasons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,LeagueId,OrganizationId")] Season season)
        {
            if (ModelState.IsValid)
            {
                season.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                _SeasonService.Update(season);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LeagueId = new SelectList(db.Leagues, "Id", "Name", season.LeagueId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", season.OrganizationId);
            return View(season);
        }

        // GET: Seasons/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season = await _SeasonService.FindAsync(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        // POST: Seasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Season season = await _SeasonService.FindAsync(id);
            _SeasonService.Delete(season);
            _unitOfWork.SaveChanges();
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
