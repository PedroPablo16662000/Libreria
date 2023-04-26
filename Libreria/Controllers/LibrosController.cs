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
    public class LibrosController : Controller
    {
        private readonly LibreriaContext _context;

        public LibrosController(LibreriaContext context)
        {
            _context = context;
        }

        // GET: Libros
        /// <summary>
        /// Trae lista de libros
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var libreriaContext = _context.Libros.Include(l => l.Editoriales);
            return View(await libreriaContext.ToListAsync());
        }

        // GET: Libros/Details/5
        /// <summary>
        /// Trae detalle de un libro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.Editoriales)
                .FirstOrDefaultAsync(m => m.Isbn == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libros/Create
        /// <summary>
        /// Trae el formulario para crear un libro nuevo
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewData["EditorialesId"] = new SelectList(_context.Editoriales, "Id", "Nombre");
            return View();
        }

        // POST: Libros/Create
        /// <summary>
        /// Envía los datos para crear un libro nuevo
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Isbn,EditorialesId,Titulo,Sinopsis,NPaginas")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EditorialesId"] = new SelectList(_context.Editoriales, "Id", "Nombre", libro.EditorialesId);
            return View(libro);
        }

        // GET: Libros/Edit/5
        /// <summary>
        /// Trae el formulario para editar un libro a partír de su isbn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["EditorialesId"] = new SelectList(_context.Editoriales, "Id", "Nombre", libro.EditorialesId);
            return View(libro);
        }

        // POST: Libros/Edit/5
        /// <summary>
        /// Edita un libro a partír de su isbn
        /// </summary>
        /// <param name="id"></param>
        /// <param name="libro"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Isbn,EditorialesId,Titulo,Sinopsis,NPaginas")] Libro libro)
        {
            if (id != libro.Isbn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Isbn))
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
            ViewData["EditorialesId"] = new SelectList(_context.Editoriales, "Id", "Nombre", libro.EditorialesId);
            return View(libro);
        }

        // GET: Libros/Delete/5
        /// <summary>
        /// Formulario para borrar un libro a partír de su isbn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.Editoriales)
                .FirstOrDefaultAsync(m => m.Isbn == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libros/Delete/5
        /// <summary>
        /// Borra un libro luego de confirmación
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Verifica la existencia de un libro por su isbn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Isbn == id);
        }
    }
}
