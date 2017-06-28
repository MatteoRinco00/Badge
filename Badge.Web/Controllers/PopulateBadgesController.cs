//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Badge.EF;
//using Badge.EF.Entity;

//namespace Badge.Web.Controllers
//{
//    public class PopulateBadgesController : Controller
//    {
//        private readonly BadgeContext _context;

//        public PopulateBadgesController(BadgeContext context)
//        {
//            _context = context;    
//        }

//        // GET: PopulateBadges
//        public async Task<IActionResult> Index()
//        {
//            var badgeContext = _context.Badges.Include(p => p.Person);
//            return View(await badgeContext.ToListAsync());
//        }

//        // GET: PopulateBadges/Details/5
//        public async Task<IActionResult> Details(string? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var populateBadge = await _context.Badges
//                .Include(p => p.Person)
//                .SingleOrDefaultAsync(m => m.NomeBadge == id);
//            if (populateBadge == null)
//            {
//                return NotFound();
//            }

//            return View(populateBadge);
//        }

//        // GET: PopulateBadges/Create
//        public IActionResult Create()
//        {
//            ViewData["IdPerson"] = new SelectList(_context.People, "IdPerson", "IdPerson");
//            return View();
//        }

//        // POST: PopulateBadges/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("NomeBadge,IdPerson")] PopulateBadge populateBadge)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(populateBadge);
//                await _context.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }
//            ViewData["IdPerson"] = new SelectList(_context.People, "IdPerson", "IdPerson", populateBadge.IdPerson);
//            return View(populateBadge);
//        }

//        // GET: PopulateBadges/Edit/5
//        public async Task<IActionResult> Edit(string? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var populateBadge = await _context.Badges.SingleOrDefaultAsync(m => m.NomeBadge == id);
//            if (populateBadge == null)
//            {
//                return NotFound();
//            }
//            ViewData["IdPerson"] = new SelectList(_context.People, "IdPerson", "IdPerson", populateBadge.IdPerson);
//            return View(populateBadge);
//        }

//        // POST: PopulateBadges/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(string id, [Bind("NomeBadge,IdPerson")] PopulateBadge populateBadge)
//        {
//            if (id != populateBadge.NomeBadge)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(populateBadge);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!PopulateBadgeExists(populateBadge.NomeBadge))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction("Index");
//            }
//            ViewData["IdPerson"] = new SelectList(_context.People, "IdPerson", "IdPerson", populateBadge.IdPerson);
//            return View(populateBadge);
//        }

//        // GET: PopulateBadges/Delete/5
//        public async Task<IActionResult> Delete(string? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var populateBadge = await _context.Badges
//                .Include(p => p.Person)
//                .SingleOrDefaultAsync(m => m.NomeBadge == id);
//            if (populateBadge == null)
//            {
//                return NotFound();
//            }

//            return View(populateBadge);
//        }

//        // POST: PopulateBadges/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(string id)
//        {
//            var populateBadge = await _context.Badges.SingleOrDefaultAsync(m => m.NomeBadge == id);
//            _context.Badges.Remove(populateBadge);
//            await _context.SaveChangesAsync();
//            return RedirectToAction("Index");
//        }

//        private bool PopulateBadgeExists(string id)
//        {
//            return _context.Badges.Any(e => e.NomeBadge == id);
//        }
//    }
//}
