using CrudCoreMVC.Models;
using System.Collections.Generic;

namespace WebApplication1.Services.Strategies
{
    public interface IStudentSortingStrategy
    {
        List<Student> Sort(List<Student> students);
    }
}
