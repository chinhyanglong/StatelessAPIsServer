using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatelessAPIs.Models.ModelInput
{
    public class TeacherInputUpdate
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string ImageUrl { get; set; }
    }
}
