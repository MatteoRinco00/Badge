using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Badge.EF;
using Badge.EF.Entity;
using Badge.Web.Models.Shared;
using Badge.Web.Models.Swipes;

namespace Badge.Web.Controllers
{
    public class SwipesController : Controller
    {
        private readonly BadgeContext _context;

        public SwipesController(BadgeContext context)
        {
            _context = context;    
        }

        // GET: Swipes
        public async Task<IActionResult> Index(int? take, int skip = 0)
        {
            PaginationViewModel<SwipesViewModel> result = new PaginationViewModel<SwipesViewModel>(); 
            int quantita = await _context.Swipe.CountAsync();
            List<Swipe> person = new List<Swipe>();
            if (take.HasValue)
            {
                person = await _context.Swipe.Skip(skip).Take(take.Value).ToListAsync();
            }
            else
            {
                person = await _context.Swipe.ToListAsync();
            }

            result.Count = quantita;
            result.Skip = skip;
            foreach (var p in person)
            {
                SwipesViewModel pv = new SwipesViewModel()
                {
                    IdSwipe = p.IdSwipe,
                    PosPersona = p.PosPersona,
                    Orario = p.Orario,
                    MachineName = p.MachineName,
                    NomeBadge = p.NomeBadge
                };
                result.Data.Add(pv);
            }

            return View(result);
        
    }

        // GET: Swipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var swipe = await _context.Swipe
                .Include(s => s.Badge)
                .Include(s => s.Machine)
                .SingleOrDefaultAsync(m => m.IdSwipe == id);
            if (swipe == null)
            {
                return NotFound();
            }

            return View(swipe);
        }

        // GET: Swipes/Create
        public IActionResult Create()
        {
            ViewData["NomeBadge"] = new SelectList(_context.Badges, "NomeBadge", "NomeBadge");
            ViewData["MachineName"] = new SelectList(_context.Machines, "Name", "Name");
            return View();
        }

        // POST: Swipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSwipe,PosPersona,Orario,MachineName,NomeBadge")] Swipe swipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(swipe);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["NomeBadge"] = new SelectList(_context.Badges, "NomeBadge", "NomeBadge", swipe.NomeBadge);
            ViewData["MachineName"] = new SelectList(_context.Machines, "Name", "Name", swipe.MachineName);
            return View(swipe);
        }

        // GET: Swipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var swipe = await _context.Swipe.SingleOrDefaultAsync(m => m.IdSwipe == id);
            if (swipe == null)
            {
                return NotFound();
            }
            ViewData["NomeBadge"] = new SelectList(_context.Badges, "NomeBadge", "NomeBadge", swipe.NomeBadge);
            ViewData["MachineName"] = new SelectList(_context.Machines, "Name", "Name", swipe.MachineName);
            return View(swipe);
        }

        // POST: Swipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSwipe,PosPersona,Orario,MachineName,NomeBadge")] Swipe swipe)
        {
            if (id != swipe.IdSwipe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(swipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SwipeExists(swipe.IdSwipe))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["NomeBadge"] = new SelectList(_context.Badges, "NomeBadge", "NomeBadge", swipe.NomeBadge);
            ViewData["MachineName"] = new SelectList(_context.Machines, "Name", "Name", swipe.MachineName);
            return View(swipe);
        }

        // GET: Swipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var swipe = await _context.Swipe
                .Include(s => s.Badge)
                .Include(s => s.Machine)
                .SingleOrDefaultAsync(m => m.IdSwipe == id);
            if (swipe == null)
            {
                return NotFound();
            }

            return View(swipe);
        }

        // POST: Swipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var swipe = await _context.Swipe.SingleOrDefaultAsync(m => m.IdSwipe == id);
            _context.Swipe.Remove(swipe);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SwipeExists(int id)
        {
            return _context.Swipe.Any(e => e.IdSwipe == id);
        }
    }
}
