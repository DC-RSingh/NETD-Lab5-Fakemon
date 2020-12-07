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
    public class FakemonsController : Controller
    {
        private readonly FakedexContext _context;

        public FakemonsController(FakedexContext context)
        {
            _context = context;
        }

        // GET: Fakemons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fakemons.ToListAsync());
        }

        // GET: Fakemons/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fakemon = await _context.Fakemons
                .FirstOrDefaultAsync(m => m.DexNumber == id);
            if (fakemon == null)
            {
                return NotFound();
            }

            return View(fakemon);
        }

        // GET: Fakemons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fakemons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DexNumber,Name,TypeOne,TypeTwo,Nature")] Fakemon fakemon)
        {
            if (ModelState.IsValid)
            {
                fakemon.DexNumber = Guid.NewGuid();
                _context.Add(fakemon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fakemon);
        }

        // GET: Fakemons/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fakemon = await _context.Fakemons.FindAsync(id);
            if (fakemon == null)
            {
                return NotFound();
            }
            return View(fakemon);
        }

        // POST: Fakemons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DexNumber,Name,TypeOne,TypeTwo,Nature")] Fakemon fakemon)
        {
            if (id != fakemon.DexNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fakemon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FakemonExists(fakemon.DexNumber))
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
            return View(fakemon);
        }

        // GET: Fakemons/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fakemon = await _context.Fakemons
                .FirstOrDefaultAsync(m => m.DexNumber == id);
            if (fakemon == null)
            {
                return NotFound();
            }

            return View(fakemon);
        }

        // POST: Fakemons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fakemon = await _context.Fakemons.FindAsync(id);
            _context.Fakemons.Remove(fakemon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FakemonExists(Guid id)
        {
            return _context.Fakemons.Any(e => e.DexNumber == id);
        }
    }
}
