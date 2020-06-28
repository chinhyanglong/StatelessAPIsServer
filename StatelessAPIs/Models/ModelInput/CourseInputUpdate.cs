using StatelessAPIs.Models.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StatelessAPIs.Models.ModelInput
{
    public class CourseInputUpdate
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public CourseLevel Level { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public int MaxPeople { get; set; }
    }
}
