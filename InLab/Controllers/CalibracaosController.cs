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
    public class CalibracaosController : Controller
    {
        private readonly AppDbContext _context;

        public CalibracaosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Calibracaos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Calibracoes.Include(c => c.Detector);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Calibracaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calibracao = await _context.Calibracoes
                .Include(c => c.Detector)
                .FirstOrDefaultAsync(m => m.IdCal == id);
            if (calibracao == null)
            {
                return NotFound();
            }

            return View(calibracao);
        }

        // GET: Calibracaos/Create
        public IActionResult Create()
        {
            ViewData["IdDet"] = new SelectList(_context.Detectores, "IdAde", "IdAde");
            return View();
        }

        // POST: Calibracaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCal,IdDet,DataCal")] Calibracao calibracao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calibracao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDet"] = new SelectList(_context.Detectores, "IdAde", "IdAde", calibracao.IdDet);
            return View(calibracao);
        }

        // GET: Calibracaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calibracao = await _context.Calibracoes.FindAsync(id);
            if (calibracao == null)
            {
                return NotFound();
            }
            ViewData["IdDet"] = new SelectList(_context.Detectores, "IdAde", "IdAde", calibracao.IdDet);
            return View(calibracao);
        }

        // POST: Calibracaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCal,IdDet,DataCal")] Calibracao calibracao)
        {
            if (id != calibracao.IdCal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calibracao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalibracaoExists(calibracao.IdCal))
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
            ViewData["IdDet"] = new SelectList(_context.Detectores, "IdAde", "IdAde", calibracao.IdDet);
            return View(calibracao);
        }

        // GET: Calibracaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calibracao = await _context.Calibracoes
                .Include(c => c.Detector)
                .FirstOrDefaultAsync(m => m.IdCal == id);
            if (calibracao == null)
            {
                return NotFound();
            }

            return View(calibracao);
        }

        // POST: Calibracaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calibracao = await _context.Calibracoes.FindAsync(id);
            if (calibracao != null)
            {
                _context.Calibracoes.Remove(calibracao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalibracaoExists(int id)
        {
            return _context.Calibracoes.Any(e => e.IdCal == id);
        }
    }
}
