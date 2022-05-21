using Microsoft.EntityFrameworkCore;
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
    public class TeacherService : ITeacherService
    {
        private ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public void AddTeacher(Teacher teacher)
        {
            _teacherRepository.Add(teacher);
        }

        public void DeleteTeacher(int id)
        {
            _teacherRepository.Delete(id);
        }

        public List<Teacher> GetAllTeachers()
        {
            return _teacherRepository.GetAll();
        }

        public Teacher GetSingleTeacherById(int id) => _teacherRepository.GetSingleById(id);

        public List<Student> GetStudentsByTeacherId(int teacherId) => _teacherRepository.GetStudentsById(teacherId);
        

        public void UpdateTeacher(Teacher newTeacher)
        {
            _teacherRepository.Update(newTeacher);
        }

        public TeacherViewModel TeacherDeletionConfirmation(int id)
        {

            Teacher teacher = _teacherRepository.GetSingleById(id);
            TeacherViewModel teacherVM = new TeacherViewModel()
            {
                Id = teacher.Id,
                TeacherName = teacher.FullName
            };

            return teacherVM;

        }

        public TeacherViewModel TeacherDetails(int id)
        {
            Teacher teacher = _teacherRepository.GetSingleById(id);
            TeacherViewModel teacherVM = new TeacherViewModel()
            {
                TeacherName = teacher.FullName,
                Students = GetStudentsByTeacherId(id)
            };
            return teacherVM;

        }
    }
}
