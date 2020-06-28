using StatelessAPIs.Data;
using StatelessAPIs.Models.Dtos;
using StatelessAPIs.Models.ModelInput;
using StatelessAPIs.Models.ViewModel;
using StatelessAPIs.Services.Common;
using StatelessAPIs.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatelessAPIs.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ApplicationDbContext _context;
        public TeacherService(ApplicationDbContext db)
        {
            _context = db;
        }

        public void Delete(int Id)
        {
            var teacher = _context.Teacher.FirstOrDefault(p => p.Id == Id);
            _context.Teacher.Remove(teacher);
            _context.SaveChanges();
        }

        public void Insert(TeacherInputInsert model)
        {
            var teacher = new Teacher();
            teacher.Code = model.Code;
            teacher.Name = model.Name;
            teacher.Gender = model.Gender;
            teacher.DayOfBirth = model.DayOfBirth;
            teacher.ImageUrl = model.ImageUrl;
            _context.Teacher.Add(teacher);
            _context.SaveChanges();
        }

        public void Update(TeacherInputUpdate model)
        {
            var teacher = _context.Teacher.FirstOrDefault(p => p.Id == model.Id);
            if (teacher != null)
            {
                teacher.Code = model.Code;
                teacher.Name = model.Name;
                teacher.Gender = model.Gender;
                teacher.DayOfBirth = model.DayOfBirth;
                teacher.ImageUrl = model.ImageUrl;
                _context.SaveChanges();
            }
        }
        public PagedResult<Teacher> GetTeachers(Pageable pageable)
        {
            PagedResult<Teacher> result = new PagedResult<Teacher>();
            result.Page = pageable.Page;
            result.Size = pageable.Size;
            int skipRow = PaginatorUtils.GetSkipRow(pageable.Page, pageable.Size);
            result.Total = _context.Teacher.Count();
            if (result.Total > 0)
            {
                List<Teacher> entities = _context.Teacher
                    .Skip(skipRow)
                    .Take(pageable.Size).ToList();
                result.Data = entities;
            }
            return result;
        }

        public Teacher GetByCode(string code)
        {
            return _context.Teacher.SingleOrDefault(x => x.Code == code);
        }
    }
}
