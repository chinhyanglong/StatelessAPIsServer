using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StatelessAPIs.Data;
using StatelessAPIs.HandleException;
using StatelessAPIs.Models.Dtos;
using StatelessAPIs.Models.ModelInput;
using StatelessAPIs.Models.ModelOutput;
using StatelessAPIs.Models.ViewModel;
using StatelessAPIs.Services;
using StatelessAPIs.Services.Common;
using StatelessAPIs.Services.Interface;
using Swashbuckle.AspNetCore.Annotations;

namespace StatelessAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _CourseService;

        public CourseController(ApplicationDbContext db)
        {
            _CourseService = new CourseService(db);
        }
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete Course by id")]
        public void Delete(int id)
        {
            _CourseService.Delete(id);
        }


        [HttpPost]
        [Authorize(Policy = Policies.Admin)]
        [SwaggerOperation(Summary = "Insert Course")]
        public void Insert([FromBody] CourseInputInsert model, int teacherId)
        {
            _CourseService.Insert(model, teacherId);
        }

        [HttpPut]
        [Authorize(Policy = Policies.Admin)]
        [SwaggerOperation(Summary = "Update Course")]
        public void Update([FromBody] CourseInputUpdate model,  int teacherId)
        {
            _CourseService.Update(model, teacherId);
        }


        [HttpGet("{code}")]
        [SwaggerOperation(Summary = "Get Course by code")]
        public Course GetByCode(string code)
        {
            Course course = _CourseService.GetByCode(code);
            if (course == null)
            {
                throw new NotFoundExeception("Course not found");
            }

            return course;
        }


        [HttpGet]
        [SwaggerOperation(Summary = "Get list Course")]
        public PagedResult<Course> GetList([FromQuery(Name = "page")] int? page, [FromQuery(Name = "size")] int? size)
        {
            Pageable pageable = new Pageable(PaginatorUtils.GetPageNumber(page), PaginatorUtils.GetPageSize(size));
            return _CourseService.GetCourses(pageable);
        }

        [HttpGet("name/")]
        [SwaggerOperation(Summary = "Get Course With Filter")]
        public PagedResult<CourseFilterResult> CourseFilter(string userName, [FromQuery(Name = "filterBy")] string filterBy, [FromQuery(Name = "page")] int? page, [FromQuery(Name = "size")] int? size)
        {
            Pageable pageable = new Pageable(PaginatorUtils.GetPageNumber(page), PaginatorUtils.GetPageSize(size));
            return _CourseService.CourseFilter(userName,filterBy,pageable);
        }


        [HttpGet("course/")]
        [SwaggerOperation(Summary = "Get Course With Teacher")]
        public PagedResult<CourseTeacherResult> GetCourseWithTeacher([FromQuery(Name = "page")] int? page, [FromQuery(Name = "size")] int? size)
        {
            Pageable pageable = new Pageable(PaginatorUtils.GetPageNumber(page), PaginatorUtils.GetPageSize(size));
            return _CourseService.GetCourseWithTeacher(pageable);
        }
    }
}

