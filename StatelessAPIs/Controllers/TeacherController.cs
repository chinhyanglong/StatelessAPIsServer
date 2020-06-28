
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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _TeacherService;
        public TeacherController(ApplicationDbContext db)
        {
            _TeacherService = new TeacherService(db);
        }
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Admin)]
        [SwaggerOperation(Summary = "Delete Teacher by id")]
        public void Delete(int id)
        {
            _TeacherService.Delete(id);
        }


        [HttpPost]
        [SwaggerOperation(Summary = "Insert Teacher")]
        public void Insert([FromBody] TeacherInputInsert model)
        {
            _TeacherService.Insert(model);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update Teacher")]
        public void Update([FromBody] TeacherInputUpdate model)
        {
            _TeacherService.Update(model);
        }

        [HttpGet("{code}")]
        public Teacher GetByCode(string code)
        {
            Teacher teacher = _TeacherService.GetByCode(code);
            if (teacher == null)
            {
                throw new NotFoundExeception("Teacher not found");
            }

            return teacher;
        }
        [HttpGet]
        public PagedResult<Teacher> GetList([FromQuery(Name = "page")] int? page, [FromQuery(Name = "size")] int? size)
        {
            Pageable pageable = new Pageable(PaginatorUtils.GetPageNumber(page), PaginatorUtils.GetPageSize(size));
            return _TeacherService.GetTeachers(pageable);
        }
    }
}

