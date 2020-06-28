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
    public interface ICourseService
    {
        public void Insert(CourseInputInsert model,int teacherId);
        public void Update(CourseInputUpdate model, int teacherId);
        public void Delete(int Id);
        PagedResult<Course> GetCourses(Pageable pageable);
        public Course GetByCode(string code);
        PagedResult<CourseFilterResult> CourseFilter(string userName, string filterBy, Pageable pageable);
        PagedResult<CourseTeacherResult> GetCourseWithTeacher(Pageable pageable);

    }
}
