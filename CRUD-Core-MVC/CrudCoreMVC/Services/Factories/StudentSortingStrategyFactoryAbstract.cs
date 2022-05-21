using WebApplication1.Services.Strategies;

namespace WebApplication1.Services.Factories
{
    public abstract class StudentSortingStrategyFactoryAbstract
    {
        protected IStudentSortingStrategy studentSortingStrategy;
        public abstract IStudentSortingStrategy Create(string orderBy);
    }
}
