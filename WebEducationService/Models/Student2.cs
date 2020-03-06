using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebEducationService.Models {
    public class Student2 {

        public int Id { get; set; }
        [StringLength(30)]
        [Required]
        public string Firstname { get; set; }
        [StringLength(30)]
        [Required]
        public string Lastname { get; set; }
        public string GPA { get; set; }
        public int SAT { get; set; }
        public int MajorId { get; set; }
        public virtual Major Major { get; set; }

        

        public Student2() { }
    }
}
