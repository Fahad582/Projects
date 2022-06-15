using Assignmentproject.Data;
using Assignmentproject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Assignmentproject.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _context.categories;

            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)

        {
            if (ModelState.IsValid)

            {
                _context.categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);

        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _context.categories.Find(id);
            if ( category == null)
            {
                return NotFound();
            }
            return View( category);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category update)

        {
            if (ModelState.IsValid)

            {
                _context.categories.Update(update);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

    }
}


