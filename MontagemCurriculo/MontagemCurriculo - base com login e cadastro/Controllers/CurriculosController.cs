﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MontagemCurriculo.Models;

namespace MontagemCurriculo.Controllers
{
    public class CurriculosController : Controller
    {
        private readonly Contexto _context;

        public CurriculosController(Contexto context)
        {
            _context = context;
        }

        // GET: Curriculos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Curriculos.Include(c => c.Usuario);
            return View(await contexto.ToListAsync());
        }

        // GET: Curriculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curriculo = await _context.Curriculos
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.CurriculoID == id);
            if (curriculo == null)
            {
                return NotFound();
            }

            return View(curriculo);
        }

        // GET: Curriculos/Create
        public IActionResult Create()
        {
            ViewData["UsuarioID"] = new SelectList(_context.Usuarios, "UsuaioID", "Email");
            return View();
        }

        // POST: Curriculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CurriculoID,Nome,UsuarioID")] Curriculo curriculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curriculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioID"] = new SelectList(_context.Usuarios, "UsuaioID", "Email", curriculo.UsuarioID);
            return View(curriculo);
        }

        // GET: Curriculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curriculo = await _context.Curriculos.FindAsync(id);
            if (curriculo == null)
            {
                return NotFound();
            }
            ViewData["UsuarioID"] = new SelectList(_context.Usuarios, "UsuaioID", "Email", curriculo.UsuarioID);
            return View(curriculo);
        }

        // POST: Curriculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CurriculoID,Nome,UsuarioID")] Curriculo curriculo)
        {
            if (id != curriculo.CurriculoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curriculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurriculoExists(curriculo.CurriculoID))
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
            ViewData["UsuarioID"] = new SelectList(_context.Usuarios, "UsuaioID", "Email", curriculo.UsuarioID);
            return View(curriculo);
        }

        // GET: Curriculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curriculo = await _context.Curriculos
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.CurriculoID == id);
            if (curriculo == null)
            {
                return NotFound();
            }

            return View(curriculo);
        }

        // POST: Curriculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curriculo = await _context.Curriculos.FindAsync(id);
            _context.Curriculos.Remove(curriculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurriculoExists(int id)
        {
            return _context.Curriculos.Any(e => e.CurriculoID == id);
        }
    }
}
