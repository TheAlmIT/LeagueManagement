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
using System.Web.Configuration;
using System.IO;

namespace LeagueManagement.Controllers
{
    [OverrideAuthentication]
    public class TeamsController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IUnitOfWork _unitOfWork;

        public TeamsController(ITeamService teamService, IUnitOfWork unitOfWork)
        {
            _teamService = teamService;
            _unitOfWork = unitOfWork;
        }
        
        // GET: Teams
        public async Task<ActionResult> Index()
        {
            return View(await _teamService.GetAsync());
        }

        // GET: Teams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var team =  _teamService.Find(id);

            return View(team);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            var team = _teamService.GetTeam();
            ViewBag.OrganizationId = new SelectList(team.Organizations, "Id", "Name");
            return View(team);
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Team team, HttpPostedFileBase file, FormCollection formCollection)
        { 
            if(formCollection.AllKeys.Where(c => c.StartsWith("chk")).ToList().Count == 0)
            {
                ModelState.AddModelError("tm", "Please select Team Members");
            }

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string fileName = new Random().Next().ToString();
                    string folderName = WebConfigurationManager.AppSettings["TeamPhotoFolder"];
                    string folderPath = folderName + "\\" + fileName + Path.GetExtension(file.FileName);
                    string savingPath = Request.PhysicalApplicationPath + folderPath;
                    team.PhotoUrl = Request.ApplicationPath + folderPath;
                    file.SaveAs(savingPath);
                }
                var teamMembers = formCollection.AllKeys.Where(c => c.StartsWith("chk")).ToList();
                _teamService.CreateTeam(team, teamMembers);            
                return RedirectToAction("Index");
            }
            var teams = _teamService.GetTeam();
            ViewBag.OrganizationId = new SelectList(teams.Organizations, "Id", "Name");

            return View(teams);
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int id)
        {
           Team team =  _teamService.Find(id);
            ViewBag.OrganizationId = new SelectList(team.Organizations, "Id", "Name");
            //team.Users = (from u in db.Users
            //              where !(from tm in db.TeamMembers
            //                      select tm.UserId)
            //                      .Contains(u.Id)
            //              select u).ToList();
            //if (team == null)
            //{
            //    return HttpNotFound();
            //}
            //team.TeamMembers = 
            //ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", team.OrganizationId);
            //ViewBag.CreatedBy = new SelectList(db.Users, "Id", "EmailId", team.CreatedBy);
            return View(team);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,OrganizationId,NickName,Description,PhotoUrl,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] Team team, HttpPostedFileBase file,FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                team.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                if (file != null)
                {
                    string fileName = new Random().Next().ToString();
                    string folderName = WebConfigurationManager.AppSettings["TeamPhotoFolder"];
                    string folderPath = folderName + "\\" + fileName + Path.GetExtension(file.FileName);
                    string savingPath = Request.PhysicalApplicationPath + folderPath;
                    team.PhotoUrl = Request.ApplicationPath + folderPath;
                    file.SaveAs(savingPath);
                }
                team.OrganizationId = 1;
                
                var teamMembers = formCollection.AllKeys.Where(c => c.StartsWith("chk")).ToList();
                if(teamMembers.Count > 0)
                {
                    _teamService.UpdateTeam(team, teamMembers);
                }

                _teamService.Update(team);
                _unitOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = await _teamService.FindAsync(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _teamService.Delete(id);
           return RedirectToAction("Index");
        }
    }
}
