using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CuaHangDoAn.Data;
using CuaHangDoAn.Models;

namespace CuaHangDoAn.Controllers
{
    public class KhoNguyenLieusController : Controller
    {
        private readonly CuaHangDoAnContext _context;

        public KhoNguyenLieusController(CuaHangDoAnContext context)
        {
            _context = context;
        }

        // GET: KhoNguyenLieus
        public async Task<IActionResult> Index()
        {
              return _context.KhoNguyenLieus != null ? 
                          View(await _context.KhoNguyenLieus.ToListAsync()) :
                          Problem("Entity set 'CuaHangDoAnContext.KhoNguyenLieus'  is null.");
        }

        // GET: KhoNguyenLieus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KhoNguyenLieus == null)
            {
                return NotFound();
            }

            var khoNguyenLieu = await _context.KhoNguyenLieus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khoNguyenLieu == null)
            {
                return NotFound();
            }

            return View(khoNguyenLieu);
        }

        // GET: KhoNguyenLieus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhoNguyenLieus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SoLuong")] KhoNguyenLieu khoNguyenLieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khoNguyenLieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khoNguyenLieu);
        }

        // GET: KhoNguyenLieus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KhoNguyenLieus == null)
            {
                return NotFound();
            }

            var khoNguyenLieu = await _context.KhoNguyenLieus.FindAsync(id);
            if (khoNguyenLieu == null)
            {
                return NotFound();
            }
            return View(khoNguyenLieu);
        }

        // POST: KhoNguyenLieus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SoLuong")] KhoNguyenLieu khoNguyenLieu)
        {
            if (id != khoNguyenLieu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khoNguyenLieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhoNguyenLieuExists(khoNguyenLieu.Id))
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
            return View(khoNguyenLieu);
        }

        // GET: KhoNguyenLieus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KhoNguyenLieus == null)
            {
                return NotFound();
            }

            var khoNguyenLieu = await _context.KhoNguyenLieus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khoNguyenLieu == null)
            {
                return NotFound();
            }

            return View(khoNguyenLieu);
        }

        // POST: KhoNguyenLieus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KhoNguyenLieus == null)
            {
                return Problem("Entity set 'CuaHangDoAnContext.KhoNguyenLieus'  is null.");
            }
            var khoNguyenLieu = await _context.KhoNguyenLieus.FindAsync(id);
            if (khoNguyenLieu != null)
            {
                _context.KhoNguyenLieus.Remove(khoNguyenLieu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhoNguyenLieuExists(int id)
        {
          return (_context.KhoNguyenLieus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
