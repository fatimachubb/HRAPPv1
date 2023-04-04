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
    public class ColaboradorTypesController : Controller
    {
        private readonly JobContext _context;

        public ColaboradorTypesController(JobContext context)
        {
            _context = context;
        }

        // GET: ColaboradorTypes
        public async Task<IActionResult> Index()
        {
              return _context.ColaboradorTypes != null ? 
                          View(await _context.ColaboradorTypes.ToListAsync()) :
                          Problem("Entity set 'JobContext.ColaboradorTypes'  is null.");
        }

        // GET: ColaboradorTypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ColaboradorTypes == null)
            {
                return NotFound();
            }

            var colaboradorType = await _context.ColaboradorTypes
                .FirstOrDefaultAsync(m => m.IdType == id);
            if (colaboradorType == null)
            {
                return NotFound();
            }

            return View(colaboradorType);
        }

        // GET: ColaboradorTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ColaboradorTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdType,Type")] ColaboradorType colaboradorType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaboradorType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colaboradorType);
        }

        // GET: ColaboradorTypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ColaboradorTypes == null)
            {
                return NotFound();
            }

            var colaboradorType = await _context.ColaboradorTypes.FindAsync(id);
            if (colaboradorType == null)
            {
                return NotFound();
            }
            return View(colaboradorType);
        }

        // POST: ColaboradorTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdType,Type")] ColaboradorType colaboradorType)
        {
            if (id != colaboradorType.IdType)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaboradorType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradorTypeExists(colaboradorType.IdType))
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
            return View(colaboradorType);
        }

        // GET: ColaboradorTypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ColaboradorTypes == null)
            {
                return NotFound();
            }

            var colaboradorType = await _context.ColaboradorTypes
                .FirstOrDefaultAsync(m => m.IdType == id);
            if (colaboradorType == null)
            {
                return NotFound();
            }

            return View(colaboradorType);
        }

        // POST: ColaboradorTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ColaboradorTypes == null)
            {
                return Problem("Entity set 'JobContext.ColaboradorTypes'  is null.");
            }
            var colaboradorType = await _context.ColaboradorTypes.FindAsync(id);
            if (colaboradorType != null)
            {
                _context.ColaboradorTypes.Remove(colaboradorType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboradorTypeExists(string id)
        {
          return (_context.ColaboradorTypes?.Any(e => e.IdType == id)).GetValueOrDefault();
        }
    }
}
