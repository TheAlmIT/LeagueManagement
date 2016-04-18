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
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;
namespace LeagueManagement.Controllers
{
    public class SkillSpecialitiesController : Controller
    {
        private readonly ISkillSpecialityService _skillSpecialityService;
        private readonly IUnitOfWork _unitOfWork;
        public SkillSpecialitiesController(ISkillSpecialityService skillSpecialityService, IUnitOfWork unitOfWork)
        {
            _skillSpecialityService = skillSpecialityService;
            _unitOfWork = unitOfWork;
        }

        // GET: SkillSpecialities
        public async Task<ActionResult> Index()
        {
            return View(await _skillSpecialityService.GetAsync());
        }

        // GET: SkillSpecialities/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillSpeciality skillSpeciality = await _skillSpecialityService.FindAsync(id);
            if (skillSpeciality == null)
            {
                return HttpNotFound();
            }
            return View(skillSpeciality);
        }

        // GET: SkillSpecialities/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationId = new SelectList(_skillSpecialityService.Organizations, "Id", "Name");
            ViewBag.CreatedBy = new SelectList(_skillSpecialityService.Users, "Id", "EmailId");
            return View();
        }

        // POST: SkillSpecialities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,OrganizationId,Name,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] SkillSpeciality skillSpeciality)
        {
            if (ModelState.IsValid)
            {
                _skillSpecialityService.Insert(skillSpeciality);
                 _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skillSpeciality);
        }

        // GET: SkillSpecialities/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillSpeciality skillSpeciality = await _skillSpecialityService.FindAsync(id);
            if (skillSpeciality == null)
            {
                return HttpNotFound();
            }
            return View(skillSpeciality);
        }

        // POST: SkillSpecialities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,OrganizationId,Name,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] SkillSpeciality skillSpeciality)
        {
            if (ModelState.IsValid)
            {
                skillSpeciality.ObjectState = ObjectState.Modified;
                _skillSpecialityService.Update(skillSpeciality);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skillSpeciality);
        }

        // GET: SkillSpecialities/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillSpeciality skillSpeciality = await _skillSpecialityService.FindAsync(id);
            if (skillSpeciality == null)
            {
                return HttpNotFound();
            }
            return View(skillSpeciality);
        }

        // POST: SkillSpecialities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SkillSpeciality skillSpeciality = await _skillSpecialityService.FindAsync(id);
            _skillSpecialityService.Delete(skillSpeciality);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
