using Coursera_Task.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursera_Task.Data.Models
{
    public class Students
    {
        public string PIN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime TimeCreated { get; set; }
        public List<StudentCourseXref> CompletedCourses { get; set; }
    }
}
