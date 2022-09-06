using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCadastro.Models;

namespace WebCadastro.Controllers
{
    public class CadastroPetController : Controller
    {
        private readonly Ligacao _context;

        public CadastroPetController(Ligacao context)
        {
            _context = context;
        }

        // GET: CadastroPet
        public async Task<IActionResult> Index()
        {
              return _context.CadastroPet != null ? 
                          View(await _context.CadastroPet.ToListAsync()) :
                          Problem("Entity set 'Ligacao.CadastroPet'  is null.");
        }

        // GET: CadastroPet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CadastroPet == null)
            {
                return NotFound();
            }

            var cadastroPet = await _context.CadastroPet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroPet == null)
            {
                return NotFound();
            }

            return View(cadastroPet);
        }

        // GET: CadastroPet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroPet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Idade,Peso,Email,Telefone")] CadastroPet cadastroPet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroPet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroPet);
        }

        // GET: CadastroPet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CadastroPet == null)
            {
                return NotFound();
            }

            var cadastroPet = await _context.CadastroPet.FindAsync(id);
            if (cadastroPet == null)
            {
                return NotFound();
            }
            return View(cadastroPet);
        }

        // POST: CadastroPet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Idade,Peso,Email,Telefone")] CadastroPet cadastroPet)
        {
            if (id != cadastroPet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroPet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroPetExists(cadastroPet.Id))
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
            return View(cadastroPet);
        }

        // GET: CadastroPet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CadastroPet == null)
            {
                return NotFound();
            }

            var cadastroPet = await _context.CadastroPet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroPet == null)
            {
                return NotFound();
            }

            return View(cadastroPet);
        }

        // POST: CadastroPet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CadastroPet == null)
            {
                return Problem("Entity set 'Ligacao.CadastroPet'  is null.");
            }
            var cadastroPet = await _context.CadastroPet.FindAsync(id);
            if (cadastroPet != null)
            {
                _context.CadastroPet.Remove(cadastroPet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroPetExists(int id)
        {
          return (_context.CadastroPet?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
