using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using LMEntities.Models;
using Repository.Pattern.UnitOfWork;
using LMService;

namespace LeagueManagement.Controllers
{
    public class SeasonsController : Controller
    {
        private readonly ISeasonService _seasonService;
        private readonly IUnitOfWork _unitOfWork;
        public SeasonsController(ISeasonService seasonServiceService, IUnitOfWork unitOfWork)
        {
            _seasonService = seasonServiceService;
            _unitOfWork = unitOfWork;
        }
        // GET: Seasons
        public async Task<ActionResult> Index()
        {
            return View(await _seasonService.GetAsync());
        }

        // GET: Seasons/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season =  _seasonService.Find(id);

            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }
        // GET: Seasons/Create
        public ActionResult Create()
        {
            ViewBag.LeagueId = new SelectList(_seasonService.Leagues, "Id", "Name");
            ViewBag.OrganizationId = new SelectList(_seasonService.Organizations, "Id", "Name");
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
                _seasonService.Insert(season);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LeagueId = new SelectList(_seasonService.Leagues, "Id", "Name", season.LeagueId);
            ViewBag.OrganizationId = new SelectList(_seasonService.Organizations, "Id", "Name", season.OrganizationId);
            return View(season);
        }

       // GET: Seasons/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season = await _seasonService.FindAsync(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            ViewBag.LeagueId = new SelectList(_seasonService.Leagues, "Id", "Name", season.LeagueId);
            ViewBag.OrganizationId = new SelectList(_seasonService.Organizations, "Id", "Name", season.OrganizationId);
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
                _seasonService.Update(season);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LeagueId = new SelectList(_seasonService.Leagues, "Id", "Name", season.LeagueId);
            ViewBag.OrganizationId = new SelectList(_seasonService.Organizations, "Id", "Name", season.OrganizationId);
            return View(season);
        }

        // GET: Seasons/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season = _seasonService.Find(id);
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
            Season season = await _seasonService.FindAsync(id);
            _seasonService.Delete(season);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
