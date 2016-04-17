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
    public class UmpiresController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IScheduleService _scheduleService;
        public UmpiresController(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }
        // GET: Users
        public ActionResult Index()
        {
            return View(_userService.GetUmpiresList());
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await _userService.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            User user = new LMEntities.Models.User {Umpires = _userService.GetUsers_NotUmpires()};

            return View(user);
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FormCollection formCollection)
        {
            if(formCollection.AllKeys.Where(c => c.StartsWith("chk")).ToList().Count == 0)
            {
                ModelState.AddModelError("Umpire", "Please Select an umpire");
            }

            if (ModelState.IsValid)
            {
                var umpiresList = formCollection.AllKeys.Where(c => c.StartsWith("chk")).ToList();
                _userService.SaveUmpires(umpiresList);               
                return RedirectToAction("Index");
            }
            User users = new LMEntities.Models.User();
            users.Umpires = _userService.GetUsers_NotUmpires();
            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await _userService.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            SetViewBag(ref user);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(
            [Bind(
                Include =
                    "Id,OrganizationId,UserTypeId,EmailId,FirstName,LastName,Password,GenderId,ProfilePhoto,CreatedOn,ModifiedOn"
                )] User user)
        {
            if (ModelState.IsValid)
            {
                user.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                _userService.Update(user);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            SetViewBag(ref user);
            return View(user);
        }

        private void SetViewBag(ref User user)
        {
            ViewBag.GenderId = new SelectList(_userService.Genders, "Id", "Name", user.GenderId);
            ViewBag.OrganizationId = new SelectList(_userService.Organizations, "Id", "Name", user.OrganizationId);
            ViewBag.Id = new SelectList(_userService.Users, "Id", "EmailId", user.Id);
            ViewBag.UserTypeId = new SelectList(_userService.UserTypes, "Id", "Name", user.UserTypeId);
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await _userService.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User user = await _userService.FindAsync(id);

            user.Schedules = _scheduleService.GetSchedule_ForUser(id);

            if(user.Schedules.Count > 0)
            {
                ModelState.AddModelError("FirstName", "Please change the schedule to delete this umpire");
            }

            if (ModelState.IsValid)
            {
               _userService.DeleteUmpire(id);
                return RedirectToAction("Index");
            }

            return View(user);
        }
       
    }
}
