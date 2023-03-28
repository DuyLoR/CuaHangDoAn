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
    public class PhuongThucThanhToansController : Controller
    {
        private readonly CuaHangDoAnContext _context;

        public PhuongThucThanhToansController(CuaHangDoAnContext context)
        {
            _context = context;
        }

        // GET: PhuongThucThanhToans
        public async Task<IActionResult> Index()
        {
              return _context.PhuongThucThanhToans != null ? 
                          View(await _context.PhuongThucThanhToans.ToListAsync()) :
                          Problem("Entity set 'CuaHangDoAnContext.PhuongThucThanhToans'  is null.");
        }

        // GET: PhuongThucThanhToans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PhuongThucThanhToans == null)
            {
                return NotFound();
            }

            var phuongThucThanhToan = await _context.PhuongThucThanhToans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phuongThucThanhToan == null)
            {
                return NotFound();
            }

            return View(phuongThucThanhToan);
        }

        // GET: PhuongThucThanhToans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhuongThucThanhToans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenPhuongThuc")] PhuongThucThanhToan phuongThucThanhToan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phuongThucThanhToan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phuongThucThanhToan);
        }

        // GET: PhuongThucThanhToans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PhuongThucThanhToans == null)
            {
                return NotFound();
            }

            var phuongThucThanhToan = await _context.PhuongThucThanhToans.FindAsync(id);
            if (phuongThucThanhToan == null)
            {
                return NotFound();
            }
            return View(phuongThucThanhToan);
        }

        // POST: PhuongThucThanhToans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenPhuongThuc")] PhuongThucThanhToan phuongThucThanhToan)
        {
            if (id != phuongThucThanhToan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phuongThucThanhToan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhuongThucThanhToanExists(phuongThucThanhToan.Id))
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
            return View(phuongThucThanhToan);
        }

        // GET: PhuongThucThanhToans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PhuongThucThanhToans == null)
            {
                return NotFound();
            }

            var phuongThucThanhToan = await _context.PhuongThucThanhToans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phuongThucThanhToan == null)
            {
                return NotFound();
            }

            return View(phuongThucThanhToan);
        }

        // POST: PhuongThucThanhToans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PhuongThucThanhToans == null)
            {
                return Problem("Entity set 'CuaHangDoAnContext.PhuongThucThanhToans'  is null.");
            }
            var phuongThucThanhToan = await _context.PhuongThucThanhToans.FindAsync(id);
            if (phuongThucThanhToan != null)
            {
                _context.PhuongThucThanhToans.Remove(phuongThucThanhToan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhuongThucThanhToanExists(int id)
        {
          return (_context.PhuongThucThanhToans?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
