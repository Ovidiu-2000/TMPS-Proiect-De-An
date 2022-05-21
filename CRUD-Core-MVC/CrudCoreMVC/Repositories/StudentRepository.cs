using CrudCoreMVC.Data;
using CrudCoreMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Mementos;

namespace WebApplication1.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Student studentToBeDeleted = GetSingleById(id);
            _context.Students.Remove(studentToBeDeleted);
            _context.SaveChanges();
        }

        public List<Student> GetAll()
        {
            List<Student> students = _context.Students.Include(n => n.Teacher).ToList();
            return students;
        }

        public Student GetSingleById(int id) => _context.Students.Where(n => n.Id == id).FirstOrDefault();



        public void Update(Student newStudent)
        {
            Student oldStudent = GetSingleById(newStudent.Id);
            oldStudent.FullName = newStudent.FullName;
            oldStudent.MiddleName = newStudent.MiddleName;
            oldStudent.EmailAddress = newStudent.EmailAddress;
            oldStudent.Age = newStudent.Age;
            oldStudent.Birthday = newStudent.Birthday;
            oldStudent.GPA = newStudent.GPA;
            oldStudent.TeacherId = newStudent.TeacherId;
            _context.SaveChanges();
        }
    }
}
