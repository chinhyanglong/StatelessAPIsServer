using StatelessAPIs.Data;
using StatelessAPIs.Models.Dtos;
using StatelessAPIs.Models.ModelInput;
using StatelessAPIs.Models.ModelOutput;
using StatelessAPIs.Models.ViewModel;
using StatelessAPIs.Services.Common;
using StatelessAPIs.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatelessAPIs.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _context;
        public CourseService(ApplicationDbContext db)
        {
            _context = db;
        }

        public void Delete(int Id)
        {
            var Course = _context.Course.FirstOrDefault(p => p.Id == Id);
            _context.Course.Remove(Course);
            _context.SaveChanges();
        }

        public void Insert(CourseInputInsert model,int teacherId)
        {
            var course = new Course();
            course.Code = model.Code;
            course.Name = model.Name;
            course.Description = model.Description;
            course.Level = model.Level;
            course.BeginDate = model.BeginDate;
            course.EndDate = model.EndDate;
            course.RegisterDate = model.RegisterDate;
            course.MaxPeople = model.MaxPeople;
            _context.Course.Add(course);
            _context.SaveChanges();
            var courseTeacher = new CourseTeacher();
            courseTeacher.CourseId = course.Id;
            courseTeacher.TeacherId = teacherId;
            _context.SaveChanges();
        }

        public void Update(CourseInputUpdate model, int teacherId)
        {
            var course = _context.Course.SingleOrDefault(p => p.Id == model.Id);
            if (course != null)
            {
                course.Code = model.Code;
                course.Name = model.Name;
                course.Description = model.Description;
                course.Level = model.Level;
                course.BeginDate = model.BeginDate;
                course.EndDate = model.EndDate;
                course.RegisterDate = model.RegisterDate;
                course.MaxPeople = model.MaxPeople;
                _context.SaveChanges();
                var courseTeacher = _context.CourseTeacher.SingleOrDefault(p => p.TeacherId == teacherId && p.CourseId == course.Id);
                if (courseTeacher != null)
                {
                    courseTeacher.TeacherId = teacherId;
                    _context.SaveChanges();
                }
            }
        }
        public PagedResult<Course> GetCourses(Pageable pageable)
        {
            PagedResult<Course> result = new PagedResult<Course>();
            result.Page = pageable.Page;
            result.Size = pageable.Size;
            int skipRow = PaginatorUtils.GetSkipRow(pageable.Page, pageable.Size);
            result.Total = _context.Course.Count();
            if (result.Total > 0)
            {
                List<Course> entities = _context.Course
                    .Skip(skipRow)
                    .Take(pageable.Size).ToList();
                result.Data = entities;
            }
            return result;
        }

        public Course GetByCode(string code)
        {
            return _context.Course.SingleOrDefault(x => x.Code == code);
        }
        public PagedResult<CourseFilterResult> CourseFilter(string userName, string filterBy, Pageable pageable)
        {
            var studentId = _context.Student.Where(p => String.Equals(p.UserName, userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault().Id;
            PagedResult<CourseFilterResult> result = new PagedResult<CourseFilterResult>();
            result.Page = pageable.Page;
            result.Size = pageable.Size;
            int skipRow = PaginatorUtils.GetSkipRow(pageable.Page, pageable.Size);
            result.Total = _context.Course.Count();
            if (result.Total > 0)
            {
                List<CourseFilterResult> query = new List<CourseFilterResult>() ;
                if (String.IsNullOrEmpty(filterBy))
                {
                    query = (from s in _context.Course
                             join c in _context.CourseStudent on s.Id equals c.StudentId
                             where c.StudentId == studentId
                             select new CourseFilterResult()
                             {
                                 Code = s.Code,
                                 Name = s.Name,
                                 Description = s.Description,
                                 BeginDate = s.BeginDate,
                                 EndDate = s.EndDate,
                                 RegisterDate = s.RegisterDate,
                                 MaxPeople = s.MaxPeople
                             }
                                 ).ToList();
                }
                else
                {
                    switch (filterBy)
                    {
                        case "ChuaBatDau":
                            query = (from s in _context.Course
                                     where s.BeginDate > DateTime.Now
                                     select new CourseFilterResult()
                                     {
                                         Code = s.Code,
                                         Name = s.Name,
                                         Description = s.Description,
                                         BeginDate = s.BeginDate,
                                         EndDate = s.EndDate,
                                         RegisterDate = s.RegisterDate,
                                         MaxPeople = s.MaxPeople
                                     }
                                     ).ToList();
                            break;
                        case "DangHoc":
                            query = (from s in _context.Course
                                     where s.BeginDate <= DateTime.Now && DateTime.Now >= s.EndDate
                                     select new CourseFilterResult()
                                     {
                                         Code = s.Code,
                                         Name = s.Name,
                                         Description = s.Description,
                                         BeginDate = s.BeginDate,
                                         EndDate = s.EndDate,
                                         RegisterDate = s.RegisterDate,
                                         MaxPeople = s.MaxPeople
                                     }
                                     ).ToList();
                            break;
                        case "DaKetThuc":
                            query = (from s in _context.Course
                                     where s.EndDate < DateTime.Now
                                     select new CourseFilterResult()
                                     {
                                         Code = s.Code,
                                         Name = s.Name,
                                         Description = s.Description,
                                         BeginDate = s.BeginDate,
                                         EndDate = s.EndDate,
                                         RegisterDate = s.RegisterDate,
                                         MaxPeople = s.MaxPeople
                                     }
                                     ).ToList();
                            break;
                    }
                }
                var resultEnd = query.Skip(skipRow)
                    .Take(pageable.Size).ToList();
                result.Data = resultEnd;
            }
            return result;
        }

        public PagedResult<CourseTeacherResult> GetCourseWithTeacher(Pageable pageable)
        {
            PagedResult<CourseTeacherResult> result = new PagedResult<CourseTeacherResult>();
            result.Page = pageable.Page;
            result.Size = pageable.Size;
            int skipRow = PaginatorUtils.GetSkipRow(pageable.Page, pageable.Size);
            result.Total = _context.Course.Count();
            if (result.Total > 0)
            {
                List<CourseTeacherResult> course = (from c in _context.Course
                                                    join ct in _context.CourseTeacher on c.Id equals ct.CourseId
                                                    join t in _context.Teacher on ct.TeacherId equals t.Id
                                                    select new CourseTeacherResult()
                                                    {
                                                        Code = c.Code,
                                                        Name = c.Name,
                                                        Description = c.Description,
                                                        BeginDate = c.BeginDate,
                                                        EndDate = c.EndDate,
                                                        RegisterDate = c.RegisterDate,
                                                        MaxPeople = c.MaxPeople,
                                                        TeacherCode = t.Code,
                                                        TeacherName = t.Name,
                                                        ImageUrl = t.ImageUrl,
                                                    }
                                                    ).ToList();

                var resultEnd = course.Skip(skipRow)
                    .Take(pageable.Size).ToList();
                result.Data = resultEnd;
            }
            return result;
        }
    }
}
