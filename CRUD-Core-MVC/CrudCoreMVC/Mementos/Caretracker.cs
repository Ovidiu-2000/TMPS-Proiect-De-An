using System;
using System.Collections;
using System.Collections.Generic;

namespace WebApplication1.Mementos
{
    public class Caretracker
    {
        private readonly IList<StudentMemento> _studendMementos = new List<StudentMemento>();
        private Caretracker()
        {

        }
        private static readonly Lazy<Caretracker> _instance =
        new Lazy<Caretracker>(() => new Caretracker());
        public static Caretracker Instance
        {
            get { return _instance.Value; }
        }
        public void AddMemento(StudentMemento studentMemento)
        {
            _studendMementos.Add(studentMemento);
        }

        public StudentMemento Undo(int index)
        {
            try
            {
                return _studendMementos[_studendMementos.Count - index];
            }
            catch
            {
                Console.WriteLine("No such Id");
                throw new IndexOutOfRangeException();
            }
        }
    }
}
