using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using Models.Entities;

namespace Libreria.Controllers
{
    public class AutoresController : Controller
    {
        private readonly LibreriaContext _context;

        public AutoresController(LibreriaContext context)
        {
            _context = context;
        }

        // GET: Autores
        /// <summary>
        /// Trae la lista de autores
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Autores.ToListAsync());
        }

        // GET: Autores/Details/5
        /// <summary>
        /// Trae el detalle de un autor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autore = await _context.Autores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autore == null)
            {
                return NotFound();
            }

            return View(autore);
        }

        // GET: Autores/Create
        /// <summary>
        /// Trae el formulario para crear un autor
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autores/Create
        /// <summary>
        /// Crea un autor según los datos
        /// </summary>
        /// <param name="autore"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellidos")] Autore autore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autore);
        }

        // GET: Autores/Edit/5
        /// <summary>
        /// Trae el formulario para editar un autor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autore = await _context.Autores.FindAsync(id);
            if (autore == null)
            {
                return NotFound();
            }
            return View(autore);
        }

        // POST: Autores/Edit/5
        /// <summary>
        /// Edita los datos de un autor según el formulario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="autore"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellidos")] Autore autore)
        {
            if (id != autore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoreExists(autore.Id))
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
            return View(autore);
        }

        // GET: Autores/Delete/5
        /// <summary>
        /// Trae el formulario para borrar un autor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autore = await _context.Autores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autore == null)
            {
                return NotFound();
            }

            return View(autore);
        }

        // POST: Autores/Delete/5
        /// <summary>
        /// Borra un autor luego de la confirmación
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autore = await _context.Autores.FindAsync(id);
            _context.Autores.Remove(autore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Verifica la existencia de un autor por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool AutoreExists(int id)
        {
            return _context.Autores.Any(e => e.Id == id);
        }
    }
}
