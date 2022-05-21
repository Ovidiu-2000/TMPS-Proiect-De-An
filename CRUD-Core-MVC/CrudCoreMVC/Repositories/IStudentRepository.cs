using CrudCoreMVC.Models;
using System.Collections.Generic;

namespace WebApplication1.Repositories
{
    public interface IStudentRepository
    {
        void Add(Student student);
        void Delete(int id);
        List<Student> GetAll();
        Student GetSingleById(int id);
        void Update(Student newStudent);
    }
}