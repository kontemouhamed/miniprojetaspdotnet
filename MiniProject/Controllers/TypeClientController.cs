using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniProject.Data;
using MiniProject.Models;

namespace MiniProject.Controllers
{
    public class TypeClientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypeClient
        public async Task<IActionResult> Index()
        {
              return _context.TypeClients != null ? 
                          View(await _context.TypeClients.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TypeClients'  is null.");
        }

        // GET: TypeClient/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeClients == null)
            {
                return NotFound();
            }

            var typeClient = await _context.TypeClients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeClient == null)
            {
                return NotFound();
            }

            return View(typeClient);
        }

        // GET: TypeClient/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeClient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Libelle")] TypeClient typeClient)
        {
            //if (ModelState.IsValid)
           // {
                _context.Add(typeClient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
          //  }
          //  return View(typeClient);
        }

        // GET: TypeClient/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeClients == null)
            {
                return NotFound();
            }

            var typeClient = await _context.TypeClients.FindAsync(id);
            if (typeClient == null)
            {
                return NotFound();
            }
            return View(typeClient);
        }

        // POST: TypeClient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Libelle")] TypeClient typeClient)
        {
            if (id != typeClient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeClient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeClientExists(typeClient.Id))
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
            return View(typeClient);
        }

        // GET: TypeClient/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeClients == null)
            {
                return NotFound();
            }

            var typeClient = await _context.TypeClients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeClient == null)
            {
                return NotFound();
            }

            return View(typeClient);
        }

        // POST: TypeClient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeClients == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TypeClients'  is null.");
            }
            var typeClient = await _context.TypeClients.FindAsync(id);
            if (typeClient != null)
            {
                _context.TypeClients.Remove(typeClient);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeClientExists(int id)
        {
          return (_context.TypeClients?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
