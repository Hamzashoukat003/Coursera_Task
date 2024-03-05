using Coursera_Task.Data.Models;

namespace Coursera_Task.ViewModels
{
    public class StudentCourseViewModel
    {
        public string StudentPin { get; set; }
        public int CourseId { get; set; }
        public DateTime? CompletionDate { get; set; }
    }
}