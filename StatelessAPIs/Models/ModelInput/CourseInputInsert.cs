using StatelessAPIs.Models.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace StatelessAPIs.Models.ModelInput
{
    public class CourseInputInsert
    {
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
