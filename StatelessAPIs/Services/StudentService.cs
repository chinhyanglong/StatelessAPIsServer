
using StatelessAPIs.Data;
using StatelessAPIs.HandleException;
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
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;
        public StudentService(ApplicationDbContext db)
        {
            _context = db;
        }

        public void Delete(int Id)
        {
            var student = _context.Student.FirstOrDefault(p => p.Id == Id);
            _context.Student.Remove(student);
            _context.SaveChanges();
        }

        public void Insert(StudentInputInsert model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var student = new Student();
                    student.Code = model.Code;
                    student.Name = model.Name;
                    student.Gender = model.Gender;
                    student.DayOfBirth = model.DayOfBirth;
                    student.Address = model.Address;
                    student.EntryPoint = model.EntryPoint;
                    _context.Student.Add(student);
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
                
            }
            
        }

        public void Update(StudentInputUpdate model)
        {
            var student = _context.Student.FirstOrDefault(p => p.Id == model.Id);
            if (student != null)
            {
                student.Code = model.Code;
                student.Name = model.Name;
                student.Gender = model.Gender;
                student.DayOfBirth = model.DayOfBirth;
                student.Address = model.Address;
                student.EntryPoint = model.EntryPoint;
                _context.SaveChanges();
            }
        }
        public PagedResult<Student> GetStudents(Pageable pageable)
        {
            PagedResult<Student> result = new PagedResult<Student>();
            result.Page = pageable.Page;
            result.Size = pageable.Size;
            int skipRow = PaginatorUtils.GetSkipRow(pageable.Page, pageable.Size);
            result.Total = _context.Student.Count();
            if (result.Total > 0)
            {
                List<Student> entities = _context.Student
                    .Skip(skipRow)
                    .Take(pageable.Size).ToList();
                result.Data = entities;
            }
            return result;
        }

        public Student GetByCode(string code)
        {
            return _context.Student.SingleOrDefault(x => x.Code == code);
        }

        public void CourseRegistation(string userName,int courseId)
        {
            var student = _context.Student.Where(p => String.Equals(p.UserName, userName, StringComparison.CurrentCultureIgnoreCase)).SingleOrDefault();
            var courseCount = _context.CourseStudent.Where(p => p.CourseId == courseId).Count();
            var course = _context.Course.FirstOrDefault(p => p.Id == courseId);
            if(course.BeginDate < DateTime.Now)
            {
                throw new BadRequestException("Out of time to register");
            }
            else if(courseCount >= course.MaxPeople)
            {
                throw new BadRequestException("Course is full");
            }
            else
            {
                var courseRegis = new CourseStudent();
                courseRegis.StudentId = student.Id;
                courseRegis.CourseId = courseId;
                _context.CourseStudent.Add(courseRegis);
                _context.SaveChanges();
            }    
        }

        public void AddStudentAdviser(string userName, int teacherId)
        {
            var student = _context.Student.Where(p => String.Equals(p.UserName, userName, StringComparison.CurrentCultureIgnoreCase)).SingleOrDefault();
            var studentAdviser = new StudentAdviser();
            if(student != null)
            {
                studentAdviser.StudentId = student.Id;
                studentAdviser.TeacherAdviserId = teacherId;
            }
            _context.StudentAdviser.Add(studentAdviser);
            _context.SaveChanges();
        }

        public StudentAdviserResult GetStudentWithAdviser(string userName)
        {
            var student = _context.Student.Where(p => String.Equals(p.UserName, userName, StringComparison.CurrentCultureIgnoreCase)).SingleOrDefault();
            if(student == null)
            {

            }    
            StudentAdviserResult stuAdv = (StudentAdviserResult)(from s in _context.Student
                              join sa in _context.StudentAdviser on s.Id equals sa.StudentId
                              join t in _context.Teacher on sa.TeacherAdviserId equals t.Id
                              where s.Id == student.Id
                              select new StudentAdviserResult()
                              {
                                  Code = s.Code,
                                  Name = s.Name,
                                  Gender = s.Gender,
                                  DayOfBirth = s.DayOfBirth,
                                  Address = s.Address,
                                  EntryPoint = s.EntryPoint,
                                  TeacherCode = t.Code,
                                  TeacherName = t.Name,
                                  ImageUrl = t.ImageUrl,
                              });
            return stuAdv;
        }
    }
}
