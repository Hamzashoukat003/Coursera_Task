using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursera_Task.Data.Models
{
    public class Courses
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        public byte TotalTime { get; set; }
        public byte Credit { get; set; }
        public Instructor Instructor { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
