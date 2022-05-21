using System.Collections.Generic;
using System.Linq;
using CrudCoreMVC.Data;
using CrudCoreMVC.Models;

namespace WebApplication1.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private AppDbContext _context;
        public SchoolRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(School school)
        {
            _context.Schools.Add(school);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            School schoolToBeDeleted = GetSingleById(id);
            _context.Schools.Remove(schoolToBeDeleted);
            _context.SaveChanges();
        }

        public List<School> GetAll()
        {
            return _context.Schools.ToList();
        }

        public School GetSingleById(int id) => _context.Schools.Where(n => n.Id == id).FirstOrDefault();

        public List<Teacher> GetTeachersById(int schoolId) => _context.Teachers.Where(n => n.SchoolId == schoolId).ToList();


        public void Update(School newSchool)
        {
            School oldSchool = GetSingleById(newSchool.Id);
            oldSchool.Address = newSchool.Address;
            oldSchool.FoundingYear = newSchool.FoundingYear;
            oldSchool.Name = newSchool.Name;
            oldSchool.NumberOfStudents = newSchool.NumberOfStudents;
            _context.SaveChanges();
        }
    }
}
