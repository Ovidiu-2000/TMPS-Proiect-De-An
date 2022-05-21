using WebApplication1.Services.Strategies;

namespace WebApplication1.Services.Factories
{
    public class StudentSortingStrategyFactory : StudentSortingStrategyFactoryAbstract
    {
        public override IStudentSortingStrategy Create(string orderBy)
        {
            switch (orderBy.ToLower())
            {
                case "name": studentSortingStrategy = new SortingStudentByName(); break;
                case "gpa": studentSortingStrategy = new SortingStudentByGPA(); break;
                case "age": studentSortingStrategy = new SortingStudentByAge(); break;
            }
            return studentSortingStrategy;
        }
    }
}
