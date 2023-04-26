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
    public class EditorialesController : Controller
    {
        private readonly LibreriaContext _context;

        public EditorialesController(LibreriaContext context)
        {
            _context = context;
        }

        // GET: Editoriales
        /// <summary>
        /// Trae la lista de las editoriales
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Editoriales.ToListAsync());
        }

        // GET: Editoriales/Details/5
        /// <summary>
        /// Trae el detalle de una editorial
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editoriale = await _context.Editoriales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (editoriale == null)
            {
                return NotFound();
            }

            return View(editoriale);
        }

        // GET: Editoriales/Create
        /// <summary>
        /// Trae el formulario para crear una editorial nueva
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editoriales/Create
        /// <summary>
        /// Crea una editorial con los datos del formulario
        /// </summary>
        /// <param name="editoriale"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Sede")] Editoriale editoriale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editoriale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(editoriale);
        }

        // GET: Editoriales/Edit/5
        /// <summary>
        /// Trae el formulario para editar una editorial
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editoriale = await _context.Editoriales.FindAsync(id);
            if (editoriale == null)
            {
                return NotFound();
            }
            return View(editoriale);
        }

        // POST: Editoriales/Edit/5
        /// <summary>
        /// Edita una editorial con los datos del formulario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editoriale"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Sede")] Editoriale editoriale)
        {
            if (id != editoriale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editoriale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditorialeExists(editoriale.Id))
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
            return View(editoriale);
        }

        // GET: Editoriales/Delete/5
        /// <summary>
        /// Trae el formulario para solicitar verificación de borrar una editorial
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editoriale = await _context.Editoriales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (editoriale == null)
            {
                return NotFound();
            }

            return View(editoriale);
        }

        // POST: Editoriales/Delete/5
        /// <summary>
        /// Borra una editorial luego de la confirmación
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var editoriale = await _context.Editoriales.FindAsync(id);
            _context.Editoriales.Remove(editoriale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Verifica si existe una editorial por el id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool EditorialeExists(int id)
        {
            return _context.Editoriales.Any(e => e.Id == id);
        }
    }
}
