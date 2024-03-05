﻿using System;

namespace Coursera_Task.ViewModels
{
    public class ReportViewModel
    {
        public string PIN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseName { get; set; }
        public DateTime CompletionDate { get; set; }
        public int TotalTime { get; set; }
        public int Credit { get; set; }
        public string InstructorFirstName { get; set; }
        public string InstructorLastName { get; set; }
    }
}
