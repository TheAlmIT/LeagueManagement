﻿using System;
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
        private SportsSiteContext db = new SportsSiteContext();
        private readonly IUserService _UserService;
        private IUnitOfWork _unitOfWork;
        public UmpiresController(IUserService UserService, IUnitOfWork unitOfWork)
        {
            _UserService = UserService;
            _unitOfWork = unitOfWork;
        }
        // GET: Users
        public async Task<ActionResult> Index()
        {
            return View(await _UserService.GetAsync());
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await _UserService.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name");
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            ViewBag.Id = new SelectList(db.Users, "Id", "EmailId");
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "Name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,OrganizationId,UserTypeId,EmailId,FirstName,LastName,Password,GenderId,ProfilePhoto,CreatedOn,ModifiedOn")] User user)
        {
            if (ModelState.IsValid)
            {
                _UserService.Insert(user);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name", user.GenderId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", user.OrganizationId);
            ViewBag.Id = new SelectList(db.Users, "Id", "EmailId", user.Id);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "Name", user.UserTypeId);
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await _UserService.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name", user.GenderId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", user.OrganizationId);
            ViewBag.Id = new SelectList(db.Users, "Id", "EmailId", user.Id);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "Name", user.UserTypeId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,OrganizationId,UserTypeId,EmailId,FirstName,LastName,Password,GenderId,ProfilePhoto,CreatedOn,ModifiedOn")] User user)
        {
            if (ModelState.IsValid)
            {
                user.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                _UserService.Update(user);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name", user.GenderId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", user.OrganizationId);
            ViewBag.Id = new SelectList(db.Users, "Id", "EmailId", user.Id);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "Name", user.UserTypeId);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await _UserService.FindAsync(id);
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
            User user = await _UserService.FindAsync(id);          
            user.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
            user.UserTypeId = 3;
            _UserService.Update(user);
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
