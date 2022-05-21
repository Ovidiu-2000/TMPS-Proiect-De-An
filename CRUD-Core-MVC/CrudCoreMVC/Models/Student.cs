using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Mementos;

namespace CrudCoreMVC.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Please provide full name!")]
        [StringLength (25, ErrorMessage = "Full name is too long.")]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Display(Name = "Middle name")]
        public string MiddleName { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }

        [Range(15,25, ErrorMessage = "Age should be between 15 and 25")]
        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        [Range(0,10.0, ErrorMessage = "Provide a valid GPA.")]
        public double GPA { get; set; }

        //Relations
        public virtual Teacher Teacher { get; set; }
        [Display(Name = "Teacher Name")]
        public int TeacherId { get; set; }

        public StudentMemento CreateMemento()
        {
            return new StudentMemento(this);
        }

        public void SetMemento(StudentMemento memento)
        {
            var mementoStudent = memento.GetStudent();
            this.Age = mementoStudent.Age;
            this.FullName = mementoStudent.FullName;
            this.TeacherId = mementoStudent.TeacherId;
            this.Teacher = mementoStudent.Teacher;
            this.Birthday = mementoStudent.Birthday;
            this.EmailAddress = mementoStudent.EmailAddress;
            this.GPA = mementoStudent.GPA;
        }

    }
}
