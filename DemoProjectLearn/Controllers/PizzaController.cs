using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoProjectLearn.Models;

namespace DemoProjectLearn.Controllers
{
    public class PizzaController : Controller
    {
        private readonly AppDBContext _context;

        public PizzaController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Pizza
        public async Task<IActionResult> Index()
        {
            return View(await _context.pizzas.ToListAsync());
        }

        // GET: Pizza/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaModel = await _context.pizzas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pizzaModel == null)
            {
                return NotFound();
            }

            return View(pizzaModel);
        }

        // GET: Pizza/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pizza/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PName,Description,Size,Price,ImageUrl")] PizzaModel pizzaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pizzaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pizzaModel);
        }

        // GET: Pizza/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaModel = await _context.pizzas.FindAsync(id);
            if (pizzaModel == null)
            {
                return NotFound();
            }
            return View(pizzaModel);
        }

        // POST: Pizza/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PName,Description,Size,Price,ImageUrl")] PizzaModel pizzaModel)
        {
            if (id != pizzaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pizzaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaModelExists(pizzaModel.Id))
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
            return View(pizzaModel);
        }

        // GET: Pizza/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaModel = await _context.pizzas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pizzaModel == null)
            {
                return NotFound();
            }

            return View(pizzaModel);
        }

        // POST: Pizza/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pizzaModel = await _context.pizzas.FindAsync(id);
            _context.pizzas.Remove(pizzaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PizzaModelExists(int id)
        {
            return _context.pizzas.Any(e => e.Id == id);
        }
    }
}
