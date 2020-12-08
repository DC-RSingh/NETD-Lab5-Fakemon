using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NETD_F2020_Lab5.Models;

namespace NETD_F2020_Lab5.Controllers
{
    public class StatsController : Controller
    {
        private readonly FakedexContext _context;

        public StatsController(FakedexContext context)
        {
            _context = context;
        }

        // GET: Stats
        public async Task<IActionResult> Index()
        {
            var fakedexContext = _context.Stats.Include(s => s.Fakemon);
            return View(await fakedexContext.ToListAsync());
        }

        // GET: Stats/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stats = await _context.Stats
                .Include(s => s.Fakemon)
                .FirstOrDefaultAsync(m => m.StatsId == id);
            if (stats == null)
            {
                return NotFound();
            }

            return View(stats);
        }

        // GET: Stats/Create
        public IActionResult Create()
        {
            ViewData["StatsId"] = new SelectList(_context.Fakemons, "DexNumber", "Name");
            return View();
        }

        // POST: Stats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatsId,HitPoints,Attack,Defense,SpecialAttack,SpecialDefense,Speed")] Stats stats)
        {
            if (ModelState.IsValid && !StatsExists(stats.StatsId))
            {
                //stats.StatsId = Guid.NewGuid();
                _context.Add(stats);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatsId"] = new SelectList(_context.Fakemons, "DexNumber", "Name", stats.StatsId);

            return View(stats);
        }

        // GET: Stats/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stats = await _context.Stats.FindAsync(id);
            if (stats == null)
            {
                return NotFound();
            }

            // Retrieve corresponding Fakemon information
            var fakemon = await _context.Fakemons.FindAsync(id);
            stats.Fakemon = fakemon;

            ViewData["StatsId"] = new SelectList(_context.Fakemons, "DexNumber", "Name", stats.StatsId);
            return View(stats);
        }

        // POST: Stats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("StatsId,HitPoints,Attack,Defense,SpecialAttack,SpecialDefense,Speed")] Stats stats)
        {
            if (id != stats.StatsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stats);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatsExists(stats.StatsId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatsId"] = new SelectList(_context.Fakemons, "DexNumber", "Name", stats.StatsId);
            return View(stats);
        }

        // GET: Stats/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stats = await _context.Stats
                .Include(s => s.Fakemon)
                .FirstOrDefaultAsync(m => m.StatsId == id);
            if (stats == null)
            {
                return NotFound();
            }

            return View(stats);
        }

        // POST: Stats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var stats = await _context.Stats.FindAsync(id);
            _context.Stats.Remove(stats);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatsExists(Guid id)
        {
            return _context.Stats.Any(e => e.StatsId == id);
        }
    }
}
