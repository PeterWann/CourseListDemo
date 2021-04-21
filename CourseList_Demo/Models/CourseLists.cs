using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CourseList_Demo.Models;

namespace CourseList.Models
{
    public class CourseLists
    {
        [Key]

        public int CourseId { get; set; }

        public string CourseName { get; set; }

        [ForeignKey("DeegreeId")]
        public DeegreeList DeegreeList { get; set; }

    }
}