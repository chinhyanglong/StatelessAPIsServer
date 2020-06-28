using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatelessAPIs.Models.ModelOutput
{
    public class StudentAdviserResult
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string Address { get; set; }
        public float EntryPoint { get; set; }
        public string TeacherCode { get; set; }
        public string TeacherName { get; set; }
        public string ImageUrl { get; set; }
    }
}
