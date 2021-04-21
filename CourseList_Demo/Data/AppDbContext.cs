using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseList.Models;
using CourseList_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        
        public DbSet<CourseLists> CourseLists { get; set; }

        public DbSet<DeegreeList> DeegreeLists { get; set; }

        
    }
}