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
    public class ArticleCommandeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticleCommandeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArticleCommande
        public async Task<IActionResult> Index()
        {
              return _context.ArticleCommandes != null ? 
                          View(await _context.ArticleCommandes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ArticleCommandes'  is null.");
        }

        // GET: ArticleCommande/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ArticleCommandes == null)
            {
                return NotFound();
            }

            var articleCommande = await _context.ArticleCommandes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articleCommande == null)
            {
                return NotFound();
            }

            return View(articleCommande);
        }

        // GET: ArticleCommande/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArticleCommande/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] ArticleCommande articleCommande)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articleCommande);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articleCommande);
        }

        // GET: ArticleCommande/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ArticleCommandes == null)
            {
                return NotFound();
            }

            var articleCommande = await _context.ArticleCommandes.FindAsync(id);
            if (articleCommande == null)
            {
                return NotFound();
            }
            return View(articleCommande);
        }

        // POST: ArticleCommande/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] ArticleCommande articleCommande)
        {
            if (id != articleCommande.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articleCommande);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleCommandeExists(articleCommande.Id))
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
            return View(articleCommande);
        }

        // GET: ArticleCommande/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ArticleCommandes == null)
            {
                return NotFound();
            }

            var articleCommande = await _context.ArticleCommandes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articleCommande == null)
            {
                return NotFound();
            }

            return View(articleCommande);
        }

        // POST: ArticleCommande/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ArticleCommandes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ArticleCommandes'  is null.");
            }
            var articleCommande = await _context.ArticleCommandes.FindAsync(id);
            if (articleCommande != null)
            {
                _context.ArticleCommandes.Remove(articleCommande);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleCommandeExists(int id)
        {
          return (_context.ArticleCommandes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
