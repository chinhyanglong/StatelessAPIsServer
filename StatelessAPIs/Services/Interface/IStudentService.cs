using StatelessAPIs.Models.Dtos;
using StatelessAPIs.Models.ModelInput;
using StatelessAPIs.Models.ModelOutput;
using StatelessAPIs.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatelessAPIs.Services.Interface
{
    public interface IStudentService
    {
        public void Insert(StudentInputInsert model);
        public void Update(StudentInputUpdate model);
        public void Delete(int Id);
        PagedResult<Student> GetStudents(Pageable pageable);
        public Student GetByCode(string code);
        public void CourseRegistation(string userName, int courseId);
        public void AddStudentAdviser(string userName, int teacherId);
        public StudentAdviserResult GetStudentWithAdviser(string userName);
    }
}
