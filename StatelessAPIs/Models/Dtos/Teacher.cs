using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace StatelessAPIs.Models.Dtos
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string ImageUrl { get; set; }
    }
}
