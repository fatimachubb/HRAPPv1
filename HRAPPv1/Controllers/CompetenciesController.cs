using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRAPPv1.Models;

namespace HRAPPv1.Controllers
{
    public class CompetenciesController : Controller
    {
        private readonly JobContext _context;

        public CompetenciesController(JobContext context)
        {
            _context = context;
        }

        // GET: Competencies
        public async Task<IActionResult> Index()
        {
              return _context.Competencies != null ? 
                          View(await _context.Competencies.ToListAsync()) :
                          Problem("Entity set 'JobContext.Competencies'  is null.");
        }

        // GET: Competencies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Competencies == null)
            {
                return NotFound();
            }

            var competency = await _context.Competencies
                .FirstOrDefaultAsync(m => m.IdCompetencie == id);
            if (competency == null)
            {
                return NotFound();
            }

            return View(competency);
        }

        // GET: Competencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Competencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompetencie,CompetencieDescrip")] Competency competency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(competency);
        }

        // GET: Competencies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Competencies == null)
            {
                return NotFound();
            }

            var competency = await _context.Competencies.FindAsync(id);
            if (competency == null)
            {
                return NotFound();
            }
            return View(competency);
        }

        // POST: Competencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdCompetencie,CompetencieDescrip")] Competency competency)
        {
            if (id != competency.IdCompetencie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetencyExists(competency.IdCompetencie))
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
            return View(competency);
        }

        // GET: Competencies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Competencies == null)
            {
                return NotFound();
            }

            var competency = await _context.Competencies
                .FirstOrDefaultAsync(m => m.IdCompetencie == id);
            if (competency == null)
            {
                return NotFound();
            }

            return View(competency);
        }

        // POST: Competencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Competencies == null)
            {
                return Problem("Entity set 'JobContext.Competencies'  is null.");
            }
            var competency = await _context.Competencies.FindAsync(id);
            if (competency != null)
            {
                _context.Competencies.Remove(competency);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetencyExists(string id)
        {
          return (_context.Competencies?.Any(e => e.IdCompetencie == id)).GetValueOrDefault();
        }
    }
}
