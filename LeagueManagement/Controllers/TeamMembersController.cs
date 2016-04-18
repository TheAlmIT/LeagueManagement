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
using Microsoft.AspNet.Identity;
using System.Web.Configuration;
using System.IO;

namespace LeagueManagement.Controllers
{
    public class TeamMembersController : Controller
    {
        private readonly ITeamMemeberService _teamMemeberService;
        private readonly IUnitOfWork _unitOfWork;

        public TeamMembersController(ITeamMemeberService teamMemberService, IUnitOfWork unitOfWork)
        {
            _teamMemeberService = teamMemberService;
            _unitOfWork = unitOfWork;
        }

        // GET: TeamMembers
        public async Task<ActionResult> Index()
        {
            //  var teamMembers = db.TeamMembers.Include(t => t.SkillSpeciality).Include(t => t.Team);
            return View(await _teamMemeberService.GetAsync());
        }

        // GET: TeamMembers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember teamMember = await _teamMemeberService.FindAsync(id);
            if (teamMember == null)
            {
                return HttpNotFound();
            }
            return View(teamMember);
        }

        // GET: TeamMembers/Create
        public ActionResult Create()
        {
            ViewBag.SkillSpecialityId = new SelectList(_teamMemeberService.SkillSpecialities, "Id", "Name");
            ViewBag.TeamId = new SelectList(_teamMemeberService.Teams, "Id", "Name");
            return View();
        }

        // POST: TeamMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TeamMember teamMember)
        {
            if (ModelState.IsValid)
            {
                _teamMemeberService.Insert(teamMember);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.SkillSpecialityId = new SelectList(db.SkillSpecialities, "Id", "Name", teamMember.SkillSpecialityId);
            ViewBag.TeamId = new SelectList(_teamMemeberService.Teams, "Id", "Name", teamMember.TeamId);
            return View(teamMember);
        }

        // GET: TeamMembers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember teamMember = await _teamMemeberService.FindAsync(id);

            var userId = User.Identity.GetUserId();



            if (teamMember == null)
            {
                return HttpNotFound();
            }
            //ViewBag.SkillSpecialityId = new SelectList(db.SkillSpecialities, "Id", "Name", teamMember.SkillSpecialityId);
            ViewBag.TeamId = new SelectList(_teamMemeberService.Teams, "Id", "Name", teamMember.TeamId);
            return View(teamMember);
        }

        // POST: TeamMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TeamMember teamMember)
        {
            if (ModelState.IsValid)
            {
                teamMember.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                _teamMemeberService.Update(teamMember);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.SkillSpecialityId = new SelectList(db.SkillSpecialities, "Id", "Name", teamMember.SkillSpecialityId);
            ViewBag.TeamId = new SelectList(_teamMemeberService.Teams, "Id", "Name", teamMember.TeamId);
            return View(teamMember);
        }

        // GET: TeamMembers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember teamMember = await _teamMemeberService.FindAsync(id);
            if (teamMember == null)
            {
                return HttpNotFound();
            }
            return View(teamMember);
        }

        // POST: TeamMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TeamMember teamMember = await _teamMemeberService.FindAsync(id);
            _teamMemeberService.Delete(teamMember);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
