using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StatelessAPIs.Models.ModelInput
{
    public class StudentInputUpdate
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string Address { get; set; }

        [Range(0.0, 10.0, ErrorMessage = "Please enter valid float Number")]
        public float EntryPoint { get; set; }
        public string UserName { get; set; }
    }
}
