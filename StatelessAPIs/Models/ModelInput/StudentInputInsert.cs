using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StatelessAPIs.Models.ModelInput
{
    public class StudentInputInsert
    {
        public string Code { get; set; }
        [StringLength(256, MinimumLength = 0, ErrorMessage = "Length of {0} field should be between {2} and {1}.")]
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string Address { get; set; }
        [Range(0.0, 10.0, ErrorMessage = "Please enter valid float Number")]
        public float EntryPoint { get; set; }
        public string UserName { get; set; }
    }
}
