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
using Badge.Web.Models.People;
using Badge.Web.Models.Machines;

namespace Badge.Web.Controllers
{
    public class MachinesController : Controller
    {
        private readonly BadgeContext _context;

        public MachinesController(BadgeContext context)
        {
            _context = context;    
        }

        // GET: Machines
        public async Task<IActionResult> Index(int skip = 1, int take = 10)
        {
            PaginationViewModel<MachinesViewModel> result = new PaginationViewModel<MachinesViewModel>();

            int quantita = await _context.Machines.CountAsync();
            List<Machine> person = await _context.Machines.Skip(skip).Take(take).ToListAsync();

            result.Count = quantita;
            foreach (var p in person)
            {
                MachinesViewModel pv = new MachinesViewModel()
                {
                    IpMachine = p.IpMachine,
                    Nome = p.Name,
                    MacAddress = p.MacAddress
                };
                result.Data.Add(pv);
            }

            return View(result);
        }

        // GET: Machines/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var machine = await _context.Machines
                .SingleOrDefaultAsync(m => m.Name == id);
            if (machine == null)
            {
                return NotFound();
            }

            return View(machine);
        }

        // GET: Machines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Machines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,IpMachine,MacAddress")] Machine machine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machine);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(machine);
        }

        // GET: Machines/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var machine = await _context.Machines.SingleOrDefaultAsync(m => m.Name == id);
            if (machine == null)
            {
                return NotFound();
            }
            return View(machine);
        }

        // POST: Machines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,IpMachine,MacAddress")] Machine machine)
        {
            if (id != machine.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineExists(machine.Name))
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
            return View(machine);
        }

        // GET: Machines/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var machine = await _context.Machines
                .SingleOrDefaultAsync(m => m.Name == id);
            if (machine == null)
            {
                return NotFound();
            }

            return View(machine);
        }

        // POST: Machines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var machine = await _context.Machines.SingleOrDefaultAsync(m => m.Name == id);
            _context.Machines.Remove(machine);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        private bool MachineExists(string id)
        {
            return _context.Machines.Any(e => e.Name == id);
        }
    }
}
