using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InLab.Data;
using InLab.Models;

namespace InLab.Controllers
{
    public class DetectorsController : Controller
    {
        private readonly AppDbContext _context;

        public DetectorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Detectors
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Detectores.Include(d => d.Area);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Detectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detector = await _context.Detectores
                .Include(d => d.Area)
                .FirstOrDefaultAsync(m => m.IdAde == id);
            if (detector == null)
            {
                return NotFound();
            }

            return View(detector);
        }

        // GET: Detectors/Create
        public IActionResult Create()
        {
            ViewData["IdAre"] = new SelectList(_context.Areas, "IdAre", "IdAre");
            return View();
        }

        // POST: Detectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAde,IdAre,CadastroDet,SerialDet,FabricanteDet,ModeloDet,StatusUsoDet,StatusCoDet,DataCoDet,DataCacDet")] Detector detector)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAre"] = new SelectList(_context.Areas, "IdAre", "IdAre", detector.IdAre);
            return View(detector);
        }

        // GET: Detectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detector = await _context.Detectores.FindAsync(id);
            if (detector == null)
            {
                return NotFound();
            }
            ViewData["IdAre"] = new SelectList(_context.Areas, "IdAre", "IdAre", detector.IdAre);
            return View(detector);
        }

        // POST: Detectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAde,IdAre,CadastroDet,SerialDet,FabricanteDet,ModeloDet,StatusUsoDet,StatusCoDet,DataCoDet,DataCacDet")] Detector detector)
        {
            if (id != detector.IdAde)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetectorExists(detector.IdAde))
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
            ViewData["IdAre"] = new SelectList(_context.Areas, "IdAre", "IdAre", detector.IdAre);
            return View(detector);
        }

        // GET: Detectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detector = await _context.Detectores
                .Include(d => d.Area)
                .FirstOrDefaultAsync(m => m.IdAde == id);
            if (detector == null)
            {
                return NotFound();
            }

            return View(detector);
        }

        // POST: Detectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detector = await _context.Detectores.FindAsync(id);
            if (detector != null)
            {
                _context.Detectores.Remove(detector);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetectorExists(int id)
        {
            return _context.Detectores.Any(e => e.IdAde == id);
        }
    }
}
