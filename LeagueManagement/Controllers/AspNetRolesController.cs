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
    public class AspNetRolesController : Controller
    {
        private SportsSiteContext db = new SportsSiteContext();
        private readonly IAspNetRoleService _aspNetRoleService;
        private IUnitOfWork _unitOfWork;
        public AspNetRolesController (IAspNetRoleService AspNetRoleService, IUnitOfWork unitOfWork)
        {
            _aspNetRoleService = AspNetRoleService;
            _unitOfWork = unitOfWork;
        }

        // GET: AspNetRoles
        public async Task<ActionResult> Index()
        {
            return View(await _aspNetRoleService.GetAsync());
        }

        // GET: AspNetRoles/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRole aspNetRole = await _aspNetRoleService.FindAsync(id);
            if (aspNetRole == null)
            {
                return HttpNotFound();
            }
            return View(aspNetRole);
        }

        // GET: AspNetRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AspNetRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] AspNetRole aspNetRole)
        {
           
            if (ModelState.IsValid)
            {
                _aspNetRoleService.Insert(aspNetRole);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(aspNetRole);
        }

        // GET: AspNetRoles/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRole aspNetRole = await _aspNetRoleService.FindAsync(id);
            if (aspNetRole == null)
            {
                return HttpNotFound();
            }
            return View(aspNetRole);
        }

        // POST: AspNetRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] AspNetRole aspNetRole)
        {
           

            if (ModelState.IsValid)
            {
                aspNetRole.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                _aspNetRoleService.Update(aspNetRole);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aspNetRole);
        }

        // GET: AspNetRoles/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRole aspNetRole = await _aspNetRoleService.FindAsync(id);
            if (aspNetRole == null)
            {
                return HttpNotFound();
            }
            return View(aspNetRole);
        }

        // POST: AspNetRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            AspNetRole aspNetRole = await _aspNetRoleService.FindAsync(id);
            _aspNetRoleService.Delete(aspNetRole);
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
