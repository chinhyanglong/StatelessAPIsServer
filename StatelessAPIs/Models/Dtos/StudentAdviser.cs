using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StatelessAPIs.Models.Dtos
{
    public class StudentAdviser
    {
        [Key]
        public int StudentId { get; set; }
        public int TeacherAdviserId { get; set; }

    }

}
