using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatelessAPIs.Models.ModelOutput
{
    public class StudentResult
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string Address { get; set; }
        public float EntryPoint { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
    }
}
