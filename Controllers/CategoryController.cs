using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocku.Data;
using Rocku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocku.Controllers {
    public class CategoryController : Controller {

        private readonly ApplicationDbContext db;

        public CategoryController(ApplicationDbContext db) {
            this.db = db;
        }

        public IActionResult Index() {
            IEnumerable<Category> objList = db.Category;
            return View(objList);
        }

        public IActionResult Create() {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category row) {
            if (ModelState.IsValid) {
                db.Category.Add(row);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(row);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category row) {
            if (ModelState.IsValid) {
                db.Category.Update(row);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(row);
        }

        public IActionResult Edit(int? id) {
            if (id == null || id == 0) {
                return NotFound();
            }
            Category row = db.Category.Find(id);
            if (row == null) {
                return NotFound();
            }
            return View(row);
        }


        [HttpPost]
        public IActionResult Delete(Category row) {
            db.Category.Remove(db.Category.Find(row.Id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Clone(int id) {
            Category row = db.Category.FirstOrDefault(u => u.Id == id);
            if (row == null) {
                return NotFound();
            }
            db.Category.Add(new Category { Name = row.Name, DisplayOrder = row.DisplayOrder });
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            return Edit(id);
        }


    }
}
