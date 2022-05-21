using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudCoreMVC.Data;
using CrudCoreMVC.Models;
using CrudCoreMVC.ViewModels;
using WebApplication1.Repositories;

namespace CrudCoreMVC.Services
{
    public class SchoolService : ISchoolService
    {
        private ISchoolRepository _schoolRepository;
        public SchoolService(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }
        public void AddSchool(School school)
        {
            _schoolRepository.Add(school);
        }

        public void DeleteSchool(int id)
        {
            _schoolRepository.Delete(id);
        }

        public List<School> GetAllSchools()
        {
           return _schoolRepository.GetAll();
        }

        public School GetSingleSchoolById(int id) => _schoolRepository.GetSingleById(id);

        public List<Teacher> GetTeachersBySchoolId(int schoolId) => _schoolRepository.GetTeachersById(schoolId);
        

        public void UpdateSchool(School newSchool)
        {
            _schoolRepository.Update(newSchool);
        }

        public SchoolViewModel SchoolDeletionConfirmation(int id)
        {

            School school = GetSingleSchoolById(id);
            SchoolViewModel schoolVM = new SchoolViewModel()
            {
                Id = school.Id,
                SchoolName = school.Name
            };

            return schoolVM;

        }

        public SchoolViewModel SchoolDetails(int id)
        {
            School school = _schoolRepository.GetSingleById(id);
            SchoolViewModel schoolVM = new SchoolViewModel()
            {
                SchoolName = school.Name,
                Teachers = _schoolRepository.GetTeachersById(id)
            };
            return schoolVM;

        }
    }
}
