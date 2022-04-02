using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroElogin.Data;
using CadastroElogin.Models;
using Microsoft.AspNetCore.Http;

namespace CadastroElogin.Controllers
{
    public class TelefonesController : Controller
    {
        private readonly Context _context;

        public TelefonesController(Context context)
        {
            _context = context;
        }

        // GET: Telefones
        public async Task<IActionResult> Index()
        {
            var context = _context.passagens.Include(t => t.Usuario);
            return View(await context.ToListAsync());
        }

        // GET: Telefones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.passagens
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.Id_tel == id);
            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }

        // GET: Telefones/Create
        public IActionResult Create()
        {
            ViewData["Id_usuario"] = new SelectList(_context.clientes, "Id_usuario", "Email");
            return View();
        }

        // POST: Telefones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_tel,Id_usuario,Celeluar")] Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefone);
                await _context.SaveChangesAsync();
                TempData["Id_tel"] = telefone.Id_tel.ToString();
                TempData["Celular"] = telefone.Celeluar.ToString();
                
               
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_usuario"] = new SelectList(_context.clientes, "Id_usuario", "Email", telefone.Id_usuario);
            return View(telefone);
        }

        // GET: Telefones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.passagens.FindAsync(id);
            if (telefone == null)
            {
                return NotFound();
            }
            ViewData["Id_usuario"] = new SelectList(_context.clientes, "Id_usuario", "Email", telefone.Id_usuario);
            return View(telefone);
        }

        // POST: Telefones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_tel,Id_usuario,Celeluar")] Telefone telefone)
        {
            if (id != telefone.Id_tel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefoneExists(telefone.Id_tel))
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
            ViewData["Id_usuario"] = new SelectList(_context.clientes, "Id_usuario", "Email", telefone.Id_usuario);
            return View(telefone);
        }

        // GET: Telefones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.passagens
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.Id_tel == id);
            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }

        // POST: Telefones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefone = await _context.passagens.FindAsync(id);
            _context.passagens.Remove(telefone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefoneExists(int id)
        {
            return _context.passagens.Any(e => e.Id_tel == id);
        }
    }
}
