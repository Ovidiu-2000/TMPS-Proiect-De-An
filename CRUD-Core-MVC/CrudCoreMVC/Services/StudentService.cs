using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using CrudCoreMVC.Data;
using CrudCoreMVC.Models;
using CrudCoreMVC.ViewModels;
using WebApplication1.Repositories;
using WebApplication1.Services.Factories;
using WebApplication1.Services.Strategies;
using WebApplication1.Models;
using WebApplication1.Mementos;

namespace CrudCoreMVC.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _studentRepository;
        private StudentSortingStrategyFactoryAbstract _studentSortingStrategyFactoryAbstract;
        private Caretracker _caretracker;
        public StudentService(IStudentRepository studentRepository, StudentSortingStrategyFactoryAbstract studentSortingStrategyFactoryAbstract)
        {
            this._studentRepository = studentRepository;
            this._studentSortingStrategyFactoryAbstract = studentSortingStrategyFactoryAbstract;
            this._caretracker = Caretracker.Instance;
        }
        public void AddStudent(Student student)
        {            
            _studentRepository.Add(student);
            ActivityCounterOnStudents.Instance.StudentsAddedToday += 1;
        }

        public void DeleteStudent(int id)
        {
            _studentRepository.Delete(id);
            ActivityCounterOnStudents.Instance.StudentsDeletedToday += 1;
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        public Student GetSingleStudentById(int id) => _studentRepository.GetSingleById(id);

        

        public void UpdateStudent(Student newStudent)
        {
            var student = _studentRepository.GetSingleById(newStudent.Id);
            Caretracker.Instance.AddMemento(
                new Student
                {
                    Age = student.Age,
                    TeacherId = student.TeacherId,
                    Teacher = student.Teacher,
                    Birthday = student.Birthday,
                    EmailAddress = student.EmailAddress,
                    FullName = student.FullName,
                    GPA = student.GPA,
                    Id = student.Id,
                    MiddleName = student.MiddleName
                }.CreateMemento());
                
            _studentRepository.Update(newStudent);
            ActivityCounterOnStudents.Instance.StudentsEditedToday += 1;
        }

        public StudentViewModel StudentDeletionConfirmation(int id)
        {

            Student student = _studentRepository.GetSingleById(id);
            StudentViewModel studentVM = new StudentViewModel()
            {
                Id = student.Id,
                StudentName = student.FullName
            };

            return studentVM;

        }

        public List<Student> OrderStudents(string orderBy)
        {
            IStudentSortingStrategy strategy = _studentSortingStrategyFactoryAbstract.Create(orderBy);
            return strategy.Sort(_studentRepository.GetAll());
        }

        public ActivityCounterOnStudents GetTodayStatsOnStudents()
        {
            return ActivityCounterOnStudents.Instance;
        }

        public void UndoEdit()
        {
            _studentRepository.Update(_caretracker.Undo(1).GetStudent());
        }
    }
}
