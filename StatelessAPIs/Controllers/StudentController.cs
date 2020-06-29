
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StatelessAPIs.Data;
using StatelessAPIs.HandleException;
using StatelessAPIs.Models.Dtos;
using StatelessAPIs.Models.ModelInput;
using StatelessAPIs.Models.ViewModel;
using StatelessAPIs.Services;
using StatelessAPIs.Services.Common;
using StatelessAPIs.Services.Interface;
using Swashbuckle.AspNetCore.Annotations;

namespace StatelessAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        private readonly IStudentService _StudentService;

        
        public StudentController(IStudentService studentService)
        {
            _StudentService = studentService;
        }
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Admin)]
        [SwaggerOperation(Summary = "Delete Student by id")]
        public void Delete(int id)
        {
            _StudentService.Delete(id);
        }


        [HttpPost]
        [SwaggerOperation(Summary = "Insert Student")]
        public void Insert([FromBody] StudentInputInsert model)
        {
            _StudentService.Insert(model);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update Student")]
        public void Update([FromBody] StudentInputUpdate model)
        {
            _StudentService.Update(model);
        }

        [HttpGet("{code}")]
        [SwaggerOperation(Summary = "Get Student by Code")]
        public Student GetByCode(string code)
        {
            Student student = _StudentService.GetByCode(code);
            if (student == null)
            {
                throw new NotFoundExeception("Student not found");
            }

            return student;
        }
        [HttpGet]
        [Authorize(Policy = Policies.Admin)]
        public PagedResult<Student> GetList( [FromQuery(Name = "page")] int? page, [FromQuery(Name = "size")] int? size)
        {
            Pageable pageable = new Pageable(PaginatorUtils.GetPageNumber(page), PaginatorUtils.GetPageSize(size));
            return _StudentService.GetStudents(pageable);
        }
        
        [HttpPost("registration/")]
        [SwaggerOperation(Summary = "Course registration")]
        public void CourseRegistration(string userName,  int courseId)
        {
            _StudentService.CourseRegistation(userName, courseId);
        }

        [HttpPost("student/")]
        [Authorize(Policy = Policies.User)]
        [SwaggerOperation(Summary = "Add adviser for student")]
        public void AddStudentAdviser(string userName,  int teacherId)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new BadRequestException("userName can not be empty");
            }
            _StudentService.AddStudentAdviser(userName, teacherId);
        }


    }
}

