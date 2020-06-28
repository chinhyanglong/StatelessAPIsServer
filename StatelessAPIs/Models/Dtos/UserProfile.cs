using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StatelessAPIs.Models.Dtos
{
    public class UserProfile
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string Address { get; set; }
        public float EntryPoint { get; set; }

    }
}
