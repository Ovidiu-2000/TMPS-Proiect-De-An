using System;

namespace WebApplication1.Models
{
    public class ActivityCounterOnStudents
    {
        private int _studentsEditedToday;
        private int _studentsDeletedToday;
        private int _studentsAddedToday;
        private ActivityCounterOnStudents()
        {

        }
        private static readonly Lazy<ActivityCounterOnStudents> _instance =
        new Lazy<ActivityCounterOnStudents>(() => new ActivityCounterOnStudents());

        public static ActivityCounterOnStudents Instance
        {
            get { return _instance.Value; }
        }
        private DateTime _currentDate = DateTime.Now.Date;
        private int UpdateToCurrentDate(int currentValue)
        {
            return DateTime.Now.Date != _currentDate ? 0 : currentValue;
        }
        public int StudentsAddedToday
        {
            set
            {
                _studentsAddedToday = UpdateToCurrentDate(value);
            }
            get
            {
                return _studentsAddedToday;
            }
        }
        
        public int StudentsEditedToday
        {
            set
            {
                _studentsEditedToday = UpdateToCurrentDate(value);
            }
            get
            {
                return _studentsEditedToday;
            }
        }
        public int StudentsDeletedToday
        {
            set
            {
                _studentsDeletedToday = UpdateToCurrentDate(value);
            }
            get
            {
                return _studentsDeletedToday;
            }
        }
    }
}
