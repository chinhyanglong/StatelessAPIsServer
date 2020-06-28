using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatelessAPIs.Models.ModelOutput
{
    public class CourseFilterResult
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public int MaxPeople { get; set; }
    }
}
