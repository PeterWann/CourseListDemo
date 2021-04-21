using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CourseList.Models;

namespace CourseList_Demo.Models
{
    public class DeegreeList
    {
        [Key]
        public int DeegreeId { get; set; }

        public string DeegreeName { get; set; }

        public List<CourseLists> CourseLists { get; set; }
    }
}
