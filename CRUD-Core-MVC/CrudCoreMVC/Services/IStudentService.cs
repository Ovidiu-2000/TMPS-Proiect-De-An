using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudCoreMVC.Models;
using CrudCoreMVC.ViewModels;
using WebApplication1.Models;

namespace CrudCoreMVC.Services
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        void AddStudent(Student student);
        Student GetSingleStudentById(int id);
        void UpdateStudent(Student newStudent);
        void DeleteStudent(int id);
        StudentViewModel StudentDeletionConfirmation(int id);
        List<Student> OrderStudents(string orderBy);
        ActivityCounterOnStudents GetTodayStatsOnStudents();
        void UndoEdit();
    }
}
