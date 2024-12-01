using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAMotosMVC.Data;
using SAMotosMVC.Models;

namespace SAMotosMVC.Controllers
{
    public class SAMotoesController : Controller
    {
        private readonly SAMotosMVCContext _context;

        public SAMotoesController(SAMotosMVCContext context)
        {
            _context = context;
        }

        // GET: SAMotoes
        public async Task<IActionResult> SAIndex()
        {
            return View(await _context.SAMoto.ToListAsync());
        }

        // GET: SAMotoes/Details/5
        public async Task<IActionResult> SADetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sAMoto = await _context.SAMoto
                .FirstOrDefaultAsync(m => m.idSAMoto == id);
            if (sAMoto == null)
            {
                return NotFound();
            }

            return View(sAMoto);
        }

        // GET: SAMotoes/Create
        public IActionResult SACreate()
        {
            return View();
        }

        // POST: SAMotoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SACreate([Bind("idSAMoto,SAmodelo,SAmarca,SAcilindraje,SAcolor")] SAMoto sAMoto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sAMoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SAIndex));
            }
            return View(sAMoto);
        }

        // GET: SAMotoes/Edit/5
        public async Task<IActionResult> SAEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sAMoto = await _context.SAMoto.FindAsync(id);
            if (sAMoto == null)
            {
                return NotFound();
            }
            return View(sAMoto);
        }

        // POST: SAMotoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SAEdit(int id, [Bind("idSAMoto,SAmodelo,SAmarca,SAcilindraje,SAcolor")] SAMoto sAMoto)
        {
            if (id != sAMoto.idSAMoto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sAMoto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SAMotoExists(sAMoto.idSAMoto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(SAIndex));
            }
            return View(sAMoto);
        }

        // GET: SAMotoes/Delete/5
        public async Task<IActionResult> SADelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sAMoto = await _context.SAMoto
                .FirstOrDefaultAsync(m => m.idSAMoto == id);
            if (sAMoto == null)
            {
                return NotFound();
            }

            return View(sAMoto);
        }

        // POST: SAMotoes/Delete/5
        [HttpPost, ActionName("SADelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sAMoto = await _context.SAMoto.FindAsync(id);
            if (sAMoto != null)
            {
                _context.SAMoto.Remove(sAMoto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(SAIndex));
        }

        private bool SAMotoExists(int id)
        {
            return _context.SAMoto.Any(e => e.idSAMoto == id);
        }
    }
}
