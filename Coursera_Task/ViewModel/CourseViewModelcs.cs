using Coursera_Task.Data.Models;

namespace Coursera_Task.ViewModel
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InstructorId { get; set; }
        public int TotalTime { get; set; }
        public int Credit { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
