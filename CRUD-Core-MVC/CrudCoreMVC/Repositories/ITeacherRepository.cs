using CrudCoreMVC.Models;
using System.Collections.Generic;

namespace WebApplication1.Repositories
{
    public interface ITeacherRepository
    {
        void Add(Teacher teacher);
        void Delete(int id);
        List<Teacher> GetAll();
        Teacher GetSingleById(int id);
        List<Student> GetStudentsById(int teacherId);
        void Update(Teacher newTeacher);
    }
}