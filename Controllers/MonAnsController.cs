﻿using System;
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
    public class MonAnsController : Controller
    {
        private readonly CuaHangDoAnContext _context;

        public MonAnsController(CuaHangDoAnContext context)
        {
            _context = context;
        }


        // GET: MonAns
        public async Task<IActionResult> Index()
        {
              return _context.MonAns != null ? 
                          View(await _context.MonAns.ToListAsync()) :
                          Problem("Entity set 'CuaHangDoAnContext.MonAns'  is null.");
        }

        // GET: MonAns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MonAns == null)
            {
                return NotFound();
            }

            var monAn = await _context.MonAns
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monAn == null)
            {
                return NotFound();
            }

            return View(monAn);
        }

        // GET: MonAns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MonAns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenMon,Gia")] MonAn monAn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monAn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monAn);
        }

        // GET: MonAns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MonAns == null)
            {
                return NotFound();
            }

            var monAn = await _context.MonAns.FindAsync(id);
            if (monAn == null)
            {
                return NotFound();
            }
            return View(monAn);
        }

        // POST: MonAns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenMon,Gia")] MonAn monAn)
        {
            if (id != monAn.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monAn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonAnExists(monAn.Id))
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
            return View(monAn);
        }

        // GET: MonAns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MonAns == null)
            {
                return NotFound();
            }

            var monAn = await _context.MonAns
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monAn == null)
            {
                return NotFound();
            }

            return View(monAn);
        }

        // POST: MonAns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MonAns == null)
            {
                return Problem("Entity set 'CuaHangDoAnContext.MonAns'  is null.");
            }
            var monAn = await _context.MonAns.FindAsync(id);
            if (monAn != null)
            {
                _context.MonAns.Remove(monAn);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonAnExists(int id)
        {
          return (_context.MonAns?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
