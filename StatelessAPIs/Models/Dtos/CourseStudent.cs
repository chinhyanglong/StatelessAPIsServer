using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StatelessAPIs.Models.Dtos
{
    public class CourseStudent
    {
        public int StudentId { get; set; }
        [Key]
        public int CourseId { get; set; }

    }
}
