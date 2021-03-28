using Microsoft.AspNetCore.Mvc;
using Rocku.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rocku.Models;
using Microsoft.EntityFrameworkCore;

namespace Rocku.Controllers {
    public class ApplicationController : Controller {

        private readonly ApplicationDbContext db;

        public ApplicationController(ApplicationDbContext db) {
            this.db = db;
        }

        public IActionResult Index() {
            IEnumerable<Application> objList = db.Application;
            return View(objList);
        }

        public IActionResult Create() {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Application row) {
            db.Application.Add(row);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Application row) {
            if (ModelState.IsValid) {
                db.Application.Update(row);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(row);
        }

        public IActionResult Edit(int? id) {
            if (id == null || id == 0) {
                return NotFound();
            }
            Application row = db.Application.Find(id);
            if (row == null) {
                return NotFound();
            }
            return View(row);
        }

        [HttpPost]
        public IActionResult Delete(Application row) {
            db.Application.Remove(db.Application.Find(row.Id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Clone(int id) {
            Application row = db.Application.FirstOrDefault(u => u.Id == id);
            if (row == null) {
                return NotFound();
            }
            db.Application.Add(new Application { Name = row.Name, Category = row.Category });
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            return Edit(id);
        }
    }
}
