using Microsoft.EntityFrameworkCore;
using Rocku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocku.Data {
    public class ApplicationDbContext:DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option) { }

        public DbSet<Category> Category { get; set; }

        public DbSet<Application> Application { get; set; }
    }
}
