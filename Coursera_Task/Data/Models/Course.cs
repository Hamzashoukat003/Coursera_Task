using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursera_Task.Data.Models
{
    public class Courses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InstructorId { get; set; }
        public int TotalTime { get; set; }
        public int Credit { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
