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
    public class LeaguesController : Controller
    {
        private SportsSiteContext db = new SportsSiteContext();
        private readonly ILeagueService _leagueService;
        private IUnitOfWork _unitOfWork;
        public LeaguesController(ILeagueService LeagueService, IUnitOfWork unitOfWork)
        {
            _leagueService = LeagueService;
            _unitOfWork = unitOfWork;
        }
        // GET: Leagues
        public async Task<ActionResult> Index()
        {


            return View(await _leagueService.GetAsync());
        }

        // GET: Leagues/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            League league =  _leagueService.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }
            return View(league);
        }

        // GET: Leagues/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            return View();
        }

        // POST: Leagues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,OrganizationId")] League league)
        {
            if (ModelState.IsValid)
            {
                _leagueService.Insert(league);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", league.OrganizationId);
            return View(league);
        }

        // GET: Leagues/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            League league = await _leagueService.FindAsync(id);
            if (league == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", league.OrganizationId);
            return View(league);
        }

        // POST: Leagues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,OrganizationId")] League league)
        {
            if (ModelState.IsValid)
            {
                league.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                _leagueService.Update(league);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", league.OrganizationId);
            return View(league);
        }

        // GET: Leagues/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            League league = _leagueService.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }
            return View(league);
        }

        // POST: Leagues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            League league = await _leagueService.FindAsync(id);
            _leagueService.Delete(league);
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
