using CrudCoreMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Services.Strategies
{
    public class SortingStudentByName : IStudentSortingStrategy
    {
        public List<Student> Sort(List<Student> students) => students.OrderBy(s => s.FullName.Split(',')[0]).ToList();
    }
}
