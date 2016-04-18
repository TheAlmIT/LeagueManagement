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
using LMService;
using Repository.Pattern.UnitOfWork;

namespace LeagueManagement.Controllers
{
    public class TeamTitlesController : Controller
    {
        private readonly ITeamTitleService _teamtitleService;
        private readonly IUnitOfWork _unitOfWork;
        public TeamTitlesController(ITeamTitleService teamtitleService, IUnitOfWork unitOfWork)
        {
            _teamtitleService = teamtitleService;
            _unitOfWork = unitOfWork;
        }
      
        // GET: TeamTitles
        public async Task<ActionResult> Index()
        {

            return View(await _teamtitleService.GetAsync());
        }

        // GET: TeamTitles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamTitle teamTitle = await _teamtitleService.FindAsync(id);
            if (teamTitle == null)
            {
                return HttpNotFound();
            }
            return View(teamTitle);
        }

        // GET: TeamTitles/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationId = new SelectList(_teamtitleService.Organizations, "Id", "Name");
            ViewBag.CreatedBy = new SelectList(_teamtitleService.Users, "Id", "EmailId");
            return View();
        }

        // POST: TeamTitles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,OrganizationId,Name,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] TeamTitle teamTitle)
        {
            if (ModelState.IsValid)
            {
                _teamtitleService.Insert(teamTitle);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teamTitle);
        }

        // GET: TeamTitles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamTitle teamTitle = await _teamtitleService.FindAsync(id);
            if (teamTitle == null)
            {
                return HttpNotFound();
            }
            return View(teamTitle);
        }

        // POST: TeamTitles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,OrganizationId,Name,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] TeamTitle teamTitle)
        {
            if (ModelState.IsValid)
            {
                teamTitle.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                _teamtitleService.Update(teamTitle);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teamTitle);
        }

        // GET: TeamTitles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamTitle teamTitle = await _teamtitleService.FindAsync(id);
            if (teamTitle == null)
            {
                return HttpNotFound();
            }
            return View(teamTitle);
        }

        // POST: TeamTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TeamTitle teamTitle = await _teamtitleService.FindAsync(id);
            _teamtitleService.Delete(teamTitle);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
