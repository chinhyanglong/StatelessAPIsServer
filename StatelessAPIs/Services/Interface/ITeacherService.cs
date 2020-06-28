using StatelessAPIs.Models.Dtos;
using StatelessAPIs.Models.ModelInput;
using StatelessAPIs.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatelessAPIs.Services.Interface
{
    public interface ITeacherService
    {
        public void Insert(TeacherInputInsert model);
        public void Update(TeacherInputUpdate model);
        public void Delete(int Id);
        PagedResult<Teacher> GetTeachers(Pageable pageable);
        public Teacher GetByCode(string code);
    }
}
