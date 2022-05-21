using CrudCoreMVC.Models;

namespace WebApplication1.Mementos
{
    public class StudentMemento
    {
        private Student _student;
        public StudentMemento(Student student)
        {
            _student = student;
        }

        public Student GetStudent()
        {
            return _student;
        }
    }
}
