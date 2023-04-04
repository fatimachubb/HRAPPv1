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
    public class ColaboradorCompetenciesController : Controller
    {
        private readonly JobContext _context;

        public ColaboradorCompetenciesController(JobContext context)
        {
            _context = context;
        }

        // GET: ColaboradorCompetencies
        public async Task<IActionResult> Index()
        {
            var jobContext = _context.ColaboradorCompetencies.Include(c => c.ColaboradorTypeIdTypeNavigation).Include(c => c.CompetencieIdCompetencieNavigation);
            return View(await jobContext.ToListAsync());
        }

        // GET: ColaboradorCompetencies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ColaboradorCompetencies == null)
            {
                return NotFound();
            }

            var colaboradorCompetency = await _context.ColaboradorCompetencies
                .Include(c => c.ColaboradorTypeIdTypeNavigation)
                .Include(c => c.CompetencieIdCompetencieNavigation)
                .FirstOrDefaultAsync(m => m.Idcc == id);
            if (colaboradorCompetency == null)
            {
                return NotFound();
            }

            return View(colaboradorCompetency);
        }

        // GET: ColaboradorCompetencies/Create
        public IActionResult Create()
        {
            ViewData["ColaboradorTypeIdType"] = new SelectList(_context.ColaboradorTypes, "IdType", "IdType");
            ViewData["CompetencieIdCompetencie"] = new SelectList(_context.Competencies, "IdCompetencie", "IdCompetencie");
            return View();
        }

        // POST: ColaboradorCompetencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcc,ColaboradorTypeIdType,CompetencieIdCompetencie")] ColaboradorCompetency colaboradorCompetency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaboradorCompetency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColaboradorTypeIdType"] = new SelectList(_context.ColaboradorTypes, "IdType", "IdType", colaboradorCompetency.ColaboradorTypeIdType);
            ViewData["CompetencieIdCompetencie"] = new SelectList(_context.Competencies, "IdCompetencie", "IdCompetencie", colaboradorCompetency.CompetencieIdCompetencie);
            return View(colaboradorCompetency);
        }

        // GET: ColaboradorCompetencies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ColaboradorCompetencies == null)
            {
                return NotFound();
            }

            var colaboradorCompetency = await _context.ColaboradorCompetencies.FindAsync(id);
            if (colaboradorCompetency == null)
            {
                return NotFound();
            }
            ViewData["ColaboradorTypeIdType"] = new SelectList(_context.ColaboradorTypes, "IdType", "IdType", colaboradorCompetency.ColaboradorTypeIdType);
            ViewData["CompetencieIdCompetencie"] = new SelectList(_context.Competencies, "IdCompetencie", "IdCompetencie", colaboradorCompetency.CompetencieIdCompetencie);
            return View(colaboradorCompetency);
        }

        // POST: ColaboradorCompetencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Idcc,ColaboradorTypeIdType,CompetencieIdCompetencie")] ColaboradorCompetency colaboradorCompetency)
        {
            if (id != colaboradorCompetency.Idcc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaboradorCompetency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradorCompetencyExists(colaboradorCompetency.Idcc))
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
            ViewData["ColaboradorTypeIdType"] = new SelectList(_context.ColaboradorTypes, "IdType", "IdType", colaboradorCompetency.ColaboradorTypeIdType);
            ViewData["CompetencieIdCompetencie"] = new SelectList(_context.Competencies, "IdCompetencie", "IdCompetencie", colaboradorCompetency.CompetencieIdCompetencie);
            return View(colaboradorCompetency);
        }

        // GET: ColaboradorCompetencies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ColaboradorCompetencies == null)
            {
                return NotFound();
            }

            var colaboradorCompetency = await _context.ColaboradorCompetencies
                .Include(c => c.ColaboradorTypeIdTypeNavigation)
                .Include(c => c.CompetencieIdCompetencieNavigation)
                .FirstOrDefaultAsync(m => m.Idcc == id);
            if (colaboradorCompetency == null)
            {
                return NotFound();
            }

            return View(colaboradorCompetency);
        }

        // POST: ColaboradorCompetencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ColaboradorCompetencies == null)
            {
                return Problem("Entity set 'JobContext.ColaboradorCompetencies'  is null.");
            }
            var colaboradorCompetency = await _context.ColaboradorCompetencies.FindAsync(id);
            if (colaboradorCompetency != null)
            {
                _context.ColaboradorCompetencies.Remove(colaboradorCompetency);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboradorCompetencyExists(string id)
        {
          return (_context.ColaboradorCompetencies?.Any(e => e.Idcc == id)).GetValueOrDefault();
        }
    }
}
