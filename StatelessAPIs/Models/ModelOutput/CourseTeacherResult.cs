using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatelessAPIs.Models.ModelOutput
{
    public class CourseTeacherResult
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public int MaxPeople { get; set; }
        public string TeacherCode { get; set; }
        public string TeacherName { get; set; }
        public string ImageUrl { get; set; }
    }
}
