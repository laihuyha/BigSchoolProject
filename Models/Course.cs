using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace BigSchoolProject.Models
{
    public class Course
    {
        public int id { get; set; }
        public bool isCanceled { get; set; }
        public ApplicationUser Lecture { get; set; }
        [Required]
        public string LectureID { get; set; }
        [Required]
        [StringLength(255)]
        public string Place { get; set; }
        public DateTime datetime { get; set; }
        public  Category Category { get; set; }
        [Required]
        public byte CategoryID { get; set; }
    }
}