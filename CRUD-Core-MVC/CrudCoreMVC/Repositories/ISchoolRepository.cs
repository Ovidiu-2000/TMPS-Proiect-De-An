using CrudCoreMVC.Models;
using System.Collections.Generic;

namespace WebApplication1.Repositories
{
    public interface ISchoolRepository
    {
        void Add(School school);
        void Delete(int id);
        List<School> GetAll();
        School GetSingleById(int id);
        List<Teacher> GetTeachersById(int schoolId);
        void Update(School newSchool);
    }
}