using CrudCoreMVC.Data;
using CrudCoreMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private AppDbContext _context;
        public TeacherRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Teacher teacherToBeDeleted = GetSingleById(id);
            _context.Teachers.Remove(teacherToBeDeleted);
            _context.SaveChanges();
        }

        public List<Teacher> GetAll()
        {
            List<Teacher> teachers = _context.Teachers.Include(n => n.School).ToList();
            return teachers;
        }

        public Teacher GetSingleById(int id) => _context.Teachers.Where(n => n.Id == id).FirstOrDefault();

        public List<Student> GetStudentsById(int teacherId) => _context.Students.Where(n => n.TeacherId == teacherId).ToList();


        public void Update(Teacher newTeacher)
        {
            Teacher oldTeacher = GetSingleById(newTeacher.Id);
            oldTeacher.FullName = newTeacher.FullName;
            oldTeacher.Age = newTeacher.Age;
            oldTeacher.PhoneNumber = newTeacher.PhoneNumber;
            oldTeacher.YearsOfExperience = newTeacher.YearsOfExperience;
            oldTeacher.Subject = newTeacher.Subject;
            oldTeacher.SchoolId = newTeacher.SchoolId;
            _context.SaveChanges();
        }
    }
}
