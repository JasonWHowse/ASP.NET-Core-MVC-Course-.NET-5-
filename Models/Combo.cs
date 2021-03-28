using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rocku.Models {
    public class Combo : Controller {
        public IQueryable<Category> CatTable { get; set; }
        public IQueryable<Application> AppTable { get; set; }
    }
}
