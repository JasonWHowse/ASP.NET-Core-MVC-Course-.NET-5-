using Microsoft.AspNetCore.Mvc;
using Rocku.Data;
using Rocku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocku.Controllers {
    public class ComboController : Controller {

        private readonly ApplicationDbContext db;

        public ComboController(ApplicationDbContext db) {
            this.db = db;
        }
        public IActionResult Index() {            
            return View(new Combo() { CatTable = db.Category, AppTable = db.Application });
        }
    }
}
