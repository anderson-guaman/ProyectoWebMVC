using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoPerfecto.Data;
using AutoPerfecto.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AutoPerfecto.Controllers
{
    public class ComprasController : Controller
    {
        private readonly BDContext _context;

        public ComprasController(BDContext context)
        {
            _context = context;
        }

        // GET: Compras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Compra.ToListAsync());
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public async Task<IActionResult> Create(int? id) // el identificador debe ser igual al asp-route-[nombreIdentificador] de la vista en la eti <a>
        {
            //var seleccionAuto= await _context.Auto.FirstOrDefaultAsync(m => m.Id == AutoId);// envias un modelo
            //var auto=  await _context.Auto.FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.Seleccion = id;
            //ViewData["auto"] = autoSelec;// sirve mas para cadenas de texto por o si no debes formatear al tipo de dato que requieres con el as 
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id" ,"Nombre");


            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create([Bind("PrecioVenta,Fecha,ClienteId,AutoId")] Compra compra,int? idauto) // el nobre de la variable debe ser igual al nombre que estas enviando desde la etiqueta a
        {
            var auto = await _context.Auto.FirstOrDefaultAsync(a => a.Id == idauto);
            if (auto != null)
            {
                if (!auto.Vendido)
                {
                    if (ModelState.IsValid)
                    {
                        _context.Compra.Add(compra);
                        await _context.SaveChangesAsync();

                        auto.Vendido=true;
                        _context.Auto.Update(auto);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Seleccion = auto.Id;
                        ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nombre");
                        return View(compra);
                    }
                }
                else
                {
                    TempData["Mensaje"] = "¡El auto ya ha sido vendido!";
                    ViewBag.Seleccion = auto.Id;
                    ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nombre");
                    return View(compra);
                }
            }
            else
            {
                TempData["Mensaje"] = "¡El auto no existe!";
                ViewBag.Seleccion = auto.Id;
                ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nombre");
                return View(compra);
            }
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PrecioVenta,Fecha,ClienteId,AutoId")] Compra compra)
        {
            if (id != compra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.Id))
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
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compra = await _context.Compra.FindAsync(id);
            if (compra != null)
            {
                _context.Compra.Remove(compra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(int id)
        {
            return _context.Compra.Any(e => e.Id == id);
        }
    }
}
