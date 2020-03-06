using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebEducationService.Models;

namespace WebEducationService.Data {
    public class EdDBContext : DbContext {
        public EdDBContext (DbContextOptions<EdDBContext> options)
            : base(options) {

        }

        public DbSet<Major> Majors { get; set; }
        public DbSet<Student2> Students2 { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
    }
}
