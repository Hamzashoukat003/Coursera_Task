using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Coursera_Task.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Coursera_Task.Data.Models
{
    public class StudentCourseXref
    {
        public string StudentPin { get; set; }
        public int CourseId { get; set; }
        public DateTime? CompletionDate { get; set; }
       public Students Student { get; set; }
        public Courses Course { get; set; }
    }
}
