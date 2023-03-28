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
    public class HoaDonMuaNguyenLieusController : Controller
    {
        private readonly CuaHangDoAnContext _context;

        public HoaDonMuaNguyenLieusController(CuaHangDoAnContext context)
        {
            _context = context;
        }

        // GET: HoaDonMuaNguyenLieus
        public async Task<IActionResult> Index()
        {
              return _context.HoaDonMuaNguyenLieus != null ? 
                          View(await _context.HoaDonMuaNguyenLieus.ToListAsync()) :
                          Problem("Entity set 'CuaHangDoAnContext.HoaDonMuaNguyenLieus'  is null.");
        }

        // GET: HoaDonMuaNguyenLieus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HoaDonMuaNguyenLieus == null)
            {
                return NotFound();
            }

            var hoaDonMuaNguyenLieu = await _context.HoaDonMuaNguyenLieus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hoaDonMuaNguyenLieu == null)
            {
                return NotFound();
            }

            return View(hoaDonMuaNguyenLieu);
        }

        // GET: HoaDonMuaNguyenLieus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HoaDonMuaNguyenLieus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NgayDat,SoLuong,GiaNguyenLieu,TongTien")] HoaDonMuaNguyenLieu hoaDonMuaNguyenLieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaDonMuaNguyenLieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hoaDonMuaNguyenLieu);
        }

        // GET: HoaDonMuaNguyenLieus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HoaDonMuaNguyenLieus == null)
            {
                return NotFound();
            }

            var hoaDonMuaNguyenLieu = await _context.HoaDonMuaNguyenLieus.FindAsync(id);
            if (hoaDonMuaNguyenLieu == null)
            {
                return NotFound();
            }
            return View(hoaDonMuaNguyenLieu);
        }

        // POST: HoaDonMuaNguyenLieus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NgayDat,SoLuong,GiaNguyenLieu,TongTien")] HoaDonMuaNguyenLieu hoaDonMuaNguyenLieu)
        {
            if (id != hoaDonMuaNguyenLieu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDonMuaNguyenLieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonMuaNguyenLieuExists(hoaDonMuaNguyenLieu.Id))
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
            return View(hoaDonMuaNguyenLieu);
        }

        // GET: HoaDonMuaNguyenLieus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HoaDonMuaNguyenLieus == null)
            {
                return NotFound();
            }

            var hoaDonMuaNguyenLieu = await _context.HoaDonMuaNguyenLieus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hoaDonMuaNguyenLieu == null)
            {
                return NotFound();
            }

            return View(hoaDonMuaNguyenLieu);
        }

        // POST: HoaDonMuaNguyenLieus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HoaDonMuaNguyenLieus == null)
            {
                return Problem("Entity set 'CuaHangDoAnContext.HoaDonMuaNguyenLieus'  is null.");
            }
            var hoaDonMuaNguyenLieu = await _context.HoaDonMuaNguyenLieus.FindAsync(id);
            if (hoaDonMuaNguyenLieu != null)
            {
                _context.HoaDonMuaNguyenLieus.Remove(hoaDonMuaNguyenLieu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonMuaNguyenLieuExists(int id)
        {
          return (_context.HoaDonMuaNguyenLieus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
