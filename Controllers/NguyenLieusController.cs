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
    public class NguyenLieusController : Controller
    {
        private readonly CuaHangDoAnContext _context;

        public NguyenLieusController(CuaHangDoAnContext context)
        {
            _context = context;
        }

        // GET: NguyenLieus
        public async Task<IActionResult> Index()
        {
              return _context.NguyenLieus != null ? 
                          View(await _context.NguyenLieus.ToListAsync()) :
                          Problem("Entity set 'CuaHangDoAnContext.NguyenLieus'  is null.");
        }

        // GET: NguyenLieus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NguyenLieus == null)
            {
                return NotFound();
            }

            var nguyenLieu = await _context.NguyenLieus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nguyenLieu == null)
            {
                return NotFound();
            }

            return View(nguyenLieu);
        }

        // GET: NguyenLieus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NguyenLieus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenNguyenLieu,DonViTinh")] NguyenLieu nguyenLieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguyenLieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nguyenLieu);
        }

        // GET: NguyenLieus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NguyenLieus == null)
            {
                return NotFound();
            }

            var nguyenLieu = await _context.NguyenLieus.FindAsync(id);
            if (nguyenLieu == null)
            {
                return NotFound();
            }
            return View(nguyenLieu);
        }

        // POST: NguyenLieus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenNguyenLieu,DonViTinh")] NguyenLieu nguyenLieu)
        {
            if (id != nguyenLieu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguyenLieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguyenLieuExists(nguyenLieu.Id))
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
            return View(nguyenLieu);
        }

        // GET: NguyenLieus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NguyenLieus == null)
            {
                return NotFound();
            }

            var nguyenLieu = await _context.NguyenLieus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nguyenLieu == null)
            {
                return NotFound();
            }

            return View(nguyenLieu);
        }

        // POST: NguyenLieus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NguyenLieus == null)
            {
                return Problem("Entity set 'CuaHangDoAnContext.NguyenLieus'  is null.");
            }
            var nguyenLieu = await _context.NguyenLieus.FindAsync(id);
            if (nguyenLieu != null)
            {
                _context.NguyenLieus.Remove(nguyenLieu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguyenLieuExists(int id)
        {
          return (_context.NguyenLieus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
