using System;

namespace Coursera_Task.ViewModels
{
    public class ReportViewModel
    {
        public string PIN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseName { get; set; }
        public DateTime CompletionDate { get; set; }
        public byte TotalTime { get; set; }
        public byte Credit { get; set; }
        public string InstructorFirstName { get; set; }
        public string InstructorLastName { get; set; }
    }
}
