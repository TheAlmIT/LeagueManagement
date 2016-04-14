
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
    public class GroundsController : Controller
    {
        private SportsSiteContext db = new SportsSiteContext();
        private readonly IGroundService _groundService;
        private IUnitOfWork _unitOfWork;

        public GroundsController(IGroundService GroundService, IUnitOfWork unitOfWork)
        {
            _groundService = GroundService;
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _groundService.GetAsync());
        }

        // GET: Grounds/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ground ground = await _groundService.FindAsync(id);
            if (ground == null)
            {
                return HttpNotFound();
            }
            return View(ground);
        }

        // GET: Grounds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grounds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Address,Directions")] Ground ground)
        {
            if (ModelState.IsValid)
            {
                _groundService.Insert(ground);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ground);
        }

        // GET: Grounds/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ground ground = await _groundService.FindAsync(id);
            if (ground == null)
            {
                return HttpNotFound();
            }
            return View(ground);
        }

        // POST: Grounds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Address,Directions")] Ground ground)
        {
            if (ModelState.IsValid)
            {
                ground.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                _groundService.Update(ground);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ground);
        }

        // GET: Grounds/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ground ground = await _groundService.FindAsync(id);
            if (ground == null)
            {
                return HttpNotFound();
            }
            return View(ground);
        }

        // POST: Grounds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ground ground = await _groundService.FindAsync(id);
            _groundService.Delete(ground);
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
