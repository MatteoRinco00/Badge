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
using AutoMapper;

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
        public async Task<IActionResult> Index(int peopleid, int take=6, int skip = 0)
        {
            PaginationViewModel<SwipesViewModel> result = new PaginationViewModel<SwipesViewModel>(); 
            //int quantita = await _context.Swipe.CountAsync();
            List<Swipe> swipes = new List<Swipe>();
            int Countgiri = 0;
            int quantitatot = await _context.Swipe
                .Where(x => x.Badge.IdPerson == peopleid)
                .CountAsync();

            int quantita = await _context.Swipe
                .Where(x => x.Badge.IdPerson == peopleid)
                .CountAsync();
            swipes = await _context.Swipe
                .Include(x => x.Badge)
                .Where(x => x.Badge.IdPerson == peopleid)
                .Skip(skip).Take(take)
                .ToListAsync();

            result.Count = quantita;
            result.Skip = skip;
            if (result.Count % 6 == 0)
            {
                Countgiri = (result.Count / 6) - 1;
            }
            else
            {
                Countgiri = (result.Count / 6);
            }

            result.Count = Countgiri;

            
            
            foreach (var p in swipes)
            {
                SwipesViewModel pv = new SwipesViewModel()
                {
                    IdSwipe = p.IdSwipe,
                    PosPersona = p.PosPersona,
                    Orario = p.Orario,
                    MachineName = p.MachineName,
                    NomeBadge = p.NomeBadge,
                    IdPerson = p.Badge.IdPerson
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

            int idPerson = await _context.Swipe
               .Where(m => m.IdSwipe == id)
               .Select(p => p.Badge.IdPerson)
               .FirstOrDefaultAsync();

            var swipe = await _context.Swipe
                .Include(s => s.Badge)
                .Include(s => s.Machine)
                .SingleOrDefaultAsync(m => m.IdSwipe == id);
            if (swipe == null)
            {
                return NotFound();
            }

            swipe.IdPerson = idPerson;

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
        public async Task<IActionResult> Create( SwipesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newswipes = Mapper.Map<Swipe>(model);
                _context.Add(newswipes);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //ViewData["NomeBadge"] = new SelectList(_context.Badges, "NomeBadge", "NomeBadge", swipe.NomeBadge);
            //ViewData["MachineName"] = new SelectList(_context.Machines, "Name", "Name", swipe.MachineName);
            return View(model);
        }

        // GET: Swipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var swipe = await _context.Swipe.SingleOrDefaultAsync(m => m.IdSwipe == id);
            int idPerson = await _context.Swipe
                .Where(m => m.IdSwipe == id)
                .Select(p => p.Badge.IdPerson )
                .FirstOrDefaultAsync();

            SwipesViewModel model = Mapper.Map<SwipesViewModel>(swipe);
            model.IdPerson = idPerson;

            if (swipe == null)
            {
                return NotFound();
            }

            //ViewData["NomeBadge"] = new SelectList(_context.Badges, "NomeBadge", "NomeBadge", swipe.NomeBadge);
            //ViewData["MachineName"] = new SelectList(_context.Machines, "Name", "Name", swipe.MachineName);
            return View(model);
        }

        // POST: Swipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SwipesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var swipe = await _context.Swipe.SingleAsync(x => x.IdSwipe == id);
                Mapper.Map(model, swipe);

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            //ViewData["NomeBadge"] = new SelectList(_context.Badges, "NomeBadge", "NomeBadge", swipe.NomeBadge);
            //ViewData["MachineName"] = new SelectList(_context.Machines, "Name", "Name", swipe.MachineName);
            return View(model);

        }

        // GET: Swipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int idPerson = await _context.Swipe
                .Where(m => m.IdSwipe == id)
                .Select(p => p.Badge.IdPerson)
                .FirstOrDefaultAsync();

            var swipe = await _context.Swipe
                .Include(s => s.Badge)
                .Include(s => s.Machine)
                .SingleOrDefaultAsync(m => m.IdSwipe == id);
            if (swipe == null)
            {
                return NotFound();
            }

            swipe.IdPerson = idPerson;

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
